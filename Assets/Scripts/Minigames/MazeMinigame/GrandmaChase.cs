using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class GrandmaChase : MonoBehaviour
{
    public Transform targetPlayer;
    public float velocidadAbuela = 3f;
    public float distanciaAtrape = 0.5f;
    public float delayInicial;

    public GameObject victoryScreen;
    public TextMeshProUGUI winnerPlayerText;

    private bool chasePlayer = false;

    private void Start()
    {
        StartCoroutine(ChasePlayer());
    }

    private void Update()
    {
        if (chasePlayer)
        {
      
            Vector3 direccion = (targetPlayer.position - transform.position).normalized;
            transform.position += direccion * velocidadAbuela * Time.deltaTime;

            if (Vector3.Distance(transform.position, targetPlayer.position) < distanciaAtrape)
            {
                Debug.Log("UwU");
            }
        }
           
    }
    IEnumerator ChasePlayer()
    {
        yield return new WaitForSeconds(delayInicial);
        chasePlayer = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player1" || collision.tag == "Player2")
        {
            if(collision.tag == "Player1")
            {
                GameObject.Find("grandma2").GetComponent<GrandmaChase>().chasePlayer = false;
                victoryScreen.SetActive(true);
                winnerPlayerText.text = "PLAYER 2 WON THE RACE!!!";

            }
            else if (collision.tag == "Player2")
            {
                GameObject.Find("grandma").GetComponent<GrandmaChase>().chasePlayer = false;
                victoryScreen.SetActive(true);
                winnerPlayerText.text = "PLAYER 1 WON THE RACE!!!";
            }
            GameManager.Instance.CloseCurtainAnimations();
            GameManager.Instance.ChangeScene();
        }
    }
}
