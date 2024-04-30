using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseManager : MonoBehaviour
{

    public Texture2D centerIcon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PointerMove( InputAction.CallbackContext context )
    {
        Vector2 pointerPosition = context.ReadValue<Vector2>();

        _ray = Camera.main.ScreenPointToRay( pointerPosition );

        RaycastHit2D hit = Physics2D.GetRayIntersection( _ray );

        // Si j'ai touché quelque chose
        if( hit.collider != null )
        {
            if( hit.collider.CompareTag("CenterZone") )
            {
                Debug.Log( "CENTER" );
                Cursor.SetCursor( centerIcon, new Vector2( 256, 256 ), CursorMode.Auto );
                // J'ai touché la fleche
            }
            else if( hit.collider.CompareTag( "OutterZone" ) )
            {
                // J'ai touché le cercle exterieur
                Debug.Log( "OUTTER" );
            }
        }
        else
        {
            //Notre pointer survole rien, on remet le curseur à sa forme par défaut
            Cursor.SetCursor( null, Vector2.zero, CursorMode.Auto );
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay( _ray.origin, _ray.direction * 1000f );
    }

    private Ray _ray;
}
