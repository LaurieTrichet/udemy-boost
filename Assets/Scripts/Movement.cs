using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{

    private Vector3 cachedMovement;

    private Rigidbody playerRigidBody;

    public float thursters = 10;
    public float speed = 10;

    public Vector3 rotationStep = new Vector3(0, 0, 5);
    private Vector3 force;
    private bool shouldApplyForce;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var rotation = Vector3.Scale(rotationStep, cachedMovement);

        Rotate(rotation * Time.fixedDeltaTime * speed);
        if (shouldApplyForce)
        {
            playerRigidBody.AddRelativeForce(force);
        }
    }

    public void OnMove(InputAction.CallbackContext callbackContext)
    {
        var inputVector = callbackContext.ReadValue<Vector2>();
        var direction = inputVector.x;
        Debug.Log(inputVector.x);
        cachedMovement = Vector3.forward * direction;
    }

    public void OnFire(InputAction.CallbackContext callbackContext)
    {
        Debug.Log(callbackContext);
        force = Vector3.up * thursters;
        shouldApplyForce = callbackContext.performed;
        //playerRigidBody.AddRelativeForce(force, ForceMode.Impulse);
    }


    private void Rotate(Vector3 rotation)
    {
        Quaternion offsetRotation = Quaternion.Euler(rotation);
        Quaternion futurRotation = playerRigidBody.rotation * offsetRotation;
        playerRigidBody.MoveRotation(futurRotation);

    }

}
