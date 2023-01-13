using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : SingletonClass<UiManager>
{
    [SerializeField] private UiAnimation uiAnim;
    [SerializeField] private CanvasGroup operationUI;
    [SerializeField] private CanvasGroup messageUI;
    [SerializeField] private CanvasGroup passwordUI;

    private const string DefaultOperationMsg = "(�����ɑ������)";
    private const string DefaultMessageMsg = "(�����Ƀ��b�Z�[�W)";

    private TextMeshProUGUI operationText;
    private TextMeshProUGUI messageText;

    private void Start()
    {
        operationUI.alpha = 0f;
        messageUI.alpha = 0f;
        passwordUI.alpha = 0f;

        operationText = operationUI.GetComponentInChildren<TextMeshProUGUI>();
        messageText = messageUI.GetComponentInChildren<TextMeshProUGUI>();

        Application.targetFrameRate = 60; // TODO:��ōX�ɑ��������N���X���Ɉړ�������
    }

    public void EnableUI(UIType type, string msg = null)
    {
        if(IsEnableUI(type) == true)
        {
            if (type == UIType.Operation) uiAnim.ForceDisableUI(operationUI);
            else if (type == UIType.Message) uiAnim.ForceDisableUI(messageUI);
            else if (type == UIType.Password) uiAnim.ForceDisableUI(passwordUI);
        }

        if (type == UIType.Operation)
        {
            operationText.text = msg ?? DefaultOperationMsg;
            uiAnim.EnableUI(operationUI);
        }
        else if (type == UIType.Message)
        {
            messageText.text = msg ?? DefaultMessageMsg;
            uiAnim.EnableUI(messageUI);
        }
        else if (type == UIType.Password) uiAnim.EnableUI(passwordUI);
    }

    public void DisableUI(UIType type)
    {
        if (type == UIType.Operation) uiAnim.DisableUI(operationUI);
        else if (type == UIType.Message) uiAnim.DisableUI(messageUI);
        else if (type == UIType.Password) uiAnim.DisableUI(passwordUI);
    }

    private bool IsEnableUI(UIType type)
    {
        if (type == UIType.Operation) return operationUI.alpha > float.Epsilon;
        else if (type == UIType.Message) return messageUI.alpha > float.Epsilon;
        else if (type == UIType.Password) return passwordUI.alpha > float.Epsilon;
        return false;
    }
}
