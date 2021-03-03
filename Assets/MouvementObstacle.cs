using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementObstacle : MonoBehaviour
{
    [SerializeField]
    private KeyCode[] mouvementKeys;

    static private Vector3[] deplacements = new[] { new Vector3(1, 0, 0), new Vector3(-1, 0, 0) };

    [SerializeField]
    private KeyCode identification;

    [SerializeField]
    private float speed;
    private void Bouger2d(KeyCode[] mouvementKeys, Vector3[] deplacements)
    {
        if(Input.GetMouseButton(0))
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
}
