using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] GameObject pickupEffect;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }

    void Pickup(Collider2D player)
    {
        //Instantiate(pickupEffect, transform.position, transform.rotation);

        Debug.Log("picked up!");
        player.GetComponent<SpriteRenderer>().color = Color.green;

        Destroy(gameObject);
    }
}
