using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    public bool isStarter; // trigger pour démarrer mission
    public bool isCounter; // compter missions en cours
    [Space]
    public int triggerID; // mission Id pour trigger

    void OnTriggerEnter(Collider col)
    {
        if (isStarter)
        {
            MissionManager.instance.StartMission(triggerID);
        }

        if (isCounter)
        {
            MissionManager.instance.UpdateMission(triggerID);
        }
    }
    void OnCollisoinEnter(Collision col)
    {
        if (isStarter)
        {
            MissionManager.instance.StartMission(triggerID);
        }

        if (isCounter)
        {
            MissionManager.instance.UpdateMission(triggerID);
        }
    }

     void OnDrawGizmos()
    {
        Gizmos.color = new Color32(0, 0, 255, 125);
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawCube(Vector3.zero, Vector3.one);
    }

}
