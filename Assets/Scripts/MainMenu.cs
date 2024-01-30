using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public Canvas canvas;
    public void PlayButton()
    {

        SceneManager.LoadSceneAsync(1);

    }

    public void QuitButton()
    {

        Application.Quit();

    }

    private void Start()
    {
        Invoke("Destruir", 0f);
    }

    void Destruir()
    {
        Destroy(canvas.gameObject);
    }
}
