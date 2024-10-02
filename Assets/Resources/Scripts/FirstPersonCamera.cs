using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public float mouseSens;
    public Transform playerTransform;

    private float mouseYRotation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //Desaparece el mouse, ,.confined te confina el mouse haciendo que no puedas salir de los bordes
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        mouseYRotation -= mouseY;

        if( mouseYRotation >= 90 || mouseYRotation <= -90)
        {
            mouseYRotation = Mathf.Clamp(mouseYRotation, -90, 90);
        }

        transform.localEulerAngles = Vector3.right * mouseYRotation;

        playerTransform.Rotate(Vector3.up * mouseX);
    }
}
