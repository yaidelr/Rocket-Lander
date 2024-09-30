using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField] float mainThrust = 200;
    [SerializeField] float scright = 200;
    [SerializeField] float scleft  = 200;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Space pressed: ");
            rb.AddRelativeForce(Vector3.up * Time.deltaTime * mainThrust );
            
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.freezeRotation = true;
            transform.Rotate(Vector3.forward * Time.deltaTime * scright);
            rb.freezeRotation = false;
            
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.freezeRotation = true;
            transform.Rotate(Vector3.back * Time.deltaTime * scleft); 
            rb.freezeRotation = false;
        }

    }




}
