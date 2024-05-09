using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] audioClips;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio(int index)
    {
        if(index>=0 && index < audioClips.Length)
        {
            audioSource.PlayOneShot(audioClips[index]);
        }
    }
}
