using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class CatMovement : MonoBehaviour
{
    enum CatType { normal, golden, toxic };
    [SerializeField] CatType type;

    private enum State { alive, dead};
    State state;

    public Sprite scaredSprite;
    private Vector2 movimiento;
    private float speed;
    private bool catCanMove = false;

    private void Start()
    {
        CatMove();

        switch (type)
        {
            case CatType.normal:
                speed = 5.0f;
                break;
            case CatType.toxic:
                speed = 5.0f;
                break; 
            case CatType.golden:
                speed = 7;
                break; 
            default:
                break;
        }
    }

    private void Update()
    {
        if (catCanMove)
        {
            GetComponent<Rigidbody2D>().velocity = (movimiento.normalized * speed);
        }
    }

    void CatMove()
    {
        catCanMove = true;
        if (!GameManager.Instance.gamePaused)
        {
            if(state == State.alive)
            {
                switch(Random.Range(0, 9))
                {
                    case 0:
                        movimiento = new Vector2(1, 0);
                        break; 
                    case 1:
                        movimiento = new Vector2(-1, 0);
                        break; 
                    case 2:
                        movimiento = new Vector2(0, 1);
                        break;
                    case 3:
                        movimiento = new Vector2(0, -1);
                        break;
                    case 4:
                        movimiento = new Vector2(1, -1);
                        break;
                    case 5:
                        movimiento = new Vector2(-1, 1);
                        break;
                    case 6:
                        movimiento = new Vector2(-1, -1);
                        break;
                    case 7:
                        movimiento = new Vector2(1, 1);
                        break;
                    case 8:
                        movimiento = new Vector2(0, 0);
                        break;
                    default:
                        break;
                }
                StartCoroutine(NextDirection());
            }
        }
        else
        {
            StopCoroutine(NextDirection());
        }
    }

    IEnumerator NextDirection()
    {
        yield return new WaitForSeconds(1.0f);
        CatMove();
    }

    private void OnDestroy()
    {
        state = State.dead;
        GetComponent<SpriteRenderer>().sprite = scaredSprite;
        //Play animation 
    }

}
