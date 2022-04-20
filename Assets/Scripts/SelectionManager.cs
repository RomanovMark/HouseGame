using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [Header("Tag for selecting and material")]
    [SerializeField] string selectableTag = "Editable";
    [SerializeField] Material selectedMaterial;

    Material defaultObjMaterial;
    Material newMaterial;
    Transform selectedObject;

    public Material NewMaterial
    {
        set { newMaterial = value; }
    }

    void Update()
    {
        // Deselecting object logic
        if (selectedObject != null)
        {
            var selectedObjRenderer = selectedObject.GetComponent<Renderer>();
            if (selectedObjRenderer != null)
            {
                if (newMaterial != null)
                {
                    newMaterial.color = Color.white;
                    selectedObjRenderer.material = newMaterial;
                }
                else
                    selectedObjRenderer.material = defaultObjMaterial;

                selectedObject = null;
                newMaterial = null;
            }
            else
                Debug.LogError("Render component inside selected object not found.");
        }

        // Selecting object logic
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection != null && selection.CompareTag(selectableTag) && GameManager.Instance.CameraIsLocked)
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                defaultObjMaterial = selectionRenderer.material;

                if (selectionRenderer != null)
                    selectionRenderer.material = selectedMaterial;

                selectedObject = selection;
            }
        }
    }
}
