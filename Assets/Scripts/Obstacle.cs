using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    private SceneLoader sceneLoader;
    private Movement movement;
    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        movement = FindObjectOfType<Movement>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        movement.enabled = false;
       
        StartCoroutine(ReloadScene());
    }

    IEnumerator ReloadScene()
    {
        yield return new WaitForSecondsRealtime(1);
        sceneLoader.ReloadScene();
    }
}
