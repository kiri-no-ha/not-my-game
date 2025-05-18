using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public int indexscene;

    public void LoadScen()
    {
      
        SceneManager.LoadScene(indexscene);
    }
}
