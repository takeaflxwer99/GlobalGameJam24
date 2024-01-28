using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public List<int> playerVicotries = new List<int>();

    //GameManager.Instance.gamePaused
    public bool gamePaused = false;
    public bool minigameFinished;

    public int gamesUnitlEnd;
    public int amountOfMinigames;

    public GameObject gameMenu;
    
    public UnityEvent minigameStarted;
    public UnityEvent activateMinigameEvent;

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

        //DontDestroyOnLoad(this.gameObject);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OpenCurtainAnimations();
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

    public void ShowCredits()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
    public bool PauseGame()
    {
        if (gamePaused)
        {
            gamePaused = true;
            Time.timeScale = 0;
        }
        else
        {
            gamePaused = false;
            Time.timeScale = 1;
        }
        return gamePaused;
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
    }

    public IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2.0f);
        SelectMinigame();
    }

}
