using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBox : MonoBehaviour
{
    public AudioSource _audioSource;
    public Color _onColor;
    public Color _offColor;
    public SpriteRenderer[] _bars;

    [Header( "Volume" )]
    [Tooltip( "Volume gain per particle" )]
    public float volumeIncrement = 0.02f;
    [Tooltip( "Volume lost per second" )]
    public float volumeDecay = 0.1f;

    void Start()
    {
        _audioSource.volume = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // En fonction de la propriété _audioSource.volume le bon nombre de barre s'allume

        for ( int i = 0; i < _bars.Length; i++ )
        {
            float seuil = (float)i / (float)_bars.Length;

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

        _audioSource.volume -= volumeDecay * Time.deltaTime;
    }

    private void OnTriggerEnter2D( Collider2D collision )
    {
        if( collision.CompareTag("Particle") )
        {
            _audioSource.volume += volumeIncrement;
        }
    }
}
