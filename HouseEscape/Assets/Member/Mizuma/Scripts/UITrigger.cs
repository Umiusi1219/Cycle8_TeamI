using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITrigger : MonoBehaviour
{
    [SerializeField] private UIType uiType;
    [SerializeField] private string printMessage;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (string.IsNullOrEmpty(printMessage) == false) UiManager.Instance.EnableUI(uiType, printMessage);
            else UiManager.Instance.EnableUI(uiType);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UiManager.Instance.DisableUI(uiType);
        }
    }
}
