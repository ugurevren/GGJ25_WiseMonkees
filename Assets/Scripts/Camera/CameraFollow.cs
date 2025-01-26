using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's Transform
    public Transform targetLocation; // Reference to the assigned location Transform
    public float moveSpeed = 5f; // Speed at which the camera moves to the target location
    private bool isFollowingPlayer = true; // Flag to track if the camera is following the player
    private bool isPlayerFalling = false; // Flag to track if the player is falling
    private float previousPlayerY; // To store the previous Y position of the player

    void Start()
    {
        if (player != null)
        {
            previousPlayerY = player.position.y;
        }
    }

    void LateUpdate()
    {
        if (player == null) return;

        if (isFollowingPlayer)
        {
            if (IsPlayerOutOfScreen())
            {
                isFollowingPlayer = false;
            }
            else
            {
                if (isPlayerFalling)
                {
                    if (player.position.y > previousPlayerY)
                    {
                        isPlayerFalling = false;
                    }
                }
                else
                {
                    if (player.position.y < previousPlayerY)
                    {
                        isPlayerFalling = true;
                    }
                    FollowPlayer();
                }
            }
        }
        else
        {
            MoveToTargetLocation();
        }

        previousPlayerY = player.position.y;
    }

    void FollowPlayer()
    {
        transform.position = new Vector3(0, player.position.y, transform.position.z);
    }

    bool IsPlayerOutOfScreen()
    {
        Vector3 playerScreenPosition = Camera.main.WorldToViewportPoint(player.position);
        return playerScreenPosition.y < 0 || playerScreenPosition.y > 1;
    }

    void MoveToTargetLocation()
    {
        if (targetLocation != null)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(0, 0, -10), moveSpeed * Time.deltaTime);
        }
    }
}