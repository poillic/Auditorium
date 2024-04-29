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
    }
}
