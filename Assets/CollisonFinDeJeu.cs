using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisonBalle : MonoBehaviour
{
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
    }

    
}
