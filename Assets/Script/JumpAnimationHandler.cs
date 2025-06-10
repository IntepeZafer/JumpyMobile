using UnityEngine;
using System.Collections;
public class JumpAnimationHandler : MonoBehaviour
{
    [Header("PlayerOne Character Animation")]
    public Animator playerOneAnimator;
    public string playerOneJumpTrigger = "isJumpingOne";

    [Header("PlayerTwo Character Animation")]
    public Animator playerTwoAnimator;
    public string playerTwoJumpTrigger = "isJumpingTwo";

    [Header("Animation Settings")]
    public float jumpCooldown = 0.5f; // Animasyonun tekrar tetiklenebilmesi için bekleme süresi

    private bool isPlayerOneJumping = false;
    private bool isPlayerTwoJumping = false;

    void Update()
    {
        HandleTouch();
    }

    void HandleTouch()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    float middleX = Screen.width / 2f;

                    if (touch.position.x < middleX)
                    {
                        if (!isPlayerOneJumping)
                        {
                            TriggerAnimation(playerOneAnimator, playerOneJumpTrigger);
                            isPlayerOneJumping = true;
                            StartCoroutine(ResetJumpFlag(1));
                        }
                    }
                    else
                    {
                        if (!isPlayerTwoJumping)
                        {
                            TriggerAnimation(playerTwoAnimator, playerTwoJumpTrigger);
                            isPlayerTwoJumping = true;
                            StartCoroutine(ResetJumpFlag(2));
                        }
                    }
                }
            }
        }

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            float middleX = Screen.width / 2f;

            if (Input.mousePosition.x < middleX)
            {
                if (!isPlayerOneJumping)
                {
                    TriggerAnimation(playerOneAnimator, playerOneJumpTrigger);
                    isPlayerOneJumping = true;
                    StartCoroutine(ResetJumpFlag(1));
                }
            }
            else
            {
                if (!isPlayerTwoJumping)
                {
                    TriggerAnimation(playerTwoAnimator, playerTwoJumpTrigger);
                    isPlayerTwoJumping = true;
                    StartCoroutine(ResetJumpFlag(2));
                }
            }
        }
#endif
    }

    void TriggerAnimation(Animator animator, string triggerName)
    {
        if (animator != null && !string.IsNullOrEmpty(triggerName))
        {
            animator.ResetTrigger(triggerName);
            animator.SetTrigger(triggerName);
            Debug.Log($"Animation Triggered: {triggerName}");
        }
    }

    IEnumerator ResetJumpFlag(int playerNumber)
    {
        yield return new WaitForSeconds(jumpCooldown);
        if (playerNumber == 1)
        {
            isPlayerOneJumping = false;
        }
        else if (playerNumber == 2)
        {
            isPlayerTwoJumping = false;
        }
    }
}
