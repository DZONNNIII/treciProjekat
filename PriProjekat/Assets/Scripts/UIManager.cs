using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject gameOverPanel;
    public GameObject continuePanel;

    public TMP_Text livesText;
    public TMP_Text scoreText;
    public TMP_Text gameOverText;

    void ShowPanel(GameObject panel)
    {
        startPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        continuePanel.SetActive(false);

        if (panel != null)
        {
            panel.SetActive(true);
        }
    }

    public void SetLives(int n)
    {
        livesText.text = "Lives: " + n;
    }

    public void SetScore(int n)
    {
        scoreText.text = "Score: " + n;
    }

    public void StartGame()
    {
        ShowPanel(null);
    }

    public void ContinueGame()
    {
        ShowPanel(null);
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void Reset()
    {
        ShowPanel(startPanel);
    }

    public void Pause()
    {
        ShowPanel(continuePanel);
    }

    public void GameOver(int n)
    {
        gameOverText.text = "Your score is: " + n;
        ShowPanel(gameOverPanel);
    }

    void Start()
    {
        Reset();
    }


    void Update()
    {

    }
}
