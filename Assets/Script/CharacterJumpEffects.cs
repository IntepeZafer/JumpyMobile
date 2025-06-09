using UnityEngine;

public class CharacterJumpEffects : MonoBehaviour
{
    [Header("Kadın Karakter Ayarları")]
    public GameObject womanCharacter;
    public Animator womanAnimator;
    public string womanJumpTrigger = "isJumpingTwo";
    public AudioClip womanJumpSound;

    [Header("Erkek Karakter Ayarları")]
    public GameObject manCharacter;
    public Animator manAnimator;
    public string manJumpTrigger = "isJumpingOne";
    public AudioClip manJumpSound;

    [Header("Ortak Ayarlar")]
    public AudioSource audioSource;

    public void PlayJumpEffect()
    {
        if (womanCharacter.activeInHierarchy)
        {
            if (womanAnimator != null && !string.IsNullOrEmpty(womanJumpTrigger))
            {
                womanAnimator.ResetTrigger(womanJumpTrigger);
                womanAnimator.SetTrigger(womanJumpTrigger);
            }

            if (audioSource != null && womanJumpSound != null)
            {
                audioSource.PlayOneShot(womanJumpSound);
            }
        }
        else if (manCharacter.activeInHierarchy)
        {
            if (manAnimator != null && !string.IsNullOrEmpty(manJumpTrigger))
            {
                manAnimator.ResetTrigger(manJumpTrigger);
                manAnimator.SetTrigger(manJumpTrigger);
            }

            if (audioSource != null && manJumpSound != null)
            {
                audioSource.PlayOneShot(manJumpSound);
            }
        }
    }
}
