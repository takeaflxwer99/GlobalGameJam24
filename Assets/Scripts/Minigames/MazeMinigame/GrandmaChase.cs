using System.Collections;
using UnityEngine;

public class GrandmaChase : MonoBehaviour
{
    public Transform targetPlayer;
    public float velocidadAbuela = 3f;
    public float distanciaAtrape = 0.5f;
    public float delayInicial = 2f;

    private void Start()
    {
        StartCoroutine(StartChase());
    }

    IEnumerator StartChase()
    {
        yield return new WaitForSeconds(delayInicial);
        StartCoroutine(ChasePlayer());
    }

    IEnumerator ChasePlayer()
    {
        while (true)
        {
            Vector3 direccion = (targetPlayer.position - transform.position).normalized;
            transform.position += direccion * velocidadAbuela * Time.deltaTime;

            if (Vector3.Distance(transform.position, targetPlayer.position) < distanciaAtrape)
            {
                Destroy(targetPlayer.gameObject);
            }

            yield return null;
        }
    }
}
