using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float mouseSensitivity = 2.0f;


    private CharacterController charController;
    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0.0f;
    private float rotationY = 0.0f;
    public bool inputReading;

    [SerializeField] private ExperimentManager _experimentManager;


    void Start()
    {
        charController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //moving: 
        if (charController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        rotationX += Input.GetAxis("Mouse X") * mouseSensitivity;
        rotationY += Input.GetAxis("Mouse Y") * mouseSensitivity;
        rotationY = Mathf.Clamp(rotationY, -90, 90);

        transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
        Camera.main.transform.localRotation = Quaternion.AngleAxis(-rotationY, Vector3.right);

        moveDirection.y -= gravity * Time.deltaTime;
        charController.Move(moveDirection * Time.deltaTime);



        if (Input.GetMouseButtonDown(0) && _experimentManager.isSpawnInProgress && inputReading)
        {
            _experimentManager.playerInputs.Add(1);
            inputReading = false;

        }
    }
}