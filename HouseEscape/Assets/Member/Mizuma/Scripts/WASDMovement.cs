using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDMovement : MonoBehaviour
{
    private const float Speed = 7f;

    private Transform myTransform = null;

    [SerializeField] private Transform targetDirection;

    private void Start()
    {
        myTransform = this.transform;
    }

    private void Update()
    {
        Vector3 moveVec = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) moveVec += Vector3.forward;
        if (Input.GetKey(KeyCode.A)) moveVec += Vector3.left;
        if (Input.GetKey(KeyCode.S)) moveVec += Vector3.back;
        if (Input.GetKey(KeyCode.D)) moveVec += Vector3.right;

        if (moveVec == Vector3.zero) return;

        moveVec = (targetDirection.localRotation * moveVec.normalized) * Speed * Time.deltaTime;
        moveVec.y = 0f;
        myTransform.position += moveVec;
    }
}
