using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerVrai : MonoBehaviour
{
    public static GameManagerVrai instance;

    int startBallAmount = 3; // nombre de balles au début du jeu
    int currentBallAmount; // nombre de balles actuellement
    int activeBallsOnPlayField;

    public GameObject ballPrefab;
    public Transform spawnPoint; // endroit où la balle spawn
    public Transform multiSpawnPoint; // endroit où les multiballes spawn

    bool gameStarted; // savoir si le jeu a commencé
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        ResetGame();
    }

    public void ResetGame()
    {
        currentBallAmount = startBallAmount;
        UiManager.instance.UpdateBallText(currentBallAmount);
        UiManager.instance.ShowGameOverPanel(false);
        ScoreManager.instance.ResetScore();
        MissionManager.instance.ResetAllMissions();
        CreateNewBall();
    }

    public void CreateNewBall()
    {
        if (activeBallsOnPlayField == 0 && currentBallAmount > 0)
        {
            Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
            UpdateBallsOnPlayfield(+1);
            currentBallAmount--;
            UiManager.instance.UpdateBallText(currentBallAmount);
        }
        else
        {
            // lost game function
            Debug.Log("GAME OVER");
            UiManager.instance.ShowGameOverPanel(true);
        }
    }

    public void StartMultiBall()
    {
        StartCoroutine(Multiball());
    }

    public void UpdateBallsOnPlayfield(int amount)
    {
        activeBallsOnPlayField += amount;
    }

    IEnumerator Multiball()
    {
        int amount = 3;
        while(amount > 0)
        {
            Instantiate(ballPrefab, multiSpawnPoint.position, Quaternion.identity);
            UpdateBallsOnPlayfield(+1);
            amount--;
            yield return new WaitForSeconds(1f);
        }

    }
}
