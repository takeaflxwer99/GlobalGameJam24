using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMinigameManager : MonoBehaviour
{

    public float gameTimer;

    private int amountOfCatsInGame;

    [SerializeField] GameObject[] catPrefabs;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            GameStarted();
        }
    }

    public void GameStarted()
    {

        StartCoroutine(StartMinigame());
    }

    public void StopMinigame()
    {
        StopCoroutine(SpawnCat());
    }

    void SelectCatToBeSpawned()
    {
        Vector2 spawnPointBoundMax = GetComponent<Renderer>().bounds.max;
        Vector2 spawnPointBoundMin = GetComponent<Renderer>().bounds.min;
        Vector2 randomSpawnPoint = new Vector2((Random.Range(spawnPointBoundMax.x, spawnPointBoundMin.x)), (Random.Range(spawnPointBoundMax.y, spawnPointBoundMin.y)));

        int catSelected = Random.Range(0, 12);
        if (catSelected <= 8)
        {
            Debug.Log("normal Cat");
        }
        else if(catSelected >= 9 && catSelected <= 10) 
        {
            Debug.Log("Toxic Cat");
        }
        else if (catSelected == 11)
        {
            Debug.Log("Golden Cat");
        }
        //Instantiate()
        StartCoroutine(SpawnCat());

    }


    IEnumerator StartMinigame()
    {
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(SpawnCat());
    }

    IEnumerator SpawnCat()
    {
        StopCoroutine(StartMinigame());
        yield return new WaitForSeconds(1.0f); ;
        SelectCatToBeSpawned();
    }

}
