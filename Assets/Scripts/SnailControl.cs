using System.Collections;
using UnityEngine;

public enum OtroPlayerType
{
    Caracol1,
    Caracol2
}

public class SnailControl : MonoBehaviour
{
    public OtroPlayerType playerType;
    public float velocidadConstante = 1f;
    public float impulso = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
      
        float inputCaracol = 0f;

        switch (playerType)
        {
            case OtroPlayerType.Caracol1:
                inputCaracol = Input.GetAxis("Caracol1");
                break;
            case OtroPlayerType.Caracol2:
                inputCaracol = Input.GetAxis("Caracol2");
                break;
        }

        if (inputCaracol > 0)
        {
            rb.velocity = new Vector2(impulso, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(velocidadConstante, rb.velocity.y);
        }
    }

}
