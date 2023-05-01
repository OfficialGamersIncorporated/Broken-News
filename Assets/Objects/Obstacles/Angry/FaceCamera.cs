using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour {

    public enum FacingType { Face, Align }
    public FacingType FacingMode = FacingType.Align;
    public bool YAxisOnly = false;
    [SerializeField]
    public Quaternion Offset = Quaternion.Euler(0,180,0);
    new public Camera camera;

    void Start() {
        if(!camera) camera = Camera.main;
    }
    void LateUpdate() {
        if(!camera || !camera.enabled) return;
        Transform camMain = camera.transform;

        if(FacingMode == FacingType.Face) {
            transform.LookAt(camMain);
            transform.rotation *= Offset;
        } else
            transform.rotation = camMain.rotation * Quaternion.Euler(0, 180, 0) * Offset;

        
        //if(YAxisOnly)
        //    if (transform.parent)
        //        transform.forward = Vector3.ProjectOnPlane(transform.forward, transform.parent.up);//Vector3.up); 
        //    else
        //        transform.forward = Vector3.ProjectOnPlane(transform.forward, Vector3.up); 
        if(YAxisOnly)
            if (transform.parent)
                transform.rotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(transform.forward, transform.parent.up), transform.parent.up);
            else
                transform.rotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(transform.forward, Vector3.up), Vector3.up);

    }
}
