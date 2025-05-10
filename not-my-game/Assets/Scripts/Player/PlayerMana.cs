using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMana : MonoBehaviour
{
    public float mana;
    private float maxMana = 5;
    void Start()
    {
        mana = maxMana;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeMana(float minusmana)
    {
        if (mana - minusmana < 0)
        {
            mana = 0;
        }
        else
        {
            mana -= minusmana;
        }
    }
    public void AddMana(float addmana)
    {
        if (mana + addmana > maxMana)
        {
            mana = maxMana;
        }
        else
        {
            mana += addmana;
        }
    }
    public float GetHealth { get { return mana; } }
}
