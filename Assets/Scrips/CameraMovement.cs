using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform body;
    public Transform weapon;
    [SerializeField] float sensitivty;


    float rotateX;
    float rotateY;
    float mouseX;
    float mouseY;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    
    void Update()
    {
        
        GetMouseMoves();

        CameraRotation();
        //weapon.transform.rotation = Quaternion.Euler(rotateX, rotateY, 0);
        

    }

    private void CameraRotation()
    {
        rotateX -= mouseY;
        // How much can we look up (80) or down (90)
        rotateX = Mathf.Clamp(rotateX, -80f, 90f);
        
        body.Rotate(Vector3.up * mouseX);

        //rotateY += mouseX;
        transform.localRotation = Quaternion.Euler(rotateX, 0, 0);
    }

    private void GetMouseMoves()
    {
        mouseX = Input.GetAxisRaw("Mouse X") * sensitivty * Time.deltaTime;
        mouseY = Input.GetAxisRaw("Mouse Y") * sensitivty * Time.deltaTime;
    }
}
