using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Pausa : MonoBehaviour
{
    public bool Ispaused;
    public GameObject paused_menu;
    public float schet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.Escape))
        {
            Debug.Log(Ispaused);
            Ispaused = true;
            schet = 0;
        }


        if (Ispaused)
        {
            paused_menu.SetActive(true);
            Time.timeScale = 0;
            
        }
        else
        {
            paused_menu.SetActive(false);
            Time .timeScale = 1;

        }
        
            
    }
    public void Change_paused()
    {
        Ispaused = false;
    }

}
