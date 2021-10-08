using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int coins;
    public int life;

    private void Start()
    {
        coins = 0;
    }

    private void Update()
    {
        Debug.Log("coins: " + coins);
    }

}
