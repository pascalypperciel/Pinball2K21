using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public static MissionManager instance;

    bool missionTempsActive;
    private void Awake()
    {
        instance = this;
    }

    public List<Mission> missionList = new List<Mission>();

    public void StartMission(int ID)
    {
        foreach (Mission mission in missionList)
        {
            if (mission.missionId == ID)
            {
                // mission bas� sur le temps
                if(!mission.missionComplete && !mission.active && mission.timeToComplete > 0 && !missionTempsActive)
                {
                    mission.active = true;
                    missionTempsActive = true;

                    // d�marrer minuteur
                    StartCoroutine(Minuteur(mission.timeToComplete, ID));
                }
                // mission pas bas� sur le temps
                else if (!mission.missionComplete && !mission.active && mission.timeToComplete <= 0)
                {
                    mission.active = true;
                }
            }
        }
    }

    IEnumerator Minuteur(float t, int ID)
    {
        float tempTime = t;
        while(missionTempsActive && tempTime > 0)
        {
            yield return new WaitForSeconds(1f);
            tempTime -= 1;
            Debug.Log(tempTime);

        }
        // D�activer mission
        missionTempsActive = false;
        DeactiverMission(ID);
    }

    void DeactiverMission(int ID)
    {
        missionList.Find(m => m.missionId == ID).DeactiverMission();
        if (missionTempsActive)
        {
            missionTempsActive = false;
        }
        Debug.Log("Mission est termin�");
    }

    public void UpdateMission(int ID)
    {
        missionList.Find(m => m.missionId == ID).UpdateMission();
    }

    public void ArreterMinuteur()
    {
        missionTempsActive = false;
    }
}
