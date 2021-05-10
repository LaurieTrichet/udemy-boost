using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    private SceneLoader sceneLoader;
    private Movement movement;
    private AudioSource audioSource;

    [SerializeField] GameStateSO gameState = null;

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        movement = FindObjectOfType<Movement>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!gameState.IsTransitioning)
        {
            gameState.IsTransitioning = true;
            movement.enabled = false;
            Debug.Log("play explosion");
            audioSource.Play();
            StartCoroutine(ReloadScene());
        }
    }

    IEnumerator ReloadScene()
    {
        yield return new WaitForSecondsRealtime(1);
        sceneLoader.ReloadScene();
    }
}
