using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
     public Camera mainCamera; // Takip edilecek kamera
    public float backgroundHeight; // Arka planın yüksekliği

    private void Update()
    {
        // Kamera pozisyonunu al
        Vector3 cameraPosition = mainCamera.transform.position;

        // Eğer arka plan kameranın altına düştüyse yukarı taşı
        if (transform.position.y + backgroundHeight / 2 < cameraPosition.y)
        {
            RepositionBackground(1); // Yukarı taşı
        }
        // Eğer arka plan kameranın üstüne çıktıysa aşağı taşı
        else if (transform.position.y - backgroundHeight / 2 > cameraPosition.y)
        {
            RepositionBackground(-1); // Aşağı taşı
        }
    }

    private void RepositionBackground(int direction)
    {
        // Arka planı yukarı veya aşağı taşı
        float offset = backgroundHeight * direction;
        transform.position += new Vector3(0, offset, 0);
    }
}
