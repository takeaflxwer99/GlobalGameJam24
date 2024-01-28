using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMinigameManager : MonoBehaviour
{

    public float gameTimer;
    public static CatMinigameManager Instance;

    private int amountOfCatsInGame;

    [SerializeField] GameObject[] catPrefabs;
    GameObject catToBeSpawned;
    private bool spawnCats = true;

    private void Awake()
    {
        Instance = this;
    }

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
        spawnCats = false;
        StopCoroutine(SpawnCat());
        GameManager.Instance.CloseCurtainAnimations();
        GameManager.Instance.ChangeScene();
    }

    GameObject SelectCatToBeSpawned()
    {

        int catSelected = Random.Range(0, 12);
        if (catSelected <= 8)
        {
            Debug.Log("normal Cat");
            catToBeSpawned = catPrefabs[0];
        }
        else if(catSelected >= 9 && catSelected <= 10) 
        {
            Debug.Log("Toxic Cat");
            catToBeSpawned = catPrefabs[1];
        }
        else if (catSelected == 11)
        {
            Debug.Log("Golden Cat");
            catToBeSpawned = catPrefabs[2];

        }
        return catToBeSpawned;

    }

    public void CatSpawnPosition()
    {
        if (spawnCats)
        {
            Vector2 spawnPointMax = GetComponent<SpriteRenderer>().bounds.max;
            Vector2 spawnPointMin = GetComponent<SpriteRenderer>().bounds.min;
            Vector2 randomSpawnPoint = new Vector2((Random.Range(spawnPointMax.x, spawnPointMin.x) / 2), (Random.Range(spawnPointMax.y, spawnPointMin.y) / 2));

            Instantiate(SelectCatToBeSpawned(), transform.position, transform.rotation);
            StartCoroutine(SpawnCat());
        }
    }


    IEnumerator StartMinigame()
    {
        yield return new WaitForSeconds(1.0f);
        //GameManager.Instance.minigameStarted.Invoke();
        StartCoroutine(SpawnCat());
    }

    IEnumerator SpawnCat()
    {
        StopCoroutine(StartMinigame());
        yield return new WaitForSeconds(1.0f); ;
        CatSpawnPosition();
    }



}
