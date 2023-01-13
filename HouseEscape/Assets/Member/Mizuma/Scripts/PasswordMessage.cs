using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PasswordMessage : MonoBehaviour
{
    [SerializeField] private Button okButton;
    [SerializeField] private Button cancelButton;
    [SerializeField] private TMP_InputField passwordField;

    private const string Pass = "password";

    private const string OkMessage = "³‰ðI";
    private const string CancelMessage = "ˆá‚Á‚½‚æ‚¤‚¾";

    public void Start()
    {
        okButton.onClick.AddListener(() =>
        {
            if (string.Equals(passwordField.text, Pass) == true) UiManager.Instance.EnableUI(UIType.Message, OkMessage);
            else UiManager.Instance.EnableUI(UIType.Message, CancelMessage);
        });
        cancelButton.onClick.AddListener(() =>
        {
            UiManager.Instance.DisableUI(UIType.Password);
            UiManager.Instance.DisableUI(UIType.Message);
        });
    }
}