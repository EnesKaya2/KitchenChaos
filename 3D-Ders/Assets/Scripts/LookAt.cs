using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public enum Mode
    {
        LookAt,
        LookAtInverted,
        CameraForward,
        CameraForwardInverted,
    }
    public Mode mode;

    private void FixedUpdate()
    {
        switch (mode)
        {
            case Mode.LookAt:
                transform.LookAt(Camera.main.transform);
                break;
         
            case Mode.LookAtInverted:
                Vector3 dirFromCamera=transform.position - Camera.main.transform.forward;
                transform.LookAt(transform.position - dirFromCamera);
                break;
            
            case Mode.CameraForward:
                transform.forward = Camera.main.transform.forward;
                break;
            
            case Mode.CameraForwardInverted:
                transform.forward = -Camera.main.transform.forward;
                break;
        }
    }
}