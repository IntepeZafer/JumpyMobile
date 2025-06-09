using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class StickerMotionEffect : MonoBehaviour
{
    private enum MotionType { Bounce, Wobble, Zigzag, Pulse, SpinInOut, Wave, Shake, FloatFade }
    private MotionType selectedMotion;
    private float timeOffset;
    private Vector3 startPos;
    private Vector3 startScale;
    private CanvasGroup canvasGroup;

    void Start()
    {
        selectedMotion = (MotionType)Random.Range(0, System.Enum.GetValues(typeof(MotionType)).Length);
        timeOffset = Random.Range(0f, 100f);
        startPos = transform.localPosition;
        startScale = transform.localScale;
        canvasGroup = GetComponent<CanvasGroup>();
    }

    void Update()
    {
        float t = Time.time + timeOffset;

        switch (selectedMotion)
        {
            case MotionType.Bounce:
                transform.localPosition = startPos + new Vector3(0f, Mathf.Sin(t * 5f) * 10f, 0f);
                break;

            case MotionType.Wobble:
                transform.localRotation = Quaternion.Euler(0f, 0f, Mathf.Sin(t * 6f) * 15f);
                break;

            case MotionType.Zigzag:
                transform.localPosition = startPos + new Vector3(Mathf.Sin(t * 4f) * 10f, 0f, 0f);
                break;

            case MotionType.Pulse:
                float scale = 1 + Mathf.Sin(t * 5f) * 0.1f;
                transform.localScale = startScale * scale;
                break;

            case MotionType.SpinInOut:
                transform.localRotation = Quaternion.Euler(0f, 0f, t * 100f);
                float spinScale = 1 + Mathf.Sin(t * 3f) * 0.1f;
                transform.localScale = startScale * spinScale;
                break;

            case MotionType.Wave:
                transform.localPosition = startPos + new Vector3(Mathf.Sin(t * 2f) * 5f, Mathf.Cos(t * 2f) * 5f, 0f);
                break;

            case MotionType.Shake:
                transform.localPosition = startPos + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
                break;

            case MotionType.FloatFade:
                transform.localPosition = startPos + new Vector3(0f, (t % 1f) * 20f, 0f);
                if (canvasGroup != null)
                {
                    canvasGroup.alpha = 1f - (t % 1f);
                }
                break;
        }
    }
}