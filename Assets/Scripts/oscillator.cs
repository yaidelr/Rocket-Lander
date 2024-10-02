using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class oscillator : MonoBehaviour
{
UnityEngine.Vector3 startingPosition;
[SerializeField] UnityEngine.Vector3 movementVector;
[SerializeField] [Range(0,1)] float movementFactor;
[SerializeField] float period = 2f;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(period != 0) {
            float cycle = Time.time / period ;
            const float tau = Mathf.PI * 2 ;
            float sineWave = Mathf.Sin(cycle * tau);
            movementFactor = (sineWave +1f)/2;
       }

        UnityEngine.Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;

        
    }
}
