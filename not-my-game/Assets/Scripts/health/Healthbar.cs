using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    private Animator anim;
    public  GameObject[] healbar;
    public float healbarlen;
    public float playerhealtjjj;
    public  GameObject player;
    private PlayerHealth playerHealth;

        
    void Start()
    {
        anim = GetComponent<Animator>();
        healbarlen= healbar.Length;
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        playerhealtjjj = playerHealth.GetHealth;
        float r = healbarlen-playerHealth.GetHealth;
        if (r > 0)
        {
            DelHP(r);
        }
        if(r < 0)
        {
            AddHP(r*-1);
        }
        healbarlen = playerHealth.GetHealth;
    }
    public void DelHP(float HP)
    {
        for (int i = 0; i < HP; i++)
        {
            Debug.Log(i);
            healbar[^(i+1)].GetComponent<Animator>().SetTrigger("DellHP_trigger");
        }
    }
    public void AddHP(float HP)
    {
        for (float i = healbarlen; i < healbarlen+HP; i++)
        {
            healbar[(int)i].GetComponent<Animator>().SetTrigger("AddHP_triger");
        }
    }
}
