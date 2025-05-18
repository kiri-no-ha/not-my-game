using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_new_Game : MonoBehaviour
{
    // Start is called before the first frame update
    public void Open_NewGameWindow()
    {

    }
    public void CreateNewGame()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("PlayerName", "Oleg");
        GetComponent<SceneLoader>().LoadScen();
    }
}
