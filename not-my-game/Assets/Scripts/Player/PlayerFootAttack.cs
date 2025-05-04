using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootAttack : MonoBehaviour
{
    // Start is called before the first frame update

    public KeyCode DownButton;
    public KeyCode AttackButton;
    private Animator anim;
    private float schetchik;
    public float maxattacktime=3;
    void Start()
    {
        schetchik = 0;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (schetchik>maxattacktime && Input.GetKey(AttackButton) && Input.GetKey(DownButton))
        {
            anim.SetTrigger("Foor_attack");
            schetchik = 0;
        }
        schetchik += Time.deltaTime;
    }
}
