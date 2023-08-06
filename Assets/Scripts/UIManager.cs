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

    public float time;

    private void Awake()
    {
        
    }

    void FixedUpdate()
    {
        if (time > 0)
        {
            time -= Time.fixedDeltaTime;
            UpdateTimer(time);
        }
        else
        {
            time = 0;
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
}
