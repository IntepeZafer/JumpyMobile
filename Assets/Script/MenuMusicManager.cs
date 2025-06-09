using UnityEngine;

public class MenuMusicManager : MonoBehaviour
{
    public AudioClip[] audioTracks;
    private AudioSource audioSource;
    private int lastTrackIndex = -1;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        PlayRandomTrack();
    }
    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayRandomTrack();
        }
    }
    void PlayRandomTrack() 
    {
        if(audioTracks.Length == 0)
        {
            return;
        }
        int newIndex;
        do
        {
            newIndex = Random.Range(0, audioTracks.Length);
        } while (newIndex == lastTrackIndex && audioTracks.Length > 1);
        lastTrackIndex = newIndex;
        audioSource.clip = audioTracks[newIndex];
        audioSource.Play();
    }
}
