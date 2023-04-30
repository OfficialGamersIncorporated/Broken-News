using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paperLaunch : MonoBehaviour
{
    private Vector3 hitPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("mouse is down");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                hitPoint = hit.point;
            }
        }
    }
}
