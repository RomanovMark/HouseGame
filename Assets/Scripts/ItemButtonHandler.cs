using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemButtonHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] ItemData data;
    [SerializeField] RectTransform canvas;
    [SerializeField] RectTransform uiDragElement;
    [SerializeField] RectTransform contentPanel;

    Vector2 originalLocalPointerPosition;
    Vector2 originalPosition;
    Vector3 originalPanelLocalPosition;

    GameObject parentObject;

    int objectIndex;
    readonly float time = 0.5f;

    void Start()
    {
        originalPosition = uiDragElement.localPosition;
        parentObject = transform.parent.gameObject;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPanelLocalPosition = uiDragElement.localPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas,
            eventData.position,
            eventData.pressEventCamera,
            out originalLocalPointerPosition);

        // Change parent object
        GameManager.Instance.CameraIsLocked = true;

        if (parentObject == null)
            Debug.LogError("Parent object not found");
        else
        {
            // GET current object index
            objectIndex = parentObject.transform.GetSiblingIndex();
            parentObject.transform.SetParent(GameManager.Instance.GeneralUIPanel.transform);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 localPointerPosition;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
           canvas,
      eventData.position,
            eventData.pressEventCamera,
       out localPointerPosition))
        {
            Vector3 offsetToOriginal = localPointerPosition - originalLocalPointerPosition;
            uiDragElement.localPosition = originalPanelLocalPosition + offsetToOriginal;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        StartCoroutine(MoveUIElement(uiDragElement, originalPosition, time));

        // Create and config ray
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Shoot ray and get hitting object
        if (Physics.Raycast(ray, out hit, 1000f) && hit.collider.tag.Equals("Editable"))
            ApplayTexture(hit.collider.gameObject);

        // Set child object back, to content parent object
        StartCoroutine(WaitSeconds(time));
    }

    public IEnumerator MoveUIElement(RectTransform uiElement, Vector2 targetPosition, float duration = 0.1f)
    {
        float elapsedTime = 0;
        Vector2 startPos = uiElement.localPosition;

        while (elapsedTime < duration)
        {
            uiElement.localPosition = Vector2.Lerp(startPos, targetPosition, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        uiElement.localPosition = targetPosition;
    }

    public IEnumerator WaitSeconds(float waitSeconds)
    {
        yield return new WaitForSeconds(waitSeconds);
        parentObject.transform.SetParent(contentPanel.transform);
        parentObject.transform.SetSiblingIndex(objectIndex);
        GameManager.Instance.CameraIsLocked = false;
    }

    public void ApplayTexture(GameObject targetObject)
    {
        var targetRenderer = targetObject.GetComponent<Renderer>();
        targetRenderer.material.mainTexture = data.ItemTexture;

        GameManager.Instance.SelectionManager.GetComponent<SelectionManager>().NewMaterial = targetRenderer.material;
    }
}
