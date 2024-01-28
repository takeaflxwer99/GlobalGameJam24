using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CatGameManager : MonoBehaviour
{
    public GameObject instructions;
    public GameObject pauseMenu;
    public GameObject victoryScreen;
    public TextMeshProUGUI winnerPlayerText;

    private float gameTime = 25.0f;
    private bool timeEnded = false;
    public void DisableInstructionsActivateCourtains()
    {
        victoryScreen.SetActive(false);
        instructions.SetActive(false);
        GameManager.Instance.OpenCurtainAnimations();

    }

    private void Update()
    {
        if (!timeEnded)
        {
            gameTime -= Time.deltaTime;
            if (gameTime <= 0)
            {
                timeEnded = true;
                EndGame();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DisableInstructionsActivateCourtains();
        }

    }

    public void PauseGame()
    {
        if (GameManager.Instance.PauseGame())
        {
            pauseMenu.SetActive(false);
        }
        else
        {
            pauseMenu.SetActive(true);
        }
    }

    public void QuitGame()
    {
        GameManager.Instance.QuitGame();
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player1" && !playerCrossedTheLine)
    //    {
    //        victoryScreen.SetActive(true);
    //        playerCrossedTheLine = true;
    //        GameManager.Instance.gamePaused = true;
    //        GameManager.Instance.playerVicotries[0] = GameManager.Instance.playerVicotries[0] + 1;
    //        winnerPlayerText.text = "PLAYER 1 WON THE RACE!!!";
    //    }
    //    else if (collision.tag == "Player2" && !playerCrossedTheLine)
    //    {
    //        victoryScreen.SetActive(true);
    //        playerCrossedTheLine = true;
    //        GameManager.Instance.gamePaused = true;
    //        GameManager.Instance.playerVicotries[1] = GameManager.Instance.playerVicotries[1] + 1;
    //        winnerPlayerText.text = "PLAYER 2 WON THE RACE!!!";

    //    }
    }
}
