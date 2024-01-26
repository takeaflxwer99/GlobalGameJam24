using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Movement : MonoBehaviour
{
    public float velocidad = 5f;
  
    void Update()
    {
        {
            float movimientoHorizontal = Input.GetAxis("HorizontalP1");
            float movimientoVertical = Input.GetAxis("VerticalP1");

            Vector3 movimiento = new Vector3(movimientoHorizontal, movimientoVertical, 0f);

            transform.position += movimiento * velocidad * Time.deltaTime;
        }
    }
}
