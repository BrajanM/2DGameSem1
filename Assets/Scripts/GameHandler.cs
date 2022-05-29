using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    // LEVEL SETTINGS
    public static float GameSpeed;
    public float GameTime = 1f;
    public static bool GameOver;
    public GameObject Player;

    // UI ELEMENTS
    public Text ScoreText;
    public GameObject MenuPanel;


    // LOCAL VARIABLES
    private int gameScore = 0;

    void Start()
    {
        GameTime = 2f;
        GameSpeed = GameTime;
        GameOver = false;
        MenuPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameOver)
        {
            GameSpeed = GameTime;
            gameScore = PlayerController.ManaPoints;
            updateScoreTextbox();
        }
        else
        {
            Player.SetActive(false);
            MenuPanel.SetActive(true);
            GameSpeed = 0;
        }
    }

    private void updateScoreTextbox()
    {
        ScoreText.text = "Punkty: " + gameScore;
    }

    public void ReplayButtonOnClick()
    {
        SceneManager.LoadScene("Level1");
    }

    public void ExitButtonOnClick()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
