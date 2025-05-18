using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_new_Game : MonoBehaviour
{
    // Start is called before the first frame update
    public void CreateNewGame(string name)
    {
        PlayerPrefs.DeleteAll();
    }
}
