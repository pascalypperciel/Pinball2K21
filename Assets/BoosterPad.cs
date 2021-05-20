using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterPad : MonoBehaviour
{
    [SerializeField]
    float Speed;

    //formule de l'acc�l�ration en physique: Acc�l�ration = (velocit� finale - velocit� initiale) / temps �coul�
    Vector3 v�locit�I;
    Vector3 v�locit�F;
    float temps = 1; //= 1 car on veut que le boost soit instantann�

    private void OnTriggerEnter(Collider other)
    {
        v�locit�I = other.GetComponent<Rigidbody>().velocity;
        v�locit�F = v�locit�I * Speed;

        other.GetComponent<Rigidbody>().velocity = -transform.forward * Mathf.Abs((v�locit�F.z - v�locit�I.z) / temps);
        //Le Mathf.Abs et le -transform.forward sont juste pour s'assurer que le balle acc�l�re toujours vers le haut.
    }
}
