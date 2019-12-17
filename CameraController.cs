using UnityEngine;
using System.Collections;
public class CameraController : MonoBehaviour
{
    
    public Transform target;

   
    public Vector3 offsetPosition;

  
    private Space offsetPositionSpace = Space.Self;

    
    private bool lookAt = true;

    private void LateUpdate()
    {
        Refresh();
    }

    public void Refresh()
    {
        /*if (target == null)
        {
            Debug.LogWarning("Missing target ref !", this);

            return;
        }*/

        if (offsetPositionSpace == Space.Self)
        {
            transform.position = target.TransformPoint(offsetPosition);
        }
        else
        {
            transform.position = target.position + offsetPosition;
        }

       
        if (lookAt)
        {
            transform.LookAt(target);
        }
        else
        {
            transform.rotation = target.rotation;
        }
    }
}