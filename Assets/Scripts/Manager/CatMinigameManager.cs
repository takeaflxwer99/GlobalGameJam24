using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMinigameManager : MonoBehaviour
{

    public float gameTimer;

    private int amountOfCatsInGame;

    [SerializeField] GameObject[] catPrefabs;
    GameObject catToBeSpawned;

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

    void CatSpawnPosition()
    {
        float spawnPointX = GetComponent<CapsuleCollider2D>().size.x;
        float spawnPointY = GetComponent<CapsuleCollider2D>().size.y;
        Vector2 randomSpawnPoint = new Vector2((Random.Range(0, spawnPointX * 2)), (Random.Range(0, spawnPointY * 2)));

        Instantiate(SelectCatToBeSpawned(), randomSpawnPoint.normalized, transform.rotation);
        StartCoroutine(SpawnCat());
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
