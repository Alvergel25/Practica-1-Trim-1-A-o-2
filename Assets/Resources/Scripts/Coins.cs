using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] private float amountP;

    [SerializeField] private Score points;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            points.AddPoints(amountP);
            Destroy(gameObject);
        }
    }
}
