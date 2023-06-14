using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.PostProcessing;
using TMPro;

public class Card : MonoBehaviour
{
    // Variables for drag functionality
    bool shouldBeDragged = true;
    Plane dragPlane;
    Vector3 offset;
    Camera mainCamera;
    public PostProcessProfile glowProfile;
    Bloom g_Bloom;

    // Card class variables
    [Header("Card Variables")]
    CardType cardType;
    public int cost;
    public int health;
    public int damage;

    public TMP_Text _cost;
    public TMP_Text _hp;
    public TMP_Text _dmg;

    public GameObject borderObj;


    void Start()
    {
        mainCamera = Camera.main;
        g_Bloom = ScriptableObject.CreateInstance<Bloom>();
        g_Bloom.intensity.Override(1f);

    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.isPressed && this.shouldBeDragged)
        {
            this.borderObj.GetComponent<Renderer>().material.color = Color.red;
            //glowProfile.GetSetting<Bloom>().enabled.value = true;
            //glowProfile.GetSetting<Bloom>().color.value = Color.red;
            //glowProfile.GetSetting<Bloom>().intensity.value = 20f;
        }
        else
        {
            this.borderObj.GetComponent<Renderer>().material.color = Color.blue;
            this.borderObj.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0.1f, 0.1f, 0.1f));
            //glowProfile.GetSetting<Bloom>().color.value = Color.blue;
            //glowProfile.GetSetting<Bloom>().intensity.value = 0f;
            //glowProfile.GetSetting<Bloom>().enabled.value = false;
        }

        updateCardText();
    }

    void updateCardText()
    {
        _cost.text = cost.ToString();
        _hp.text = health.ToString();
        _dmg.text = damage.ToString();
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
