using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycasting : MonoBehaviour
{
    public float range;
    private IInteractable currentTarget;
    public Camera mainCamera;

    private void RaycastForInteractable(){
        RaycastHit hit;

        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
        
        if(Physics.Raycast(ray, out hit, range))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if(interactable != null)
            {
                if(hit.distance <= interactable.MaxRange)
                {
                    if(interactable == currentTarget)
                    {
                        return;
                    }
                    else
                    {
                        if(currentTarget!=null)
                        {
                            currentTarget.OnEndHover();
                        }
                        currentTarget = interactable;
                        currentTarget.OnStartHover();
                        return;
                    }
                }
                return;
            }
        }

        if(currentTarget!=null)
        {
            currentTarget.OnEndHover();
            currentTarget=null;
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        RaycastForInteractable();

        if(Input.GetKeyDown(KeyCode.E))
        {
            if(currentTarget!=null)
            {
                currentTarget.OnInteract();
            }
        }
    }
}
