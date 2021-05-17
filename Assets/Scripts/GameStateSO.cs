using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameState", menuName = "ScriptableObject/GameState")]
public class GameStateSO : ScriptableObject
{

    public bool isTransitioning = false;
    public bool skipCollisions = false;

    public GameObject explosionParticle = null;

    public GameObject successParticle = null;

    public bool IsTransitioning { get => isTransitioning; set => isTransitioning = value; }
    public bool SkipCollisions { get => skipCollisions; set => skipCollisions = value; }

    public void ShowExplosionParticles(Transform targetTransform)
    {
        ShowParticleAtPoint(explosionParticle, targetTransform);
    }    
    
    public void ShowSuccessParticles(Transform targetTransform)
    {
        ShowParticleAtPoint(successParticle, targetTransform);
    }    
    
    public void ShowParticleAtPoint(GameObject particlesPrefab, Transform targetTransform)
    {
        var particles = Instantiate(particlesPrefab, targetTransform, false);
        var ps = particles.GetComponent<ParticleSystem>();
        ps.Play();
    }
}
