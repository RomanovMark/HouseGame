using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OrbitCameraController : MonoBehaviour
{
    [Header("Important Objects")]
    [SerializeField] Camera mainCamera;
    [SerializeField] Transform target;

    [Header("Distance")]
    [SerializeField] float distanceToTarget = 10;
    [SerializeField] float minDistanceToTarget = 5;
    [SerializeField] float maxDistanceToTarget = 20;

    [Header("Rotation Speed")]
    [SerializeField]
    [Range(1, 360)] 
    float maxRotationInOneSwipe = 1;

    Vector3 _previousPosition;
    GraphicalRaycastScript graphicalRaycast;

    private void Start()
    {
        graphicalRaycast = GameObject.Find("GameUI").GetComponent<GraphicalRaycastScript>();

        if (graphicalRaycast == null)
            Debug.LogError("Graphical Raycaster not found");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !GameManager.Instance.CameraIsLocked)
        {
            _previousPosition = mainCamera.ScreenToViewportPoint(Input.mousePosition);

            var currentLayer = graphicalRaycast.GetCurrentLayer();
            if (currentLayer == null)
                GameManager.Instance.CameraIsLocked = false;
        }
        else if (Input.GetMouseButton(0) && !GameManager.Instance.CameraIsLocked && !GameManager.Instance.PanelChoosed)
            UpdateCameraPosition();

        // Mouse wheel input detector
        if (Input.GetAxis("Mouse ScrollWheel") > 0f && distanceToTarget > minDistanceToTarget) // forward
        {
            _previousPosition = mainCamera.ScreenToViewportPoint(Input.mousePosition);
            distanceToTarget -= 1;
            UpdateCameraPosition();
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f && distanceToTarget < maxDistanceToTarget) // backwards
        {
            _previousPosition = mainCamera.ScreenToViewportPoint(Input.mousePosition);
            distanceToTarget += 1;
            UpdateCameraPosition();
        }
    }

    void UpdateCameraPosition()
    {
        Vector3 newPosition = mainCamera.ScreenToViewportPoint(Input.mousePosition);
        Vector3 direction = _previousPosition - newPosition;

        // Horizontal camera moving
        float rotationAroundYAxis = -direction.x * maxRotationInOneSwipe;

        // Vertical camera moving
        float rotationAroundXAxis = direction.y * maxRotationInOneSwipe;

        mainCamera.transform.position = target.position;

        mainCamera.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);
        mainCamera.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World);

        mainCamera.transform.Translate(new Vector3(0, 0, -distanceToTarget));

        _previousPosition = newPosition;
    }
}
