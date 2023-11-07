using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    //public Sounds sounds;
    [HideInInspector]public AudioSource audioSource;
    public static SoundManager instance;
    void Awake()
    {
        if (instance == null) { instance = this; }
        audioSource = GetComponent<AudioSource>();
    }

    public void StopAllAudio()
    {
        audioSource.Stop();
    }
    public void PlayClipOneShot(AudioClip _clip)
    {
        if(audioSource.isPlaying)
        {
          //  print("audio stooped ");
            audioSource.Stop();
        }

        if (!audioSource.isPlaying)
        {
           // print("audio playing ");
            audioSource.PlayOneShot(_clip);
        }
    }

    public void PlayAudio(AudioClip _clip)
    {
        audioSource.clip = _clip;
        audioSource.Play();
    }
}