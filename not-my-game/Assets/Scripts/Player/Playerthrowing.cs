using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerthrowing : MonoBehaviour
{
    public float kdthrowtime;
    private float schetchik;
    private Animator anim;
    public KeyCode ThrowButton;
    private PlayerMana plmana;
    // Start is called before the first frame update
    void Start()
    {
        schetchik = 0;
        anim = GetComponent<Animator>();
        plmana = GetComponent<PlayerMana>();
    }

    // Update is called once per frame
    void Update()
    {
        if (schetchik > kdthrowtime && Input.GetKey(ThrowButton) && plmana.mana>0)
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
