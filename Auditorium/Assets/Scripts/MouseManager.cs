using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseManager : MonoBehaviour
{

    public Texture2D centerIcon;
    private Ray _ray;
    private bool _isClicked;
    private GameObject _zone = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log( _isClicked );

        if( _isClicked && _zone != null )
        {
            Debug.Log( $"Je dois d�placer {_zone.name}" );
        }
    }

    public void PointerMove( InputAction.CallbackContext context )
    {
        //Position en pixel du pointer dans l'�cran
        Vector2 pointerPosition = context.ReadValue<Vector2>();

        _ray = Camera.main.ScreenPointToRay( pointerPosition );

        RaycastHit2D hit = Physics2D.GetRayIntersection( _ray );

        //Converti un point de l'�cran dans le world
        //!\ Attention au Z avec cette m�thode
        //Camera.main.ScreenToWorldPoint()

        // Si j'ai touch� quelque chose
        if( hit.collider != null )
        {
            if( hit.collider.CompareTag("CenterZone") )
            {
                Debug.Log( "CENTER" );
                Cursor.SetCursor( centerIcon, new Vector2( 256, 256 ), CursorMode.Auto );
                // J'ai touch� la fleche

                _zone = hit.collider.transform.parent.gameObject;
            }
            else if( hit.collider.CompareTag( "OutterZone" ) )
            {
                // J'ai touch� le cercle exterieur
                Debug.Log( "OUTTER" );
            }
        }
        else
        {
            //Notre pointer survole rien, on remet le curseur � sa forme par d�faut
            Cursor.SetCursor( null, Vector2.zero, CursorMode.Auto );
            _zone = null;
        }
    }

    public void PointerPress( InputAction.CallbackContext context )
    {
        switch ( context.phase )
        {
            case InputActionPhase.Started:
                //Action qui d�bute
                break;
            case InputActionPhase.Performed:
                //Action qui est effectu�e
                //Le click est actif
                _isClicked = true;
                break;
            case InputActionPhase.Canceled:
                //Action qui est annul�e
                //Le click est inactif
                _isClicked = false;
                break;
            default:
                break;
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay( _ray.origin, _ray.direction * 1000f );
    }

    
}
