using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingZone : MonoBehaviour
{

    private SceneLoader sceneLoader;
    private Movement movement;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        movement = FindObjectOfType<Movement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (LayerHelper.AreLayerMatching(collision.gameObject.layer, "Player"))
        {
            
            movement.enabled = false;
            StartCoroutine(GoToNextScene());
        }
    }

    IEnumerator GoToNextScene()
    {
        yield return new WaitForSecondsRealtime(1);
        sceneLoader.GoToNextScene();
    }
}
