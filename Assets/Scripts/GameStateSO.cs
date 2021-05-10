using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameState", menuName = "ScriptableObject/GameState")]
public class GameStateSO : ScriptableObject
{

    [SerializeField] bool isTransitioning = false;

    [SerializeField] GameObject explosionParticle = null;

    public bool IsTransitioning { get => isTransitioning; set => isTransitioning = value; }

    public void ShowExplosionParticle(Transform targetTransform)
    {
        Debug.Log("show explosion particle" + targetTransform.position);
        Instantiate(explosionParticle, targetTransform, false);
    }
}
