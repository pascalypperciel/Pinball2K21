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
        if(other.GetContact(0).thisCollider.gameObject.name == "") // Doit trouver quoi est le nom object pour detruir
        {
            BalleDetruit();
        }
        else if(other.GetContact(0).thisCollider.gameObject.name == "") // Doit trouver quoi est le nom object pour ajouter
        {
            BalleAjouter();
        }
    }
    public void BalleDetruit()
    {
        Destroy(gameObject);
        gameManager.EnleverBalle();
    }
    public void BalleAjouter()
    {
        gameManager.AjouterBalle();
        spawner.Spawn();
    }

}
