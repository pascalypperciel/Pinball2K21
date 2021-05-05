using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMissiles : MonoBehaviour
{
    [SerializeField]
    float speed = 4f;

    [SerializeField]
    float speedMissile = 4f;

    [SerializeField]
    public GameObject rocket;
    GameObject canon;

    void Start()
    {
        canon = gameObject.GetComponent<GameObject>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject missile = InstancierMissile();
            StartCoroutine(ActiverCollider(missile.GetComponent<CapsuleCollider>()));
        }
    }

    GameObject InstancierMissile()
    {
        //Créer et positionner le missile
        GameObject missile = Instantiate(rocket, transform.position, Quaternion.Euler(98, 0, 0));
        missile.transform.position = new Vector3(transform.position.x, transform.position.y + 0.04f, transform.position.z);
        missile.AddComponent<CollisionDestroy>();

        //Ajouter et régler le rigidbody
        Rigidbody r = missile.AddComponent<Rigidbody>();
        r.useGravity = false;
        r.velocity = transform.TransformDirection(Vector3.forward * speedMissile);

        //Ajouter et régler le collider et collisions
        missile.layer = 13;
        CapsuleCollider col = missile.AddComponent<CapsuleCollider>();
        col.radius = 0.5f;
        col.isTrigger = true;

        print("TESTING: " + missile.layer.ToString());

        return missile;
    }

    IEnumerator ActiverCollider(Collider col)
    {
        yield return new WaitForSeconds(.5f);
        col.isTrigger = false;
    }
}
