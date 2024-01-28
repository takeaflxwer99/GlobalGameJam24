using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class YayaGameManager : MonoBehaviour
{
    public GameObject instructions;
    public GameObject pauseMenu;
    public GameObject victoryScreen;
    public TextMeshProUGUI winnerPlayerText;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //PauseGame();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //DisableInstructionsActivateCourtains();
        }

    }

    //public void PauseGame()
    //{
    //    if (GameManager.Instance.PauseGame())
    //    {
    //        pauseMenu.SetActive(false);
    //    }
    //    else
    //    {
    //        pauseMenu.SetActive(true);
    //    }
    //}

    public void QuitGame()
    {
        GameManager.Instance.QuitGame();
    }
}
