using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioScript : MonoBehaviour
{
    private AudioSource audioSource;

    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void GetCoin()
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
