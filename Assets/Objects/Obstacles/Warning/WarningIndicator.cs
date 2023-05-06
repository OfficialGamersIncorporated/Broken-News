using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningIndicator : MonoBehaviour {

    public Transform Pivot;
    Camera cam;
    float worldPadding = 2;
    float zOffset = 5;
    float maxDistanceOffScreen = 10;

    void Start() {
        cam = Camera.main;
    }
    void LateUpdate() {
        Vector3 cameraInlineFocusDirection = Vector3.ProjectOnPlane(transform.position - cam.transform.position, cam.transform.right);
        float distanceForward = cameraInlineFocusDirection.magnitude;
        float distanceHorizontal = ((cam.transform.position + cameraInlineFocusDirection) - transform.position).magnitude;
        float frustumHeight = 2.0f * distanceForward * Mathf.Tan(cam.fieldOfView * 0.5f * Mathf.Deg2Rad);
        float frustumWidth = (frustumHeight * cam.aspect) - worldPadding;

        //print("distanceHorizontal: " + distanceHorizontal.ToString());
        //print("frustrumWidth: " + frustumWidth.ToString());
        Vector3 toCameraVector = cam.transform.position - transform.position;
        if(distanceHorizontal > frustumWidth / 2 && distanceHorizontal - frustumWidth/2 < maxDistanceOffScreen && Vector3.Dot(transform.forward, toCameraVector) > 0) {
            Pivot.gameObject.SetActive(true);
            Vector3 pivotToCameraVector = cam.transform.position - Pivot.position;
            Pivot.position = Vector3.MoveTowards(transform.position, cam.transform.position + cameraInlineFocusDirection, distanceHorizontal - frustumWidth / 2) + pivotToCameraVector.normalized * zOffset;
            //Pivot.position = cam.transform.position + cameraInlineFocusDirection;
        } else {
            Pivot.gameObject.SetActive(false);
            Pivot.localPosition = Vector3.zero;
        }
    }
}
