using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text playerKillsText;
    public Text enemyKillsText;
    public Text timer;
    public GameObject gameoverScreen;
    public Text winText;

    public float time;

    void Start()
    {
        HideGameOver();
    }

    void Update()
    {
        if (!GameManager.Instance.isTimesUp && GameManager.Instance.win == 0)
        {
            UpdateTimer(GameManager.Instance.time);
            UpdateKills();
        }
        else
        {
            ShowGameOver(GameManager.Instance.win);
        }
    }

    public void UpdateKills()
    {
        playerKillsText.text = "Player Kills: " + GameManager.Instance.playerKills.ToString();
        enemyKillsText.text = "Enemy Kills: " + GameManager.Instance.enemyKills.ToString();
    }

    private void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void ShowGameOver(int win)
    {
        gameoverScreen.SetActive(true);

        if (win == 1)
        {
            winText.text = "Player Wins";
        }
        else if (win == 2)
        {
            winText.text = "AI Wins";
        }
        else if (win == 3)
        {
            winText.text = "Draw";
        }
    }

    public void HideGameOver()
    {
        gameoverScreen.SetActive(false);
    }

    public void CallReloadScene()
    {
        GameManager.Instance.ReloadLevel();
    }

    public void CallMainMenuScene()
    {
        GameManager.Instance.LoadMainMenu();
    }
}
