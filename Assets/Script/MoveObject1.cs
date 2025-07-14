using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public Vector3 moveDirection = Vector3.left;

    void Update()
    {
        float speed = GameSpeedController.instance != null
            ? GameSpeedController.instance.GetCurrentMoveSpeed()
            : 5f;

        transform.Translate(moveDirection * speed * Time.deltaTime);
    }
}
