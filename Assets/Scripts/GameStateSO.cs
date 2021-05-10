using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameState", menuName = "ScriptableObject/GameState")]
public class GameStateSO : ScriptableObject
{

    [SerializeField] bool isTransitioning = false;

    public bool IsTransitioning { get => isTransitioning; set => isTransitioning = value; }
}
