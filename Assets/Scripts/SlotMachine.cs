using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachine : MonoBehaviour
{
    int randInt, prizelength;
    string prizeWon;
    float time;
    bool started, rolling;
    Animator animator;

    [SerializeField] List<string> prizes;
    [SerializeField] List<float> chance;
    [SerializeField] GameObject animatorSlotOne;
    [SerializeField] GameObject animatorSlotTwo;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        time = 0;
        started = false;
        rolling = false;
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
            animator.SetBool("animationRunning", true);
            getPrize();
            started = true;
        }
        
    }

    private void FixedUpdate()
    {
        if (started)
        {
            time += Time.fixedDeltaTime;
            if (time > 1 && !rolling)
            {
                animatorSlotOne.GetComponent<Animator>().SetBool("rolling", true);
                animatorSlotTwo.GetComponent<Animator>().SetBool("rolling", true);
                animator.SetBool("animationRunning", false);
                time = 0;
                rolling = true;
            }
            if (time > 1 && rolling)
            {
                animatorSlotOne.GetComponent<Animator>().SetBool("rolling", false);
                animatorSlotTwo.GetComponent<Animator>().SetBool("rolling", false);
                time = 0;
                rolling = false;
                started = false;
            }
        }
    }
}
