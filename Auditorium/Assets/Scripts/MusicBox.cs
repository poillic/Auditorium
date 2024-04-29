using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBox : MonoBehaviour
{
    public AudioSource _audioSource;
    public Color _onColor;
    public Color _offColor;
    public SpriteRenderer[] _bars;

   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // En fonction de la propriété _audioSource.volume le bon nombre de barre s'allume

        for ( int i = 0; i < _bars.Length; i++ )
        {
            float seuil = (float)i / (float)_bars.Length;
            /*
             * 0 / 5 = 0
             * 1 / 5 = 0.2
             * 2 / 5 = 0.4
             * 3 / 5 = 0.6
             * 4 / 5 = 0.8
             * 5 / 5 = 1
             * 
             */
            if ( _audioSource.volume > seuil )
            {
                // on allume la barre
                _bars[ i ].color = _onColor;
            }
            else
            {
                // On éteinds la barre
                _bars[ i ].color = _offColor;
            }
        }
    }
}
