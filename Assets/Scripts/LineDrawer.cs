using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    public GameObject linePrefab; // Çizgi prefab
    public float maxDistance = 10f; // Çizgi uzunluk limiti
    public float energy = 1f; // Çizim için enerji
    public float energyCostPerUnit = 0.1f; // Çizgi başına enerji maliyeti (uzunluğa bağlı)
    public Color ghostColor = new Color(1, 1, 1, 0.5f); // Ghost çizginin rengi

    private LineRenderer ghostLine;
    private Vector3 startPoint;
    private bool isDrawing = false;
    private Vector3 lastPoint;

    private void Update()
    {
        // Mouse'a basıldığında
        if (Input.GetMouseButtonDown(0) && energy > 0)
        {
            StartDrawing();
        }

        // Mouse basılıyken
        if (isDrawing && Input.GetMouseButton(0))
        {
            UpdateDrawing();
        }

        // Mouse bırakıldığında
        if (Input.GetMouseButtonUp(0) && isDrawing)
        {
            FinishDrawing();
        }
    }

    private void StartDrawing()
    {
        // Çizim başlangıç noktası
        startPoint = GetMouseWorldPosition();
        lastPoint = startPoint;
        isDrawing = true;

        // Ghost çizgi oluştur
        if (ghostLine == null)
        {
            GameObject ghostObj = new GameObject("GhostLine");
            ghostLine = ghostObj.AddComponent<LineRenderer>();
            ghostLine.material = new Material(Shader.Find("Sprites/Default"));
            ghostLine.startColor = ghostColor;
            ghostLine.endColor = ghostColor;
            ghostLine.startWidth = 0.1f;
            ghostLine.endWidth = 0.1f;
            ghostLine.positionCount = 1; // Başlangıçta bir nokta
            ghostLine.SetPosition(0, startPoint);
        }
    }

    private void UpdateDrawing()
    {
        if (ghostLine != null)
        {
            Vector3 currentPoint = GetMouseWorldPosition();

            // Çizimi devam ettir
            float distance = Vector3.Distance(lastPoint, currentPoint);
            if (distance > 0.1f) // Küçük mesafelerle gereksiz çizim yapılmasın
            {
                ghostLine.positionCount += 1; // Yeni bir nokta ekle
                ghostLine.SetPosition(ghostLine.positionCount - 1, currentPoint); // Son pozisyonu güncelle

                lastPoint = currentPoint; // Son nokta olarak güncelle
            }
        }
    }

    private void FinishDrawing()
    {
        if (ghostLine != null)
        {
            // Çizgi oluştur
            GameObject newLine = Instantiate(linePrefab);
            LineRenderer lineRenderer = newLine.GetComponent<LineRenderer>();

            // LineRenderer'ı güncelle
            lineRenderer.positionCount = ghostLine.positionCount;
            for (int i = 0; i < ghostLine.positionCount; i++)
            {
                lineRenderer.SetPosition(i, ghostLine.GetPosition(i));
            }

            // Çizginin toplam uzunluğunu hesapla
            float totalLength = 0f;
            for (int i = 1; i < ghostLine.positionCount; i++)
            {
                totalLength += Vector3.Distance(ghostLine.GetPosition(i - 1), ghostLine.GetPosition(i));
            }

            // Uzunluğa bağlı olarak enerji azalt
            energy -= totalLength * energyCostPerUnit;

            // Enerji bitmişse, çizimi bitir
            if (energy <= 0)
            {
                energy = 0;
            }

            // Ghost çizgiyi yok et
            Destroy(ghostLine.gameObject);
            ghostLine = null;
            isDrawing = false;
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
