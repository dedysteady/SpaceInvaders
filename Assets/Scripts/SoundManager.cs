using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip _firePlayer;
    public AudioClip _fireEnemy;
    public AudioClip _explosion;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TembakanPlayer()
    {
        audioSource.PlayOneShot(_firePlayer);
    }

    public void TembakanEnemy()
    {
        audioSource.PlayOneShot(_fireEnemy);
    }

    public void Ledakan()
    {
        audioSource.PlayOneShot(_explosion);
    }

    public void LedakanEnemy()
    {
        audioSource.PlayOneShot(_explosion);
    }
}
