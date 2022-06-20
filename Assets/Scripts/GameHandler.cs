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

    void Awake()
    {
        sceneSetupParameters();
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
        sceneSetupParameters();
    }

    public void ExitButtonOnClick()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void sceneSetupParameters()
    {
        PlayerController.ManaPoints = 0;
        GameOver = false;
        MenuPanel.SetActive(false);
        GameTime = 2f;
        GameSpeed = GameTime;
        Player.SetActive(true);
        Player.transform.position = new Vector3(-5, -3, 0);
        PlayerController.resetLifePoints = true;
        ScoreText.text = "Punkty: 0";
        destroySceneObjects();
    }

    private void destroySceneObjects()
    {
        GameObject[] platformsToDelete = GameObject.FindGameObjectsWithTag("Platform");
        GameObject[] trapsToDelete = GameObject.FindGameObjectsWithTag("Trap");
        GameObject[] manaPotionsToDelete = GameObject.FindGameObjectsWithTag("ManaPotion");
        GameObject[] lifePointsToDelete = GameObject.FindGameObjectsWithTag("LifePoint");

        foreach (GameObject gameObject in platformsToDelete) { Destroy(gameObject);}
        foreach (GameObject gameObject in trapsToDelete) { Destroy(gameObject); }
        foreach (GameObject gameObject in manaPotionsToDelete) { Destroy(gameObject); }
        foreach (GameObject gameObject in lifePointsToDelete) { Destroy(gameObject); }
    }

}
