using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEvent : MonoBehaviour
{

    Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // new Input System form of mouse click
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = mainCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
            Ray raycast = mainCam.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(mousePos, Vector3.forward);

            if(Physics.Raycast(raycast, out RaycastHit hit, 1))
            {
                
                GameObject obj = hit.collider.gameObject;
                //obj.GetComponent<Rigidbody>().MovePosition(mousePos);
                //obj.inPlay = true;
            }
        }

    }

    private void OnMouseDown()
    {
        
    }
}
