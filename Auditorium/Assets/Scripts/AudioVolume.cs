using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioVolume : MonoBehaviour
{
    public AudioMixer mixer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //mixer.SetFloat( "MasterVolume", 10f );
    }

    public void SetVolume(float value )
    {
        float decibel = Mathf.Log10( value ) * 20f;
        mixer.SetFloat( "MasterVolume", decibel );
    }

}
