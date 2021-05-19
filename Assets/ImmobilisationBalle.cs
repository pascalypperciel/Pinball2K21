using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmobilisationBalle : MonoBehaviour
{
    [SerializeField]
    public GameObject greenSlime;

    [SerializeField]
    float speed;

    List<GameObject> slime;

    Vector3 posInitiale = new Vector3(0, 1.5f, 0);
    int compteur = -1;

    void Start()
    {
        slime = new List<GameObject>();
        slime.Add(null);
        slime.Add(null);
    }

    void Update()
    {
        //Changer compteur
        if(compteur > 0)
        {
            --compteur;
        }

        //Création et préparation d'un nouveau slime
        if (slime[0] == null)
        {
            slime[0] = InstancierSlime(posInitiale, true);
            slime[1] = (InstancierGuide());
        }
        Rigidbody rb = slime[0].GetComponent<Rigidbody>();

        //Commandes
        if (Input.GetKey(KeyCode.A))
        {
            slime[0].transform.Translate(Vector3.right * speed * Time.deltaTime);
            slime[1].transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            slime[0].transform.Translate(Vector3.left * speed * Time.deltaTime);
            slime[1].transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            slime[0].transform.Translate(Vector3.back * speed * Time.deltaTime);
            slime[1].transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            slime[0].transform.Translate(Vector3.forward * speed * Time.deltaTime);
            slime[1].transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(compteur <= 0)
            {
                InstancierSlime(slime[0].transform.position, false);
                compteur = 1500;
            }
        }
    }

    GameObject InstancierSlime(Vector3 position, bool guide)
    {
        //Créer et positionner la slime
        GameObject slime = Instantiate(greenSlime);
        slime.transform.position = position;
        slime.AddComponent<MeshRenderer>();

        //Changer Rigidbody, Collider et Opacité au besoin
        if (!guide)
        {
            //Ajouter et régler le rigidbody
            Rigidbody r = slime.AddComponent<Rigidbody>();
            r.useGravity = true;

            //Ajouter et régler le collider et collisions
            slime.layer = 10;
            BoxCollider col = slime.GetComponent<BoxCollider>();

            //Ajouter script
            slime.AddComponent<ImmobilisationSlime>();
        }
        else
        {
            slime.name = "GuideSlime";
        }

        return slime;
    }

    GameObject InstancierGuide()
    {
        //Créer et positionner le missile
        GameObject tige = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        CapsuleCollider col = tige.GetComponent<CapsuleCollider>();
        Destroy(col);
        tige.transform.position = new Vector3(0, 0.5f, 0);
        tige.transform.localScale = new Vector3(0.01f, 0.01f, 2);
        tige.transform.localRotation = Quaternion.Euler(90, 0, 0);

        tige.name = "GuideTige";

        return tige;
    }
}
