using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDestroy : MonoBehaviour
{
    GameObject expl;
    ParticleSystem part;
    private void Awake()
    {
        expl = (GameObject)Resources.Load("SmallExplosionEffect");
        part = expl.GetComponent<ParticleSystem>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        if (collision.gameObject.layer == 7)
        {
            GameObject effet = Instantiate(expl, transform.position, Quaternion.identity);
            effet.transform.position += new Vector3(0, 0.5f, 0);
            effet.AddComponent<KillEffect>();
            Destroy(collision.gameObject);
        }
    }
}
