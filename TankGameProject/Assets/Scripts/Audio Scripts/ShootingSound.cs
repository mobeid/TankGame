using UnityEngine;
using System.Collections;

public class ShootingSound : MonoBehaviour
{

    public float ShootVolume = 0.5f;
    public AudioClip FireSound;
    public AudioSource soundSource;

    // Use this for initialization
    void Awake()
    {

        soundSource = GetComponent<AudioSource>();
    }

    void Update()
    {

        // Shooting Shells
        if (Input.GetButtonDown("Jump"))
        {
            // Play sound
            soundSource.PlayOneShot(FireSound, ShootVolume);
        }


    }
}