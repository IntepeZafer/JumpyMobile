using UnityEngine;

public class CharactersJumpSound : MonoBehaviour
{
    [Header("PlayerOne Character Sound")]
    public AudioClip playerOneJumpSound;

    [Header("PlayerTwo Character Sound")]
    public AudioClip playerTwoJumpSound;

    public AudioSource audioSource;

    private void Update()
    {
        HandleTouch();
    }

    void HandleTouch()
    {
        if(Input.touchCount > 0)
        {
            foreach(Touch touch in Input.touches)
            {
                if(touch.phase == TouchPhase.Began)
                {
                    float middleX = Screen.width / 2f;
                    if(touch.position.x < middleX)
                    {
                        PlaySound(playerOneJumpSound);
                    }
                    else
                    {
                        PlaySound(playerTwoJumpSound);
                    }
                }
            }
        }
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            float middleX = Screen.width / 2f;
            if(Input.mousePosition.x < middleX)
            {
                PlaySound(playerOneJumpSound);
            }
            else 
            {
                PlaySound(playerTwoJumpSound);
            }
        }
    #endif
    }
    void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
