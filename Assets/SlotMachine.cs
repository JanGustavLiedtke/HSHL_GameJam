using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachine : MonoBehaviour
{
    int randInt, prizelength;
    string prizeWon;

    [SerializeField] List<string> prizes;
    [SerializeField] List<float> chance;

    private void Awake()
    {
    }

    void getPrize()
    {
        prizelength = prizes.ToArray().Length;

        List<string> combined = new List<string>();
        for(int i = 0; i < prizelength; i++)
        {
            for(int j = 0; j < chance[i]; j++)
            {
                combined.Add(prizes[i]);
            }

        }

        randInt = Random.Range(0, combined.ToArray().Length - 1);
        prizeWon = combined[randInt];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            getPrize();
            Debug.Log("Preis:" + prizeWon);
        }
    }
}
