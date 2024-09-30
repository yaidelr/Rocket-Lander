using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{

    AudioSource audioSource;
    Rigidbody rb;
    [SerializeField] float mainThrust = 200;
    [SerializeField] float scright = 200;
    [SerializeField] float scleft  = 200;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        ProcessAudio();
    }

    void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
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

    private void ProcessAudio()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if(!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            else
            {
                audioSource.Stop();
            }
            
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            audioSource.Stop();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if(!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        

       
    }



}
