using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] List<GameObject> ScrollViewPanels;

    object[] allButtons;
    List<Button> buttonList = new List<Button>();

    private void Start()
    {
        allButtons = FindObjectsOfType(typeof(Button));

        if (allButtons.Any())
        {
            foreach (var item in allButtons)
            {
                var tempButton = item as Button;
                var eventComponentName = tempButton.name.Split(' ').FirstOrDefault();

                // Get panel for activation
                var panel = ScrollViewPanels.FirstOrDefault(x => x.name.Contains(eventComponentName));

                if (panel != null)
                {
                    // Add button click handler
                    tempButton.onClick.AddListener(() => ClickButtonHandler(panel));

                    // Add button to list
                    buttonList.Add(tempButton);
                }
                else
                    Debug.LogError($"Panel {eventComponentName} not found! Click event not added!");

            }
        }

        void ClickButtonHandler(GameObject workingPanel)
        {
            // Check, if some panel is active
            foreach (var panel in ScrollViewPanels)
            {
                if (panel.activeSelf && workingPanel.name != panel.name)
                    panel.SetActive(false);
            }

            workingPanel.SetActive(!workingPanel.activeSelf);
        }
    }
}
