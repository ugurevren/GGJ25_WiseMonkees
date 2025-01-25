using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's Transform
    public Transform targetLocation; // Reference to the assigned location Transform
    private bool isPlayerOutOfBounds = false;

    void LateUpdate()
    {
        if (isPlayerOutOfBounds)
        {
            MoveToTargetLocation();
        }
        else if (player != null)
        {
            if (IsPlayerOutOfScreen())
            {
                isPlayerOutOfBounds = true;
            }
            else
            {
                FollowPlayer();
            }
        }
    }

    void FollowPlayer()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }

    bool IsPlayerOutOfScreen()
    {
        Vector3 playerScreenPosition = Camera.main.WorldToViewportPoint(player.position);
        return playerScreenPosition.x < 0 || playerScreenPosition.x > 1 || playerScreenPosition.y < 0 || playerScreenPosition.y > 1;
    }

    void MoveToTargetLocation()
    {
        if (targetLocation != null)
        {
            transform.position = new Vector3(targetLocation.position.x, targetLocation.position.y, transform.position.z);
        }
    }
}