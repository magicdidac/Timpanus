using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerRaycast
{

    private Transform cameraTransform;

    public void Initialize()
    {
        cameraTransform = Camera.main.transform;
    }

    public bool Check(float distance, LayerMask layer, out RaycastHit hit)
    {
        return Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, distance, layer);
    }

}
