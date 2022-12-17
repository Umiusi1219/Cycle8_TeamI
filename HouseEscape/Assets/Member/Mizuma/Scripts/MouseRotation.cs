using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotation : MonoBehaviour
{
    private const float Sensitivity = 350f;
    private const float LowerRotLimit = 25f;
    private const float UpperRotLimit = 45f;

    private Transform myTransform;

    private void Start()
    {
        myTransform = this.transform;
    }

    void Update()
    {
        Vector2 mouseAxis = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        if (mouseAxis == Vector2.zero) return;

        float deltaTime = Time.deltaTime;

        Vector3 afterRot = myTransform.localEulerAngles;
        afterRot.x += mouseAxis.y * -1f * Sensitivity * deltaTime;
        if (afterRot.x > LowerRotLimit && afterRot.x < 180) afterRot.x = LowerRotLimit;
        if (afterRot.x < 360 - UpperRotLimit && afterRot.x > 180) afterRot.x = 360 - UpperRotLimit;

        afterRot.y += mouseAxis.x * Sensitivity * deltaTime;

        afterRot.z = 0f;
        myTransform.localEulerAngles = afterRot;

    }
}
