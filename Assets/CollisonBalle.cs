using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisonFinDeJeu : MonoBehaviour
{
    private GameManager gameManager;
    private Spawner spawner;
    void Awake()
    {
        gameManager = GetComponent<GameManager>();
        spawner = GetComponent<Spawner>();
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision other)
    {
        
        if(other.GetContact(0).thisCollider.gameObject.name == "Balle") // Doit trouver quoi est le nom object pour ajouter
        {
            BalleAjouter();
        }
    }
    
    public void BalleAjouter()
    {
        gameManager.AjouterBalle();
        spawner.Spawn();
    }
    private void OnTriggerEnter(Collider other)
    {
        BalleAjouter();
    }
}
