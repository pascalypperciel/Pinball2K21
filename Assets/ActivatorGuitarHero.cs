using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorGuitarHero : MonoBehaviour
{
    public KeyCode touche;
    bool aligné = false;
    GameObject point;

    void Update()
    {
        if(Input.GetKeyDown(touche) && aligné)
        {
            Destroy(point);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        aligné = true;
        point = collision.gameObject;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        aligné = false;
    }
}
