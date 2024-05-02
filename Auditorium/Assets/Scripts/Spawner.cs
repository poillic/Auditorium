using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _particlePrefab;
    [SerializeField] private float _spawnRadius = 1f;
    [SerializeField] private float spawnInterval = 1f;
    private float _chrono = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _chrono += Time.deltaTime;

        if( _chrono >= spawnInterval )
        {
            Vector2 spawnPosition = (Vector2) transform.position + Random.insideUnitCircle * _spawnRadius;
            
            //On r�cup�re la particule
            GameObject particle = ObjectPool.Get();
            //GameObject particle = Instantiate( _particlePrefab, spawnPosition, Quaternion.identity );

            //On active la particle
            particle.SetActive( true );

            //On t�l�porte la particule
            particle.transform.position = spawnPosition;

            //On initialise la particule
            particle.GetComponent<Rigidbody2D>().velocity = transform.right * 10f;
            _chrono = 0f;
        }
    }
}
