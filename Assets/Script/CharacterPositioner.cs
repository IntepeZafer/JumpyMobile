using UnityEngine;

public class CharacterPositioner : MonoBehaviour
{
    public Vector2 viewportPosition = new Vector2(0.1f, 0.1f);

    private void Start()
    {
        Camera cam = Camera.main;
        Vector3 targetPosition = cam.ViewportToWorldPoint(new Vector3(viewportPosition.x, viewportPosition.y, cam.nearClipPlane +10f));
        targetPosition.z = 0f; 
        transform.position = targetPosition;
    }
}
