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
    public bool missionComplete; // Savoir si une mission est complète
    [Space]
    public bool restartOnNextBall; // Si on perd la balle, d'une façon ou d'une autre, on veut recommencer cette mission pour la prochaine balle
    public bool stopOnBallEnd; // Si la balle s'arrête nous voulons soit la faire continuer ou arrêter complètement le progrès de la mission
    public bool resetOnComplete; // Lorsque la mission est complète, on veut la réinitialiser pour la faire répéter plus tard
    public bool canTriggerMultiball; 
    [Space]
    public float timeToComplete; // Mission basé sur le temps (mission qui dure 10 secondes et s'arrête)
    [Space]
    public int score; // Nombre de points que nous obtenons pour la mission (faculatif pour certaine mission)
    public int quantiteToComplete; // Nombre d'actions pour compléter la mission (Ex: frapper le bumper 3x pour compléter la mission)
    public int actuelQuantite; // Quantité d'actions complétées actuellement

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

            // Vérifier si la mission est complète
            VérifierMissionComplète();
        }
    }

    void VérifierMissionComplète()
    {
        if(actuelQuantite >= quantiteToComplete)
        {
            missionComplete = true;
            active = false;
            if(timeToComplete > 0)
            {
                // Arrêter minuteur
                MissionManager.instance.ArreterMinuteur();
            }

            if (canTriggerMultiball)
            {
                GameManagerVrai.instance.StartMultiBall();
            }

            //ScoreManager.instance.AddScore(score);

            ResetMission();
            Debug.Log("Mission Complète");
        }
        
    }

}
