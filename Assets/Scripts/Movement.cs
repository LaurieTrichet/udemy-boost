using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{

    private Vector3 cachedMovement;

    private Rigidbody playerRigidBody;

    public float thursters = 10;
    public float rotationSpeed = 10;

    public Vector3 rotationStep = new Vector3(0, 0, 5);
    private Vector3 force;
    private bool shouldApplyForce;

    private AudioSource audioSource = null;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var rotation = Vector3.Scale(rotationStep, cachedMovement);

        Rotate(rotation * Time.fixedDeltaTime * rotationSpeed);
        if (shouldApplyForce)
        {
            playerRigidBody.AddRelativeForce(force * Time.deltaTime);
        }
    }

    public void OnMove(InputAction.CallbackContext callbackContext)
    {
        var inputVector = callbackContext.ReadValue<Vector2>();
        var direction = -1 * inputVector.x;
        //Debug.Log(inputVector.x);
        cachedMovement = Vector3.forward * direction;
    }

    public void OnFire(InputAction.CallbackContext callbackContext)
    {
        //Debug.Log(callbackContext);
        force = Vector3.up * thursters;
        shouldApplyForce = callbackContext.performed;
        if (callbackContext.canceled)
        {
            CancelSFX();
                Debug.Log("cancel audio");
        } else
        {
            PlaySFX();
        }
    }

    private void PlaySFX()
    {
        if (shouldApplyForce)
        {
            if (!audioSource.isPlaying)
            {
                Debug.Log("play audio");
                audioSource.Play();
            }
        }
    }


    private void CancelSFX()
    {
        audioSource.Stop();
    }

    private void Rotate(Vector3 rotation)
    {
        Quaternion offsetRotation = Quaternion.Euler(rotation);
        Quaternion futurRotation = playerRigidBody.rotation * offsetRotation;
        playerRigidBody.MoveRotation(futurRotation);

    }

}
