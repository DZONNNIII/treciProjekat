using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        start,
        running,
        dead,
        gameOver
    }

    private int score;
    private int lives;
    private float initialPlayerSpeed = 10f;
    private float currentPlayerSpeed;
    public static GameState gameState;

    public RoadManager roadManager;
    public PlayerController playerController;
    public UIManager uiManager;
    public AudioScript audioScript;
    public AudioScript2 audioScript2;


    void Start()
    {
        ResetGame();
    }

    public void StartGame()
    {
        score = 0;
        lives = 3;
        currentPlayerSpeed = initialPlayerSpeed;
        gameState = GameState.running;
        uiManager.SetLives(lives);
        uiManager.SetScore(score);
        uiManager.StartGame();
        playerController.SetSpeed(currentPlayerSpeed);
        playerController.PlayAnimation();
    }

    public void ContinueGame()
    {
        gameState = GameState.running;
        playerController.Reset();
        uiManager.ContinueGame();
        playerController.PlayAnimation();
    }

    public void ResetGame()
    {
        gameState = GameState.start;
        roadManager.Reset();
        playerController.Reset();
        uiManager.Reset();
        playerController.StopAnimation();
    }

    private void GameOver()
    {
        gameState = GameState.gameOver;
        uiManager.GameOver(score);
        playerController.StopAnimation();
    }

    private void Dead()
    {
        gameState = GameState.dead;
        uiManager.Pause();
        playerController.StopAnimation();
    }

    public void DetectedObstacle()
    {
        lives--;
        if (lives == 0)
            GameOver();
        else
            Dead();
        uiManager.SetLives(lives);
        audioScript2.Obstacle();
    }

    public void DetectedBonus()
    {
        if (gameState == GameState.running)
        {
            score++;
            uiManager.SetScore(score);
            CheckAndIncreaseSpeed();
            audioScript.GetCoin();
        }
    }

    private void CheckAndIncreaseSpeed()
    {
        if (score >= 10 && score % 10 == 0)
        {
            int multiplier = score / 10;
            currentPlayerSpeed = initialPlayerSpeed + 10 * multiplier;
            playerController.SetSpeed(currentPlayerSpeed);
            Debug.Log("Increased speed to: " + currentPlayerSpeed);
        }


    }
}
