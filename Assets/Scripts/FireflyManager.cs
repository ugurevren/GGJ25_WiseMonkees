using System.Collections.Generic;
using UnityEngine;

public class FireflyManager : MonoBehaviour
{
    [Header("Firefly Settings")]
    public GameObject fireflyPrefab; // Kullanılacak sprite prefab
    public int maxFireflies = 20; // Aynı anda ekranda olacak maksimum firefly sayısı
    public float movementSpeed = 1f; // Hareket hızı
    public Vector2 movementRange = new Vector2(0.5f, 1.5f); // Rastgele hareket aralığı

    private Camera mainCamera;
    private List<GameObject> fireflies = new List<GameObject>();

    void Start()
    {
        mainCamera = Camera.main;

        // Başlangıçta birkaç firefly oluştur
        for (int i = 0; i < maxFireflies / 2; i++)
        {
            CreateFirefly();
        }
    }

    void Update()
    {
        // Her frame firefly'ları kontrol et
        ManageFireflies();

        // Firefly'ları rastgele hareket ettir
        MoveFireflies();
    }

    void ManageFireflies()
    {
        for (int i = fireflies.Count - 1; i >= 0; i--)
        {
            if (!IsInView(fireflies[i].transform.position))
            {
                Destroy(fireflies[i]);
                fireflies.RemoveAt(i);
            }
        }

        // Maksimum firefly sayısına ulaşmadıysak yeni firefly oluştur
        while (fireflies.Count < maxFireflies)
        {
            CreateFirefly();
        }
    }

    void MoveFireflies()
    {
        foreach (GameObject firefly in fireflies)
        {
            Vector2 randomMovement = new Vector2(
                Random.Range(-movementRange.x, movementRange.x),
                Random.Range(-movementRange.y, movementRange.y)
            );
            firefly.transform.Translate(randomMovement * movementSpeed * Time.deltaTime);
        }
    }

    void CreateFirefly()
    {
        Vector3 randomPosition = GetRandomPositionInView();
        GameObject newFirefly = Instantiate(fireflyPrefab, randomPosition, Quaternion.identity);
        fireflies.Add(newFirefly);
    }

    Vector3 GetRandomPositionInView()
    {
        float minX = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane)).x;
        float maxX = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, mainCamera.nearClipPlane)).x;
        float minY = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane)).y;
        float maxY = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, mainCamera.nearClipPlane)).y;

        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        return new Vector3(randomX, randomY, 0);
    }

    bool IsInView(Vector3 position)
    {
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(position);
        return viewportPosition.x >= 0 && viewportPosition.x <= 1 &&
               viewportPosition.y >= 0 && viewportPosition.y <= 1;
    }
}
