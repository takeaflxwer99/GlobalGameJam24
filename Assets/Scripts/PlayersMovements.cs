using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerType
{
    Player1,
    Player2,
    Caracol1,
    Caracol2,
}
public class PlayersMovements : MonoBehaviour
{
    public float velocidad = 5f;
    public float impulse = 5f;
    private bool impulseCaracol = true;
    public PlayerType playerType;

    void Update()
    {
        float movimientoHorizontal = 0f;
        float movimientoVertical = 0f;


        if (playerType == PlayerType.Player1)
        {
            movimientoHorizontal = Input.GetAxis("HorizontalP1");
            movimientoVertical = Input.GetAxis("VerticalP1");

        }
        else if (playerType == PlayerType.Player2)
        {
            movimientoHorizontal = Input.GetAxis("HorizontalP2");
            movimientoVertical = Input.GetAxis("VerticalP2");
        }
        else if (playerType == PlayerType.Caracol1)
        {
            movimientoHorizontal = 0.2f;

            if (Input.GetButtonDown("Caracol1") && impulseCaracol)
            {
                GetComponent<Rigidbody2D>().velocity += new Vector2(impulse, 0f);
                impulseCaracol = false;
            }

        }
        else if (playerType == PlayerType.Caracol2)
        {
            movimientoHorizontal = 0.2f;

            if (Input.GetButtonDown("Caracol2") && !impulseCaracol)
            {
                GetComponent<Rigidbody2D>().velocity += new Vector2(impulse, 0f);
                impulseCaracol = true;
            }

        }

        Vector3 movimiento = new Vector3(movimientoHorizontal, movimientoVertical, 0f);
        transform.position += movimiento * velocidad * Time.deltaTime;
    }
}