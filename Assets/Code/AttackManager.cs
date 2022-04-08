using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    private AudioSource audioSrc;
    void Start()
    {
        audioSrc = GetComponent<AudioSource> ();
    }

    void Update()
    {
        //walking sound
        if (Input.GetMouseButtonDown(1)){
            audioSrc.Play();
        }
    }
}

