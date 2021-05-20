using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuidéeMissile : MonoBehaviour
{
    [SerializeField]
    float sensibilitéRotation = 4f;

    [SerializeField]
    float speedMissile = 4f;

    [SerializeField]
    float sensibilitéGuidage = 50f;

    [SerializeField]
    float boostMontant = 10000f;

    [SerializeField]
    public GameObject rocket;

    [SerializeField]
    public GameObject barre;

    [SerializeField]
    public Canvas cv;

    List<GameObject> missile;
    GameObject canon;
    Slider slider;

    bool missileActif = false;
    float boostNb;

    void Start()
    {
        cv.enabled = false;
        canon = gameObject.GetComponent<GameObject>();
        missile = new List<GameObject>();
        slider = barre.GetComponent<Slider>();
        missile.Add(null);
    }

    private void Update()
    {
        //Création et préparation d'un nouveau missile
        if (missile[0] == null)
        {
            boostNb = boostMontant;
            missileActif = false;
            cv.enabled = false;
            missile[0] = InstancierMissile();
        }
        Rigidbody rb = missile[0].GetComponent<Rigidbody>();

        //Préparation de la barre de boost
        barre.transform.localScale = new Vector3(0, 0, 0);
        slider.maxValue = boostMontant;
        slider.value = boostNb;

        //Faire avancer le missile dans la bonne direction lorsqu'il est actif
        //et faire apparaître bar de boost
        if (missileActif)
        {
            rb.velocity = missile[0].transform.TransformDirection(Vector3.up * speedMissile);
            barre.transform.localScale = new Vector3(1, 1, 1);
        }

        //Commandes A, D et Espace
        if(Input.GetKey(KeyCode.A))
        {
            if(missileActif == false)
            {
                transform.Rotate(Vector3.right * sensibilitéRotation * Time.deltaTime);
                missile[0].transform.Rotate(Vector3.back * sensibilitéRotation * Time.deltaTime);
            }
            else
            {
                missile[0].transform.Rotate(Vector3.back * sensibilitéRotation * Time.deltaTime * sensibilitéGuidage);
            }
        }
        if(Input.GetKey(KeyCode.D))
        {
            if (missileActif == false)
            {
                transform.Rotate(Vector3.left * sensibilitéRotation * Time.deltaTime);
                missile[0].transform.Rotate(Vector3.forward * sensibilitéRotation * Time.deltaTime);
            }
            else
            {
                missile[0].transform.Rotate(Vector3.forward * sensibilitéRotation * Time.deltaTime * sensibilitéGuidage);
            }
        }
        if(Input.GetKey(KeyCode.Space))
        {
            if(missileActif == false)
            {
                missileActif = true;
                cv.enabled = true;
                rb.velocity = missile[0].transform.TransformDirection(Vector3.up * speedMissile);
                StartCoroutine(ActiverCollider(missile[0].GetComponent<CapsuleCollider>()));
            }
            else if(boostNb > 0)
            {
                rb.velocity = missile[0].transform.TransformDirection(Vector3.up * speedMissile * 2);
                boostNb--;
            }
        }
    }

    GameObject InstancierMissile()
    {
        //Créer et positionner le missile
        GameObject missile = Instantiate(rocket, transform.position, Quaternion.Euler(95, 0, 0));
        missile.transform.position = new Vector3(transform.position.x, transform.position.y + 0.04f, transform.position.z);
        missile.AddComponent<CollisionDestroy>();

        //Ajouter et régler le rigidbody
        Rigidbody r = missile.AddComponent<Rigidbody>();
        r.useGravity = false;

        //Ajouter et régler le collider et collisions
        missile.layer = 13;
        CapsuleCollider col = missile.AddComponent<CapsuleCollider>();
        col.radius = 0.5f;
        col.isTrigger = true;

        return missile;
    }

    IEnumerator ActiverCollider(Collider col)
    {
        yield return new WaitForSeconds(.5f);
        col.isTrigger = false;
    }
}
