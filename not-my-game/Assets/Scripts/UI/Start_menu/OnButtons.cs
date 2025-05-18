using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class OnButtons : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ONbt;
    public GameObject OFFbt;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeBT()
    {
        ONbt.SetActive(!ONbt.activeSelf);
        OFFbt.SetActive(!OFFbt.activeSelf);
    }
}
