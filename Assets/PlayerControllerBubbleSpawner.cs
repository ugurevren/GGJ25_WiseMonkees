using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Spawns bubbles, gets bigger when holding down the mouse button stops when released
public partial class PlayerController
{
    [SerializeField] private GameObject bubblePrefab;
    [SerializeField] private float currentBubbleSize = 0f;
    private Animator bubbleAnimator;
    private bool isBlowing = false;
    private void SpawnBubble()
    {
        
    }
    
}
