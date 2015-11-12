using UnityEngine;
using System.Collections;

public class CollisionSound : MonoBehaviour
{

    public AudioClip CollidingSound;
    public Transform listenerLocation;

    public float volumeScale = 1f;

    private AudioSource soundSource;
    private Rigidbody rigBody;
    private float velToVol = 0.2f;
    private float velocityClipSplit = 2f;

    // Use this for initialization
    void Start()
    {

    }


    void Awake()
    {
        soundSource = GetComponent<AudioSource>();
        rigBody = GetComponent<Rigidbody>();
    }


    void OnCollisionEnter (Collision coll)
    {
        // Adjust volume based on mass of object adding an adjustable scaling value
        float CollisionVolume = volumeScale * (rigBody.mass / 1000) ;

        if (coll.relativeVelocity.magnitude > velocityClipSplit)
            soundSource.PlayOneShot(CollidingSound, CollisionVolume);
    }

    
    void Update()
    {

    }


}