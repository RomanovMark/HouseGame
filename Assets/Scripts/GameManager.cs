using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Panels for DragNDrop")]
    [SerializeField] GameObject generalUIPanel;

    [Header("Managers references")]
    [SerializeField] GameObject selectionManager;

    public bool CameraIsLocked { get; set; }
    public bool PanelChoosed { get; set; }

    public GameObject GeneralUIPanel
    {
        get { return generalUIPanel; }
    }
    public GameObject SelectionManager
    {
        get { return selectionManager; }
    }

    static GameManager _instance;
    public static GameManager Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
