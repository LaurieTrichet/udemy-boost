using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingZone : MonoBehaviour
{

    private SceneLoader sceneLoader;
    private Movement movement;
    private AudioSource audioSource;

    [SerializeField] GameStateSO gameState = null;


    private void Start()
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
            if (LayerHelper.AreLayerMatching(collision.gameObject.layer, "Player"))
            {
                gameState.ShowSuccessParticles(movement.gameObject.transform);
                audioSource.Play();
                movement.enabled = false;
                StartCoroutine(GoToNextScene());
            }
        }
    }

    IEnumerator GoToNextScene()
    {
        yield return new WaitForSecondsRealtime(1);
        sceneLoader.GoToNextScene();
    }
}
