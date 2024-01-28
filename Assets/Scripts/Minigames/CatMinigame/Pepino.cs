using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pepino : MonoBehaviour
{
    [SerializeField] enum Player { player1, player2 };
    [SerializeField] Player ChoosePlayer;

    int player1Points;
    int player2Points;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroySelf());

        //PlayAnimation
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "NormalCat")
        {
            switch (ChoosePlayer)
            {
                case Player.player1:
                    player1Points = GameObject.FindWithTag("Player1").GetComponent<PlayersMovements>().catsInLight;
                    player1Points = player1Points + 1;
                    GameObject.FindWithTag("Player1").GetComponent<PlayersMovements>().catsInLight = player1Points;
                    break;
                case Player.player2:
                    player2Points = GameObject.FindWithTag("Player2").GetComponent<PlayersMovements>().catsInLight;
                    player2Points = player2Points + 1;
                    GameObject.FindWithTag("Player2").GetComponent<PlayersMovements>().catsInLight = player2Points;
                    break;
            }
            Destroy(collision.gameObject);
            //GameManager.Instance.activateMinigameEvent.Invoke();
        }
        else if (collision.tag == "GoldenCat")
        {
            switch (ChoosePlayer)
            {
                case Player.player1:
                    player1Points = GameObject.FindWithTag("Player1").GetComponent<PlayersMovements>().catsInLight;
                    player1Points = player1Points + 5;
                    GameObject.FindWithTag("Player1").GetComponent<PlayersMovements>().catsInLight = player1Points;
                    break;
                case Player.player2:
                    player2Points = GameObject.FindWithTag("Player2").GetComponent<PlayersMovements>().catsInLight;
                    player2Points = player2Points + 5;
                    GameObject.FindWithTag("Player2").GetComponent<PlayersMovements>().catsInLight = player2Points;
                    break;
            }
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "ToxicCat")
        {
            switch (ChoosePlayer)
            {
                case Player.player1:
                    player1Points = GameObject.FindWithTag("Player1").GetComponent<PlayersMovements>().catsInLight;
                    player1Points = player1Points - 1;
                    GameObject.FindWithTag("Player1").GetComponent<PlayersMovements>().catsInLight = player1Points;
                    break;
                case Player.player2:
                    player2Points = GameObject.FindWithTag("Player2").GetComponent<PlayersMovements>().catsInLight;
                    player2Points = player2Points - 1;
                    GameObject.FindWithTag("Player2").GetComponent<PlayersMovements>().catsInLight = player2Points;
                    break;
            }
            Destroy(collision.gameObject);
        }
    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        StopCoroutine(DestroySelf());
    }
}
