using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingZone : MonoBehaviour
{

    private SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (LayerHelper.AreLayerMatching(collision.gameObject.layer, "Player"))
        {
            sceneLoader.GoToNextScene();
        }
    }
}
