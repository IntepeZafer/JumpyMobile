using UnityEngine;

public class DualCharacterJumpController : MonoBehaviour
{
    [Header("Karakterler")]
    public Transform topCharacter;
    public Transform bottomCharacter;

    public float jumpHeight = 2f;
    public float jumpSpeed = 2f;
    public float verticalMargin = 0.5f;

    private Vector3 topStartPos;
    private Vector3 bottomStartPos;

    private bool isTopJumping = false;
    private bool isBottomJumping = false;

    private float topProgress = 0f;
    private float bottomProgress = 0f;

    private float cameraTop;
    private float cameraBottom;

    void Start()
    {
        float orthoSize = Camera.main.orthographicSize;
        cameraTop = orthoSize;
        cameraBottom = -orthoSize;

        topStartPos = ClampY(topCharacter.position, verticalMargin);
        bottomStartPos = ClampY(bottomCharacter.position, verticalMargin);

        topCharacter.position = topStartPos;
        bottomCharacter.position = bottomStartPos;
    }

    void Update()
    {
        HandleTouch();

        if (isTopJumping)
        {
            topProgress += Time.deltaTime * jumpSpeed;
            float offsetY = Mathf.Sin(topProgress * Mathf.PI) * -jumpHeight; // aşağı zıplama
            float newY = topStartPos.y + offsetY;
            newY = Mathf.Clamp(newY, cameraBottom + verticalMargin, cameraTop - verticalMargin);
            topCharacter.position = new Vector3(topStartPos.x, newY, topStartPos.z);

            if (topProgress >= 1f)
            {
                isTopJumping = false;
                topCharacter.position = topStartPos;
            }
        }

        if (isBottomJumping)
        {
            bottomProgress += Time.deltaTime * jumpSpeed;
            float offsetY = Mathf.Sin(bottomProgress * Mathf.PI) * jumpHeight; // yukarı zıplama
            float newY = bottomStartPos.y + offsetY;
            newY = Mathf.Clamp(newY, cameraBottom + verticalMargin, cameraTop - verticalMargin);
            bottomCharacter.position = new Vector3(bottomStartPos.x, newY, bottomStartPos.z);

            if (bottomProgress >= 1f)
            {
                isBottomJumping = false;
                bottomCharacter.position = bottomStartPos;
            }
        }
    }

    void HandleTouch()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch t in Input.touches)
            {
                if (t.phase == TouchPhase.Began)
                {
                    float middle = Screen.width / 2f;

                    if (t.position.x < middle && !isTopJumping)
                    {
                        topStartPos = ClampY(topCharacter.position, verticalMargin);
                        isTopJumping = true;
                        topProgress = 0f;
                    }
                    else if (t.position.x >= middle && !isBottomJumping)
                    {
                        bottomStartPos = ClampY(bottomCharacter.position, verticalMargin);
                        isBottomJumping = true;
                        bottomProgress = 0f;
                    }
                }
            }
        }
    }

    Vector3 ClampY(Vector3 pos, float margin)
    {
        float y = Mathf.Clamp(pos.y, cameraBottom + margin, cameraTop - margin);
        return new Vector3(pos.x, y, pos.z);
    }
}
