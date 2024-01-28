using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PlayerType
{
    Player1,
    Player2,
}
public class PlayersMovements : MonoBehaviour
{
    public Text catGamePoints;

    public float velocidad = 5f;
    public int catsInLight = 0;
    public PlayerType playerType;

    private bool catInsideTrigger = false;

    private void Start()
    {
        if(catGamePoints == null)
        {

        }
    }

    void Update()
    {
        float movimientoHorizontal = 0f;
        float movimientoVertical = 0f;


        if (playerType == PlayerType.Player1)
        {
            movimientoHorizontal = Input.GetAxis("HorizontalP1");
            movimientoVertical = Input.GetAxis("VerticalP1");
            if(Input.GetKeyDown(KeyCode.R)) 
            {
                ActivateEvent();
            }

        }
        else if (playerType == PlayerType.Player2)
        {
            movimientoHorizontal = Input.GetAxis("HorizontalP2");
            movimientoVertical = Input.GetAxis("VerticalP2");
            if (Input.GetKeyDown(KeyCode.M))
            {
                ActivateEvent();
            }
        }

        Vector3 movimiento = new Vector3(movimientoHorizontal, movimientoVertical, 0f);
        transform.position += movimiento * velocidad * Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "cat")
        {
            
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "cat")
        {
            catsInLight = catsInLight - 1;
        }
        Debug.Log(catsInLight);
    }

    void ActivateEvent() 
    {
        GameManager.Instance.activateMinigameEvent.Invoke();
        //ShootAnimation 
        //Instantiate(pepinoPrefab, transform.position, Quaternion.identity);
    }
}