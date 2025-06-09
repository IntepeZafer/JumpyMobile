using System.Collections;
using UnityEngine;

public class OnClickPunch : MonoBehaviour
{
    public AudioClip[] clickSounds;
    private AudioSource audioSource;

    private void Awake() 
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void OnClickPunchButton()
    {
        StartCoroutine(PuncButtonClick());
    }

    IEnumerator PuncButtonClick()
    {
        PlayRandomClickSound();
        Vector3 originalScale = transform.localScale;
        transform.localScale = originalScale * 0.9f;
        yield return new WaitForSeconds(0.1f);
        transform.localScale = originalScale;

    }
    public void PlayRandomClickSound()
    {
        if(clickSounds.Length > 0 && audioSource != null)
        {
            int index = Random.Range(0, clickSounds.Length);
            audioSource.PlayOneShot(clickSounds[index]);
        }
    }
}
