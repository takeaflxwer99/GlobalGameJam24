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
        //SelectMinigame();
        //play opening curtain animation 
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space)) 
        {
            SelectMinigame();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKeyUp(KeyCode.RightShift))
        {
            SceneManager.LoadScene(2);
        }
    }

    public void SelectMinigame()
    {
        //play closing curtain animation
        switch (SelectRandomMinigame()) 
        {
            case 0:
                //Debug.Log(0);
                //SceneManager.LoadScene("CatMinigame");
                break; 
            case 1:
                //Debug.Log(1);
                //SceneManager.LoadScene("SnailRaice");
                break; 
            case 2:
                //Debug.Log(2);
                //SceneManager.LoadScene("Laberinth");
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


}
