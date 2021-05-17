using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private float direction;
    private Vector3 cachedMovement;

    private Rigidbody playerRigidBody;

    public float thursters = 10;
    public float rotationSpeed = 10;

    public Vector3 rotationStep = new Vector3(0, 0, 5);
    private Vector3 force;
    private bool shouldApplyForce;

    [SerializeField] ParticleSystem leftThruster = null;
    [SerializeField] ParticleSystem rightThruster = null;
    [SerializeField] ParticleSystem mainThruster = null;

    private AudioSource audioSource = null;

    private SceneLoader sceneLoader = null;
    private BoxCollider boxCollider = null;

    [SerializeField] GameStateSO gameState = null;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        sceneLoader = FindObjectOfType<SceneLoader>();
        boxCollider = FindObjectOfType<BoxCollider>();        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var rotation = Vector3.Scale(rotationStep, cachedMovement);

        Rotate(rotation * Time.fixedDeltaTime * rotationSpeed);
        if (shouldApplyForce)
        {
            if(direction == -1)
            {
                leftThruster.Play();
            }
            else if (direction == 1)
            {
                rightThruster.Play();
            }
            playerRigidBody.AddRelativeForce(force * Time.deltaTime);
        } else
        {
            rightThruster.Stop();
            leftThruster.Stop();
        }
    }

    public void OnGoToNextLevel(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            sceneLoader.GoToNextScene();
        }
    }    
    
    public void OnToggleCollision(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            gameState.SkipCollisions = !gameState.SkipCollisions;
        }
    }    
    public void OnMove(InputAction.CallbackContext callbackContext)
    {
        var inputVector = callbackContext.ReadValue<Vector2>();
        direction = -1 * inputVector.x;
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
            mainThruster.Stop();
            //Debug.Log("cancel audio");
        } else
        {
            mainThruster.Play();
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
