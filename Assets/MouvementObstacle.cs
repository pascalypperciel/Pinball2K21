using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementObstacle : MonoBehaviour
{
    [SerializeField]
    private KeyCode[] mouvementKeys;

    [SerializeField]
    private Vector3 mouvement1;

    [SerializeField]
    private Vector3 mouvement2;

    Vector3[] deplacements;

    [SerializeField]
    private KeyCode identification;

    [SerializeField]
    private float speed;
    private void Bouger2d(KeyCode[] mouvementKeys, Vector3[] deplacements)
    {
        if(Input.GetKeyDown(identification))
        {
            for (int i = 0; i < mouvementKeys.Length; ++i)
            {
                if (Input.GetKey(mouvementKeys[i]))
                    transform.Translate(deplacements[i] * speed);
            }
        }
        
    }
    private void Update()
    {
        Bouger2d(mouvementKeys, deplacements);
        
    }
    private void Start()
    {
        deplacements = new Vector3[2] {mouvement1,mouvement2 };
    }
}
