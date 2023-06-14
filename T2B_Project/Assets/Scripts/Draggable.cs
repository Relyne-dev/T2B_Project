using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.PostProcessing;

public class Draggable : MonoBehaviour
{
    bool shouldBeDragged = true;
    Plane dragPlane;

    Vector3 offset;

    Camera mainCamera;

    PostProcessVolume glowVol;
    Bloom g_Bloom;

    void Start()
    {
        mainCamera = Camera.main;
        g_Bloom = ScriptableObject.CreateInstance<Bloom>();
        g_Bloom.intensity.Override(1f);
        glowVol = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, g_Bloom);
    }

    void OnMouseDown()
    {
        // shift up towards camera -----------------------------------------
        float currentX, currentY, currentZ;
        currentX = transform.position.x;
        currentY = transform.position.y;
        currentZ = transform.position.z;
        transform.position = new Vector3(currentX, currentY + 1f, currentZ);
        // -----------------------------------------------------------------

        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            g_Bloom.color.value = Color.red;
        }

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
