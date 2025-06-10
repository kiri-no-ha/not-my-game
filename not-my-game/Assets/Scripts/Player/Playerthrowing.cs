using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerthrowing : MonoBehaviour
{
    public float kdthrowtime;
    private float schetchik;
    private Animator anim;
    public KeyCode ThrowButton;
    public PlayerMana PlayerMana;
    // Start is called before the first frame update
    void Start()
    {
        schetchik = 0;
        anim = GetComponent<Animator>();
        PlayerMana = GetComponent<PlayerMana>();
    }

    // Update is called once per frame
    void Update()
    {
        if (schetchik > kdthrowtime && Input.GetKey(ThrowButton) && PlayerMana.mana>0)
        {
            schetchik = 0;
            anim.SetBool("Throw", true);
        }
        else
        {
            anim.SetBool("Throw", false);
        }
            schetchik += Time.deltaTime;
    }
}
