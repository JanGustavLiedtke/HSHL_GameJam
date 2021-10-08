using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private int tooManyCoins;
    private GameObject player;
    private bool flyingCoin;
    private Vector2 vel;

    private void Start()
    {
        player = GameObject.Find("Character");
        flyingCoin = false;
        vel = new Vector2(1,0);
    }

    private void Update()
    {
        if (player.GetComponent<PlayerStats>().coins > tooManyCoins)
        {
            ChangeColliderSize(7);
        }

        if (flyingCoin)
        {
            transform.position = Vector2.SmoothDamp(transform.position, player.transform.position, ref vel, .3f) ;
            if(Vector2.Distance(transform.position, player.transform.position) < .5f)
            {
                CollectCoin();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            if(GetComponent<CircleCollider2D>().radius > 0.5f)
            {
                flyingCoin = true;
            }
            else
            {
                CollectCoin();
            }
        }
    }

    public void ChangeColliderSize(float size)
    {
        GetComponent<CircleCollider2D>().radius = size;
    }

    private void CollectCoin()
    {
        player.GetComponent<PlayerStats>().coins++;
        Destroy(gameObject);
    }
}
