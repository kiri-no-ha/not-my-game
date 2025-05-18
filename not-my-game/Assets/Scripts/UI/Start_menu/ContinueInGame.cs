using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ContinueInGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetString("PlayerName") == "")
        {
            GetComponent<Button>().interactable=false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Continue_vhod()
    {
        
        GetComponent<SceneLoader>().LoadScen();
        
    }
}
