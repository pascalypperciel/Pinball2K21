using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterPad : MonoBehaviour
{
    [SerializeField]
    float Speed;

    //formule de l'accélération en physique: Accélération = (velocité finale - velocité initiale) / temps écoulé
    Vector3 vélocitéI;
    Vector3 vélocitéF;
    float temps = 1; //= 1 car on veut que le boost soit instantanné

    private void OnTriggerEnter(Collider other)
    {
        vélocitéI = other.GetComponent<Rigidbody>().velocity;
        vélocitéF = vélocitéI * Speed;

        other.GetComponent<Rigidbody>().velocity = -transform.forward * Mathf.Abs((vélocitéF.z - vélocitéI.z) / temps);
        //Le Mathf.Abs et le -transform.forward sont juste pour s'assurer que le balle accélère toujours vers le haut.
    }
}
