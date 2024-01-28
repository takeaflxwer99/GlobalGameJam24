using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum PlayerType
{
    Player1,
    Player2,
}
public class PlayersMovements : MonoBehaviour
{
    public TextMeshProUGUI catGamePoints;

    public float velocidad = 5f;
    public int catsInLight = 0;
    public PlayerType playerType;

    public GameObject pepinoPrefab;


    private void Start()
    {
        if(catGamePoints == null)
        {

        }
    }

    void Update()
    {

        if (GameManager.Instance.gamePaused) 
            return;

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

        catGamePoints.text = catsInLight.ToString(); 
    }

    void ActivateEvent() 
    {
        //cannon audio
        Instantiate(pepinoPrefab, transform.position, Quaternion.identity);
    }
}