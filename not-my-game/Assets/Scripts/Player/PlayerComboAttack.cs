using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComboAttack : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    private int scet;
    private float time;
    public KeyCode Comboattackbutton;
    private bool firstattack;
    void Start()
    {
        firstattack = true;
        time = 0;
        scet = 0;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (Input.GetKey(Comboattackbutton) && (time<3 || firstattack) )
        {
            anim.SetInteger("Combo_Attack", ++scet);
            firstattack= false;
        }
        else
        {
            time = 0;
            scet = 0;
            anim.SetInteger("Combo_Attack", scet);
            firstattack= true;
        }
    }
}
