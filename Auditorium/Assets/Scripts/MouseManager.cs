using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseManager : MonoBehaviour
{

    public Texture2D centerIcon;
    public Texture2D resizeIcon;

    [Header("Radius Parameters")]
    public float minRadius = 1f;
    public float maxRadius = 10f;
    //public Vector2 radiusLimit = new Vector2( 1f, 10f );
    
    private Ray _ray;
    private bool _isClicked;
    private GameObject _objectToMove = null;
    private CircleShape _objectToResize = null;
    private Vector3 _worldPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log( _isClicked );

        if( _isClicked && _objectToMove != null )
        {
            Debug.Log( $"Je dois déplacer {_objectToMove.name}" );
            _objectToMove.transform.position = _worldPosition;
        }

        if( _isClicked && _objectToResize != null )
        {
            //Calcul de la distance entre le pointer et le centre de l'objet avec Vector2.Distance
            float radius = Vector2.Distance( _objectToResize.transform.position, _worldPosition );
            _objectToResize.Radius = Mathf.Clamp( radius , minRadius, maxRadius );
            //_objectToResize.Radius = Mathf.Clamp( radius , radiusLimit.x, radiusLimit.y );
        }

        if( !_isClicked )
        {
            _objectToMove = null;
            _objectToResize = null;
        }
    }

    /*public float Clamp( float value, float min, float max )
    {
        if( value < min )
        {
            return min;
        }
        else if( value > max )
        {
            return max;
        }
        else
        {
            return value;
        }

        //return Mathf.Max( Mathf.Min( value, max ), min );
    }*/

    public void PointerMove( InputAction.CallbackContext context )
    {
        //Position en pixel du pointer dans l'écran
        Vector2 pointerPosition = context.ReadValue<Vector2>();

        _ray = Camera.main.ScreenPointToRay( pointerPosition );

        RaycastHit2D hit = Physics2D.GetRayIntersection( _ray );

        //Converti un point de l'écran dans le world
        //!\ Attention au Z avec cette méthode
        _worldPosition = Camera.main.ScreenToWorldPoint( pointerPosition );
        _worldPosition.z = 0;
        // Si j'ai touché quelque chose
        if( hit.collider != null )
        {
            if( hit.collider.CompareTag("CenterZone") )
            {
                Debug.Log( "CENTER" );
                Cursor.SetCursor( centerIcon, new Vector2( 256, 256 ), CursorMode.Auto );
                // J'ai touché la fleche

                _objectToMove = hit.collider.transform.parent.gameObject;
            }
            else if( hit.collider.CompareTag( "OutterZone" ) )
            {
                // J'ai touché le cercle exterieur
                Debug.Log( "OUTTER" );
                Cursor.SetCursor( resizeIcon, new Vector2( 256, 256 ), CursorMode.Auto );
                _objectToResize = hit.collider.GetComponent<CircleShape>();
            }
        }
        else
        {
            //Notre pointer survole rien, on remet le curseur à sa forme par défaut
            Cursor.SetCursor( null, Vector2.zero, CursorMode.Auto );
        }
    }

    public void PointerPress( InputAction.CallbackContext context )
    {
        switch ( context.phase )
        {
            case InputActionPhase.Started:
                //Action qui débute
                break;
            case InputActionPhase.Performed:
                //Action qui est effectuée
                //Le click est actif
                _isClicked = true;
                break;
            case InputActionPhase.Canceled:
                //Action qui est annulée
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
