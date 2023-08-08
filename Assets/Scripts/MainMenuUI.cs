using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject goBackPanel;

    public void CallLoad1()
    {
        GameManager.Instance.LoadLevel1();
    }

    public void CallLoad2()
    {
        GameManager.Instance.LoadLevel2();
    }

    public void CallLoad3()
    {
        GameManager.Instance.LoadLevel3();
    }

    public void CallQuit()
    {
        GameManager.Instance.QuitGame();
    }

    public void ShowStartMenu()
    {
        startMenu.SetActive(true);
        goBackPanel.SetActive(true);
    }

    public void HideStartMenu()
    {
        startMenu.SetActive(false);
        goBackPanel.SetActive(false);
    }
}