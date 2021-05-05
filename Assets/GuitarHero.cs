using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuitarHero : MonoBehaviour
{
    public Sprite pointGauche;
    public Sprite pointHaut;
    public Sprite pointBas;
    public Sprite pointDroite;

    public Canvas canvas;
    public int nbPoints = 10;

    private List<Image> points;
    void Start()
    {
        points = new List<Image>();
        canvas.enabled = true;
        for (int i = 0; i < nbPoints; ++i)
        {
            Invoke("CréerSéquence", i);
        }
        Invoke("LacherBoule", nbPoints);
    }

    void CréerSéquence()
    {
        int nombre = Random.Range(1, 4);
        switch (nombre)
        {
            case 1:
                points.Add(CréerPoint(pointGauche, 430));
                break;
            case 2:
                points.Add(CréerPoint(pointHaut, 570));
                break;
            case 3:
                points.Add(CréerPoint(pointBas, 710));
                break;
            case 4:
                points.Add(CréerPoint(pointDroite, 850));
                break;
        }
    }

    Image CréerPoint(Sprite couleur, int posX)
    {
        //Instanciation et ajustement de variables
        GameObject pointGO = new GameObject();
        pointGO.transform.SetParent(canvas.transform);
        Image point = pointGO.AddComponent<Image>();
        point.sprite = couleur;

        //Déplacer vers la bonne place initiale et mettre bonne taille
        point.GetComponent<RectTransform>().anchoredPosition = new Vector3(posX, 605, 0);
        point.GetComponent<RectTransform>().sizeDelta = new Vector2(140, 140);

        //Rigidbody et Collider
        CircleCollider2D col = pointGO.AddComponent<CircleCollider2D>();
        Rigidbody2D rb = pointGO.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.velocity = new Vector2(0, -1000);

        return point;
    }

    void LacherBoule()
    {
        bool détruite = true;
        for(int i = 0; i < nbPoints; ++i)
        {
            if (points[i] != null)
            {
                détruite = false;
            }
        }

        Rigidbody rb = GameObject.Find("Boule").GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.None;
        if (détruite)
        {
            rb.velocity = transform.forward * 2;
        }
    }
}
