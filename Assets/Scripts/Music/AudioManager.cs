using UnityEngine.Audio;
using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] AudioSource walkSource;
    [SerializeField] List<AudioClip> walkClips = new List<AudioClip>(); 
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void WalkSfx()
    {
        AudioClip clip = walkClips[Random.Range(0, walkClips.Count)];

        walkSource.PlayOneShot(clip);
    }
}
