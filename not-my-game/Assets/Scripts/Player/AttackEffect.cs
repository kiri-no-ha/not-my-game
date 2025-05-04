using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackEffect : MonoBehaviour
{
    public GameObject[] Effect;
    public GameObject[] parent;
    public int n;
    public int n_parent;
    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CreateEffect()
    {
        Instantiate(Effect[n], parent[n_parent].transform.position, parent[n_parent].transform.localRotation, parent[n_parent].transform);
    }
    public void DestoyEffect()
    {
        foreach (Transform child in parent[n_parent].transform)
        {
            Destroy(child.gameObject);
        }
    }
    public void Set_N(int number)
    {
        n= number;
    }
    public void Set_N_Parent(int number)
    {
        n_parent= number;
    }
}
