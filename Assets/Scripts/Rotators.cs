using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotators : MonoBehaviour
{

    [SerializeField] float speed = -0.5f;
    
    [SerializeField] float x =0f;
    [SerializeField] float y =0f;
    [SerializeField] float z =0f;
    
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(x * speed, y * speed, z * speed);
    }
}
