using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorGuitarHero : MonoBehaviour
{
    public KeyCode touche;
    bool align� = false;
    GameObject point;

    void Update()
    {
        if(Input.GetKeyDown(touche) && align�)
        {
            Destroy(point);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        align� = true;
        point = collision.gameObject;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        align� = false;
    }
}
