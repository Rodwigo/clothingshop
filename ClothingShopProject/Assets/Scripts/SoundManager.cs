using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip sfx1, sfx2, sfx3, sfx4, sfx5;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        sfx1 = Resources.Load<AudioClip>("SFX1");
        sfx2 = Resources.Load<AudioClip>("SFX2");
        sfx3 = Resources.Load<AudioClip>("SFX3");
        sfx4 = Resources.Load<AudioClip>("SFX4");
        sfx5 = Resources.Load<AudioClip>("SFX5");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "sfx1":
                audioSrc.PlayOneShot(sfx1);
                break;
            case "sfx2":
                audioSrc.PlayOneShot(sfx2);
                break;
            case "sfx3":
                audioSrc.PlayOneShot(sfx3);
                break;
            case "sfx4":
                audioSrc.PlayOneShot(sfx4);
                break;
            case "sfx5":
                audioSrc.PlayOneShot(sfx5);
                break;
        }
    }
}
