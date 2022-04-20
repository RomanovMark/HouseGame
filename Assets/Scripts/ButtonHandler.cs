using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public GameObject Panel;
    public bool isActive;
    public void OpenPanel()
    {
        if (Panel != null)
        {
            if (!isActive)
            {
                GameManager.Instance.PanelChoosed = true;
            }
            else
                GameManager.Instance.PanelChoosed = false;

            Panel.SetActive(!isActive);
        }
    }

}
