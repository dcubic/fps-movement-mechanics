using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public Transform playerContainer;

    private float sensitivity = 40f;
    private float xAxisRotationalLimit = 90f;
    private float xAxisRotation = 0f;

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update() {
        float xMouseMovement = Input.GetAxisRaw("Mouse X") * Time.fixedDeltaTime * sensitivity;
        float yMouseMovement = Input.GetAxisRaw("Mouse Y") * Time.fixedDeltaTime * sensitivity;

        xAxisRotation -= yMouseMovement;
        xAxisRotation = Mathf.Clamp(xAxisRotation, -xAxisRotationalLimit, xAxisRotationalLimit);

        transform.localRotation = Quaternion.Euler(xAxisRotation, 0f, 0f);
        playerContainer.Rotate(new Vector3(0, xMouseMovement, 0));
    }
}
