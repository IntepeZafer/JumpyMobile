using UnityEngine;

public class CharacterJumpEffects : MonoBehaviour
{
    [Header("Kadın Karakter Ayarları")]
    public GameObject womanCharacter;
    public Animator womanAnimator;
    public string womanJumpTrigger = "isJumpingTwo";
    public AudioClip womanJumpSound;
    public AudioSource womanAudioSource;

    [Header("Erkek Karakter Ayarları")]
    public GameObject manCharacter;
    public Animator manAnimator;
    public string manJumpTrigger = "isJumpingOne";
    public AudioClip manJumpSound;
    public AudioSource manAudioSource;

    void Update()
    {
        // Mobil dokunma
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    HandleTouch(Camera.main.ScreenToWorldPoint(touch.position));
                }
            }
        }

#if UNITY_EDITOR
        // Editor için mouse kontrolü
        if (Input.GetMouseButtonDown(0))
        {
            HandleTouch(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
#endif
    }

    void HandleTouch(Vector3 touchWorldPos)
    {
        float screenMidY = Camera.main.orthographicSize; // Ekranın ortası, üst-alt ayrımı için
        float screenHeight = screenMidY * 2f;
        float screenMidX = Camera.main.aspect * Camera.main.orthographicSize;

        Vector3 touchViewportPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        if (touchViewportPos.y >= 0.5f) // Ekranın üst yarısı → Kadın karakter
        {
            TriggerJump(womanAnimator, womanJumpTrigger, womanAudioSource, womanJumpSound);
        }
        else // Alt yarısı → Erkek karakter
        {
            TriggerJump(manAnimator, manJumpTrigger, manAudioSource, manJumpSound);
        }
    }

    void TriggerJump(Animator animator, string triggerName, AudioSource audioSource, AudioClip jumpClip)
    {
        if (animator != null && !string.IsNullOrEmpty(triggerName))
        {
            animator.ResetTrigger(triggerName);
            animator.SetTrigger(triggerName);
        }

        if (audioSource != null && jumpClip != null)
        {
            audioSource.PlayOneShot(jumpClip);
        }
    }
}
