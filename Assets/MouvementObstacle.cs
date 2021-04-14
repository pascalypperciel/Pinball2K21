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

    Vector3 positionDepart;

    float mouvementMaximal = 0.225f;

    [SerializeField]
    private float speed;
    private void Bouger2d(KeyCode[] mouvementKeys, Vector3[] deplacements)
    {
        
            for (int i = 0; i < mouvementKeys.Length; ++i)
            {
                if (Input.GetKey(mouvementKeys[i]))
                {
                   if (MouvementAcceptable(deplacements[i]))
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
        positionDepart = transform.position;
    }
    private bool MouvementAcceptable(Vector3 mouvement)
    {
        bool accepte = true;
        if(mouvement.x < 0)
        {
            if (transform.position.x < positionDepart.x - mouvementMaximal)
                accepte = false;
        }
        else
        {
            if (transform.position.x > positionDepart.x + mouvementMaximal)
                accepte = false;
        }
        return accepte;
    }
}
