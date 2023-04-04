using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    // Variables for drag functionality
    bool shouldBeDragged = true;
    Plane dragPlane;
    Vector3 offset;
    Camera mainCamera;

    // Card class variables
    [Header("Card Variables")]
    CardType cardType;
    int cost;


    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // ----------------------------------- Drag Functionality --------------------------------------
    void OnMouseDown()
    {
        // shift up towards camera -----------------------------------------
        float currentX, currentY, currentZ;
        currentX = transform.position.x;
        currentY = transform.position.y;
        currentZ = transform.position.z;
        transform.position = new Vector3(currentX, currentY + 0.7f, currentZ);
        // -----------------------------------------------------------------

        // find offset of mouse position to camera/world -------------------
        dragPlane = new Plane(mainCamera.transform.forward, transform.position);
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);

        float planeDist;
        dragPlane.Raycast(cameraRay, out planeDist);
        offset = transform.position - cameraRay.GetPoint(planeDist);
        // -----------------------------------------------------------------
    }

    void OnMouseDrag()
    {
        if (shouldBeDragged)
        {
            // get mouse position
            Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);

            // update/change position using offset
            float planeDist;
            dragPlane.Raycast(cameraRay, out planeDist);
            transform.position = cameraRay.GetPoint(planeDist) + offset;
        }

    }
}
