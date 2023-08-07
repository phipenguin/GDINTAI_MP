using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int playerKills = 0;
    public int enemyKills = 0;
    public int playerBases = 3;
    public int enemyBases = 3;

    public int win = 0;

    public float time = 120;
    public bool isTimesUp = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        if (time > 0)
        {
            time -= Time.fixedDeltaTime;
        }
        else
        {
            time = 0;
            isTimesUp = true;
        }
    }

    public void UpdateValues(GameObject gameObject)
    {
        Debug.Log(gameObject.tag);

        if (gameObject.tag == "Player")
            enemyKills += 1;
        if (gameObject.tag == "Enemy")
            playerKills += 1;
        if (gameObject.tag == "PlayerBase")
            playerBases -= 1;
        if (gameObject.tag == "EnemyBase")
            enemyBases -= 1;

        GameOver();
    }

    public void ResetValues()
    {
        playerKills = 0;
        playerBases = 3;
        enemyKills = 0;
        enemyBases = 3;
        win = 0;

        time = 120;
        isTimesUp = false;

        Time.timeScale = 1;
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ReloadLevel()
    {
        ResetValues();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        if (!isTimesUp)
        {
            if (enemyBases <= 0)
            {
                Time.timeScale = 0;
                win = 1;
            }
            else if (playerBases <= 0)
            {
                Time.timeScale = 0;
                win = 2;
            }
        }
        else
        {
            Time.timeScale = 0;

            if (playerBases > enemyBases)
            {
                win = 1;
            }
            else if (playerBases < enemyBases)
            {
                win = 2;
            }
            else if (playerBases == enemyBases)
            {
                if (playerKills > enemyKills)
                {
                    win = 1;
                }
                else if (playerKills < enemyKills)
                {
                    win = 2;
                }
                else
                {
                    win = 3;
                }
            }
        }
    }
}