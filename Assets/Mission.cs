using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mission
{
    public int missionId; //Identifiaction de chaque mission
    public string description; // description de la mission

    [Space]
    public bool active; // Savoir si une mission est active
    public bool permanentActive; // toujours active
    public bool missionComplete; // Savoir si une mission est compl�te
    [Space]
    public bool restartOnNextBall; // Si on perd la balle, d'une fa�on ou d'une autre, on veut recommencer cette mission pour la prochaine balle
    public bool stopOnBallEnd; // Si la balle s'arr�te nous voulons soit la faire continuer ou arr�ter compl�tement le progr�s de la mission
    public bool resetOnComplete; // Lorsque la mission est compl�te, on veut la r�initialiser pour la faire r�p�ter plus tard
    public bool canTriggerMultiball; 
    [Space]
    public float timeToComplete; // Mission bas� sur le temps (mission qui dure 10 secondes et s'arr�te)
    [Space]
    public int score; // Nombre de points que nous obtenons pour la mission (faculatif pour certaine mission)
    public int quantiteToComplete; // Nombre d'actions pour compl�ter la mission (Ex: frapper le bumper 3x pour compl�ter la mission)
    public int actuelQuantite; // Quantit� d'actions compl�t�es actuellement

    public void ResetMission()
    {
        if (resetOnComplete)
        {
            active = false;
            missionComplete = false;
            actuelQuantite = 0;
        }
    }

    public void DeactiverMission()
    {
        if (permanentActive)
        {
            active = true;
        }
        else
        {
            active = false;
        }

        actuelQuantite = 0;
    }

    public void UpdateMission()
    {
        if(active && !missionComplete)
        {
            actuelQuantite++;

            // V�rifier si la mission est compl�te
            V�rifierMissionCompl�te();
        }
    }

    void V�rifierMissionCompl�te()
    {
        if(actuelQuantite >= quantiteToComplete)
        {
            missionComplete = true;
            active = false;
            if(timeToComplete > 0)
            {
                // Arr�ter minuteur
                MissionManager.instance.ArreterMinuteur();
            }

            if (canTriggerMultiball)
            {
                GameManagerVrai.instance.StartMultiBall();
            }

            //ScoreManager.instance.AddScore(score);

            ResetMission();
            Debug.Log("Mission Compl�te");
        }
        
    }

}
