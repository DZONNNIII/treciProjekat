using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript2 : MonoBehaviour
{
    public AudioSource audioSource;
    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Obstacle()
    {
        audioSource.Play();
    }
    void Start()
    {

    }


    void Update()
    {

    }
}
