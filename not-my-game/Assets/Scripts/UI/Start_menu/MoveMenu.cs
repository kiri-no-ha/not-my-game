using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject menu;
    public Vector3 menu_startpos;
    void Start()
    {
        menu_startpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Movemenu()
    {
        menu.transform.position = new Vector3(1000, 1000, 1000);
    }
    public void Movemenu_obratno()
    {
        menu.transform.position = menu_startpos;
    }
}
