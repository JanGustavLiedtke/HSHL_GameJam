using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private int tooManyCoins;
    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Character");
    }

    private void Update()
    {
        if (player.GetComponent<PlayerStats>().coins > tooManyCoins)
        {
            
            ChangeColliderSize(7);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            player.GetComponent<PlayerStats>().coins++;
            Destroy(gameObject);
        }
    }

    public void ChangeColliderSize(float size)
    {
        GetComponent<CircleCollider2D>().radius = size;
    }
}
