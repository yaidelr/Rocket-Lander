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
    [SerializeField] AudioClip bost;
    [SerializeField] AudioClip smallbosters;
    [SerializeField] ParticleSystem booster;
    [SerializeField] ParticleSystem leftBooster;
    [SerializeField] ParticleSystem rightBooster;

   
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //sound
        audioSource = GetComponent<AudioSource>();

        //particles
        booster = GameObject.Find("boster").GetComponent<ParticleSystem>();
        leftBooster = GameObject.Find("left booster").GetComponent<ParticleSystem>();
        rightBooster = GameObject.Find("right booster").GetComponent<ParticleSystem>();
        
    }

    void Update()
    {
        ProcessInput();
        ProcessAudio();
    }

    void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Trust();
        }

        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();

        }

        if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }

    }

    private void Trust()
    {
        rb.AddRelativeForce(Vector3.up * Time.deltaTime * mainThrust);
        booster.Play();
    }

    private void RotateRight()
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.back * Time.deltaTime * scleft);
        rb.freezeRotation = false;

        rightBooster.Play();
    }

    private void RotateLeft()
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * Time.deltaTime * scright);
        rb.freezeRotation = false;

        leftBooster.Play();
    }

    private void ProcessAudio()
    {
        Spaceinput();
        Ainput();
        Dinput();

    }

    private void Spaceinput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(bost);
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
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(bost);
            }
        }       
    }

    private void Ainput()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(smallbosters);
            }
            else
            {
                audioSource.Stop();
            }

        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            audioSource.Stop();
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(smallbosters);
            }
        }       
    }

    private void Dinput()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(smallbosters);
            }
            else
            {
                audioSource.Stop();
            }

        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            audioSource.Stop();
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(smallbosters);
            }
        }       
    }

}
