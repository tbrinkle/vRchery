using System.Collections;
using System.Collections.Generic;
using System.Runtime.Versioning;
using UnityEngine;

public class ArrowWoosh : MonoBehaviour
{
    public static AudioClip arrowWooshSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        arrowWooshSound = Resources.Load<AudioClip>("Audio/woosh");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public static void playSound()
    {
        audioSrc.PlayOneShot(arrowWooshSound);
    }

}
