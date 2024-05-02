using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public float winDuration = 2f;
    public AudioSource[] _musicBoxes;
    private int _nbFullBox = 0;
    private float _chrono = 0f;

    private bool _allMaxVolume = true;

    private void OnEnable()
    {
        Debug.Log( "Je suis activé !" );
    }

    private void OnDisable()
    {
        Debug.Log( "Je suis desactivé !" );
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] boxes = GameObject.FindGameObjectsWithTag( "MusicBox" );

        // En C# les tableaux ont une longueur fixe !
        _musicBoxes = new AudioSource[ boxes.Length ];

        for ( int i = 0; i < boxes.Length; i++ )
        {
            /*
            GameObject box = boxes[ i ];
            AudioSource audio = box.GetComponent<AudioSource>();
            _musicBoxes[ i ] = audio;
            */

            //Même façon de faire mais en une ligne
            _musicBoxes[ i ] = boxes[ i ].GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {

        /*_nbFullBox = 0;

        foreach ( AudioSource box in _musicBoxes )
        {
            if( box.volume == 1f )
            {
                _nbFullBox++;
            }
        }
        
        if ( _nbFullBox >= _musicBoxes.Length )
        {
            _chrono += Time.deltaTime;
        }
        else
        {
            _chrono = 0f;
        }
         
        */

        _allMaxVolume = true;

        foreach ( AudioSource box in _musicBoxes )
        {
            if ( box.volume < 1f )
            {
                _allMaxVolume = false;
                break;
            }
        }

        if( _allMaxVolume )
        {
            _chrono += Time.deltaTime;
        }
        else
        {
            _chrono = 0f;
        }

        if( _chrono >= winDuration )
        {
            Debug.Log( "Je lance l'event de fin de partie" );
        }
    }
}
