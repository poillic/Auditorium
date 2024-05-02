using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyScript : MonoBehaviour
{
    public int _qtyToPool = 10;
    public GameObject _itemToPool;
    private static GameObject[] _pool;

    private void Start()
    {
        _pool = new GameObject[ _qtyToPool ];

        for ( int i = 0; i < _qtyToPool; i++ )
        {
            _pool[ i ] = Instantiate( _itemToPool );
            _pool[ i ].SetActive( false );
        }
    }

    public static GameObject Get()
    {
        foreach ( GameObject item in _pool )
        {
            if( item.activeSelf )
            {
                return item;
            }
        }

        return null;
    }
}
