using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    
    public float mouseSensitivity = 100f;

    float xRotation = 0f;
    float yRotation = 0f;

    // Creates a reference of the camera of the first person player, so it can rotate around

    private Transform playerBody;

    public Transform PlayerBody { get => playerBody; set => playerBody = value; }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X")
            * mouseSensitivity
            * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y")
            * mouseSensitivity
            * Time.deltaTime;
        yRotation += mouseX;
        xRotation = xRotation - mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0F, 0F);
        //transform.localRotation = Quaternion.Euler(xRotation, turn.x, 0);
        PlayerBody.Rotate(Vector3.up * mouseX);
        
    }
}
