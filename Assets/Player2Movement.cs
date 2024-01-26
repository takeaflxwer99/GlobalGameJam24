using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    public float velocidad = 5f;
   
    void Update()
    {
        float movimientoHorizontal = Input.GetAxis("HorizontalP2");
        float movimientoVertical = Input.GetAxis("VerticalP2");

        Vector3 movimiento = new Vector3(movimientoHorizontal, movimientoVertical, 0f);

        transform.position += movimiento * velocidad * Time.deltaTime;
    }
}
