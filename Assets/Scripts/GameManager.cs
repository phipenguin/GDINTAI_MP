using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int playerKills = 0;
    public int enemyKills = 0;
    public int playerBases = 3;
    public int enemyBases = 3;

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
    }

    public void ResetValues()
    {
        playerKills = 0;
        playerBases = 3;
        enemyKills = 0;
        enemyBases = 3;
    }
}