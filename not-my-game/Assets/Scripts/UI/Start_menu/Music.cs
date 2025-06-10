using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject selfbt;
    private MusicButton musicButton;
    private AudioSource musicSource;
    void Start()
    {
        musicButton = selfbt.GetComponent<MusicButton>();
        musicSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        musicSource.enabled = musicButton.IsMusic;
    }
    
}
