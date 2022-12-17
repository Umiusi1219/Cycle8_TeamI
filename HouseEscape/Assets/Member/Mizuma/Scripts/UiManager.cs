using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : SingletonClass<UiManager>
{
    [SerializeField] private CanvasGroup operationUI;
    [SerializeField] private CanvasGroup messageUI;
    [SerializeField] private CanvasGroup passwordUI;
}
