using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Vector3 = UnityEngine.Vector3;

public class Booster : MonoBehaviour
{
    private Rigidbody rocketBody;
    private AudioSource thrustSound;

    [SerializeField] float rotationSpeed;
    [SerializeField] float forcePower;

    // Start is called before the first frame update
    void Start()
    {
        
        rocketBody = GetComponent<Rigidbody>();
        thrustSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    void ProcessInput()
    {
        Thrust();
        Rotate();
    }

    private void Rotate()
    {
        rocketBody.freezeRotation = true;
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward, rotationSpeed * Time.deltaTime);
        }

        rocketBody.freezeRotation = false;
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rocketBody.AddRelativeForce(Vector3.up * forcePower);
            if (!thrustSound.isPlaying)
            {
                thrustSound.Play();
            }
        }
        else
        {
            thrustSound.Stop();
        }
    }
}