using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicButton : MonoBehaviour
{
    // Start is called before the first frame update
    public  bool IsMusic;
    
    void Start()
    {
        IsMusic = true; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChanceMusic()
    {
        Debug.Log("asdfasd");
        IsMusic = !IsMusic;
    }
}
