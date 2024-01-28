using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public List<int> playerVicotries = new List<int>();

    public enum AnimStates { idle, open, close};
    AnimStates state;

    //GameManager.Instance.gamePaused
    public bool gamePaused = false;
    public bool minigameFinished;

    public int gamesUnitlEnd;
    public int amountOfMinigames;

    public GameObject gameMenu;
    
    public UnityEvent minigameStarted;
    public UnityEvent activateMinigameEvent;
    public UnityEvent minigameEnded;

    private int selectedMinigame;
    private int previousMinigameSelected = -1;

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        state = AnimStates.idle;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (state)
            {
                case AnimStates.idle:
                    SelectMinigame();
                    GetComponent<Animator>().SetTrigger("OpenCurtain");
                    break; 
                case AnimStates.open:
                    GetComponent<Animator>().SetTrigger("CloseCurtain");
                    break; 
                case AnimStates.close:
                    MenuInteraction();
                    GetComponent<Animator>().SetTrigger("ReturnToIdle");
                    break;
            }
            StateChanger();
        }
    }

    public void StateChanger()
    {
        switch(state)
        {
            case AnimStates.idle:
                state = AnimStates.open;
                break; 
            case AnimStates.open:
                state = AnimStates.close;
                break;
            case AnimStates.close:
                state = AnimStates.idle;
                break;
        }
    }

    public void SelectMinigame()
    {
        switch (1/*SelectRandomMinigame()*/) 
        {
            case 0:
                //Debug.Log(0);
                SceneManager.LoadScene("MazeMinigame");
                break; 
            case 1:
                //Debug.Log(1);
                SceneManager.LoadScene("SnailMinigame");
                break; 
            case 2:
                //Debug.Log(2);
                SceneManager.LoadScene("CatMinigame");
                break;
        }
    }

    int SelectRandomMinigame()
    {
        do
        {
            selectedMinigame = Random.Range(0, amountOfMinigames);

        } while (selectedMinigame == previousMinigameSelected);
        previousMinigameSelected = selectedMinigame;
        return selectedMinigame;
    }

    public void MenuInteraction()
    {

    }

    public void ShowCredits()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void PauseGame()
    {
        if (Time.timeScale == 1)
        {
            gamePaused = true;
            Time.timeScale = 0;
        }
        else if (Time.timeScale == 0)
        {
            gamePaused = false;
            Time.timeScale = 1;
        }
    }

    public void OpenCurtainAnimations()
    {
        GetComponent<Animator>().SetTrigger("OpenCurtain");
    } 

    public void ActivateMenu()
    {
        if(gameMenu != null)
        {
            gameMenu.SetActive(true);
        }
    }

    public void DeactivateMenu()
    {
        if (gameMenu != null)
        {
            gameMenu.SetActive(false);
        }
    }

    public void ReturnToIdle()
    {
        GetComponent<Animator>().SetTrigger("ReturnToIdle");
    }

    public void CloseCurtainAnimations()
    {
        GetComponent<Animator>().SetTrigger("CloseCurtain");
        for (int i = 0; i < 2; i++)
        {
            Debug.Log(GameManager.Instance.playerVicotries[i]);
        }
    }

    public IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2.0f);
        SelectMinigame();
    }

}
