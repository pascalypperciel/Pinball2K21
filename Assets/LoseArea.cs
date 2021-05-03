using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseArea : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        Destroy(col.gameObject);

        MissionManager.instance.ResetAllMissions();
        GameManagerVrai.instance.UpdateBallsOnPlayfield(-1);
        GameManagerVrai.instance.CreateNewBall();
    }
}
