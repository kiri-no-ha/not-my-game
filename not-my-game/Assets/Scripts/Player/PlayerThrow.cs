using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float AttackColdown;
    private float colldownTimer = Mathf.Infinity;
    private PlayerMana playermana;
    [SerializeField] private GameObject spawnsegment;
    [SerializeField] private Transform parent;
    void Start()
    {
        playermana = GetComponent<PlayerMana>();
    }

    // Update is called once per frame
    void Update()
    {
        if (colldownTimer > AttackColdown && Input.GetKey(KeyCode.F))
        {
            Attack();
            colldownTimer = 0;
        }
        colldownTimer += Time.deltaTime;    
    }
    public void Attack()
    {
        if (playermana.mana - 1 >= 0)
        {
            playermana.TakeMana(1);
            SpawnElem();
        }
    }
    public void SpawnElem()
    {
        Debug.Log("ВЫстрел");
        GameObject a = Instantiate(spawnsegment, parent.position, transform.rotation);
        a.GetComponent<RunKynau>().moveRight= transform.localScale.x>0;
    }
}
