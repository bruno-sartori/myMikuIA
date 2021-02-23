using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour {
    public float mouseSensitivityX = 850f;
    public float mouseSensitivityY = 850f;
    public float walkSpeed = 8f;

    Transform cameraT;
    float verticalLookRotation;
    
    Vector3 moveAmount;
    Vector3 smoothMoveVelocity;

    void MoveCamera() {
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivityX);
        verticalLookRotation += Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivityY;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -60, 60);
        cameraT.localEulerAngles = Vector3.left * verticalLookRotation;
    }

    void Start() {
        cameraT = Camera.main.transform;
    }

    void Update() {
        this.MoveCamera();

        Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        Vector3 targetMoveAmount = moveDir * walkSpeed;
        moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);
    }

    void FixedUpdate() {
        Rigidbody rgbd = GetComponent<Rigidbody>();
        rgbd.MovePosition(rgbd.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
    }
}
