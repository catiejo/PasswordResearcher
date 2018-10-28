using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EscapeHatch : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    private float heldTime;
    private float heldThreshold;
    public bool buttonIsPressed;

    void Start()
    {
        heldTime = 0.0f;
        heldThreshold = 2.0f;
    }

    private void Update()
    {
        if (buttonIsPressed) {
            heldTime += Time.deltaTime;
        } else {
            heldTime = 0.0f;
        }
        if (heldTime >= heldThreshold) {
            OpenAdminArea();
        }

    }

    public static void OpenAdminArea() {
        SceneController.setParam("PreviousScreen", SceneController.GetActiveSceneName());
        SceneController.Load("Admin Screen");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        buttonIsPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonIsPressed = false;
    }


}
