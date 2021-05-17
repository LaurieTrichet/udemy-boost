using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{

    [SerializeField] Vector3 movementVector = Vector3.up;

    [SerializeField] [Range (1,2)]float period = 2f;
    private Vector3 offset;
    private Vector3 min;
    private Vector3 max;
    private Vector3 startingPosition;
    private float tau;


    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        ComputeOffset();
        min = startingPosition - offset;
        max = startingPosition + offset;
        Debug.Log(min);
        Debug.Log(max);

        tau = Mathf.PI * 2;
    }


    private void FixedUpdate()
    {

        ComputeOffset();
        ApplyOffsetToPosition();
    }

    private void ApplyOffsetToPosition()
    {
        transform.position = startingPosition + offset;
    }

    private void ComputeOffset()
    {
        var cycles = Time.time / period; // Counting the number of cycles as the time passes
        var rawSinWave = Mathf.Sin(cycles * tau); // Get x for the cycles number * radians in a circles
        var movementFactor = (rawSinWave + 1f) / 2f; // move the interval from 0 to period instead of [-1;1]
        offset = movementVector *  movementFactor;
        Debug.Log(offset);
    }
}
