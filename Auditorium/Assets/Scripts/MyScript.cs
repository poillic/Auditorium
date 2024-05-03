using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MyScript : MonoBehaviour
{
    public AudioMixer mixer;

    private void Start()
    {
        if(  PlayerPrefs.HasKey("Volume") )
        {
            mixer.SetFloat( "MasterVolume", PlayerPrefs.GetFloat( "Volume" ) );
        }

        PlayerPrefs.SetFloat( "Volume", 1f );

        //GameManager
        //SceneManager.LoadScene( "UI", LoadSceneMode.Additive );
    }

    public void SetVolume( float value )
    {
        float decibel = Mathf.Log10( value ) * 20f;
        mixer.SetFloat( "MasterVolume", decibel );
    }

}
