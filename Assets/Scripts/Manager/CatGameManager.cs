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
    private bool canSpawnCats = true;

    void Start()
    {
        StartCoroutine(SpawnCat());
    }

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
            //PauseGame();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DisableInstructionsActivateCourtains();
        }
    }

    private void EndGame()
    {
        int player1Points = GameObject.FindWithTag("Player1").GetComponent<PlayersMovements>().catsInLight;
        int player2Points = GameObject.FindWithTag("Player2").GetComponent<PlayersMovements>().catsInLight;

        if (player1Points > player2Points)
        {
            GameManager.Instance.playerVicotries[0]++;
            winnerPlayerText.text = "PLAYER 1 WON THE GAME!";
        }
        else if (player2Points > player1Points)
        {
            GameManager.Instance.playerVicotries[1]++;
            winnerPlayerText.text = "PLAYER 2 WON THE GAME!";
        }
        else
        {
            winnerPlayerText.text = "IT'S A TIE!";
        }

        canSpawnCats = false;
        GameManager.Instance.gamePaused = true;
        victoryScreen.SetActive(true);

        if (CatMinigameManager.Instance != null)
        {
            CatMinigameManager.Instance.StopMinigame();
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

    IEnumerator SpawnCat()
    {
        while (canSpawnCats)
        {
            yield return new WaitForSeconds(1.0f);
        }
    }
}
