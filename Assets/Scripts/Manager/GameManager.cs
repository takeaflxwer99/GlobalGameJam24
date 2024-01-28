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

    public bool gamePaused;
    public bool minigameFinished;

    public int gamesUnitlEnd;
    public int amountOfMinigames;

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

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        //play opening curtain animation 
    }

    public void SelectMinigame()
    {
        //play closing curtain animation
        switch (SelectRandomMinigame()) 
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

    public void QuitGame()
    {
        Application.Quit();
    }


}
