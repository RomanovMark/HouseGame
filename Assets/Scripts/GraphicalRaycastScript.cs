using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GraphicalRaycastScript : MonoBehaviour
{
    GraphicRaycaster raycaster;
    PointerEventData pointerEventData;
    EventSystem eventSystem;

    private void Start()
    {
        raycaster = GetComponent<GraphicRaycaster>();
        eventSystem = GameObject.Find(nameof(EventSystem)).GetComponent<EventSystem>();

        if (raycaster != null)
            Debug.Log("Raycaster adding success.");
        else
            Debug.LogError("Raycaster component not found");

        if (eventSystem != null)
            Debug.Log("EventSystem adding success.");
        else
            Debug.LogError("EventSystem component not found");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !GameManager.Instance.CameraIsLocked)
        {
            var currentLayer = GetCurrentLayer();

            if (currentLayer == 5)
                GameManager.Instance.CameraIsLocked = true;
        }

    }

    public int? GetCurrentLayer()
    {
        pointerEventData = new PointerEventData(eventSystem);
        pointerEventData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();
        raycaster.Raycast(pointerEventData, results);

        if (results.Any())
            return results[0].gameObject.layer;
        else
            return null;
    }
}
