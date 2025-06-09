using UnityEngine;

public class StickerEnterEffect : MonoBehaviour
{
    private RectTransform rectTransform;
    public float rotateSpeed = 360f;
    public float rotateDuration = 0.5f;
    private float timer = 0f;
    private bool rotating = true;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (rotating)
        {
            timer += Time.deltaTime;

            if (timer < rotateDuration)
            {
                rectTransform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
            }
            else
            {
                rotating = false;

                Vector3 currentRotation = rectTransform.localEulerAngles;
                currentRotation.z = Mathf.Round(currentRotation.z / 360f) * 360f;
                rectTransform.localEulerAngles = currentRotation;
            }
        }
    }
}
