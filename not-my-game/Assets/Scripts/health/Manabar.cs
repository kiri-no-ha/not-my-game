using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manabar : MonoBehaviour
{
    private Animator anim;
    public GameObject[] manabar;
    public float manabarlen;
    public GameObject player;
    private PlayerMana playerMama;


    void Start()
    {
        anim = GetComponent<Animator>();
        manabarlen = manabar.Length;
        playerMama = player.GetComponent<PlayerMana>();
    }

    // Update is called once per frame
    void Update()
    {
        float r = manabarlen - playerMama.GetHealth;
        if (r > 0)
        {
            DelHP(r);
        }
        if (r < 0)
        {
            AddHP(r * -1);
        }
        manabarlen = playerMama.GetHealth;
    }
    public void DelHP(float HP)
    {
        for (int i = 0; i < HP; i++)
        {

            manabar[^(i + 1)].GetComponent<Animator>().SetTrigger("DellMP_trigger");
        }
    }
    public void AddHP(float HP)
    {

        for (float i = manabarlen; i < HP + manabarlen; i++)
        {
            Debug.Log(i);
            manabar[(int)i].GetComponent<Animator>().SetTrigger("AddMP_trigger");
        }
    }
}