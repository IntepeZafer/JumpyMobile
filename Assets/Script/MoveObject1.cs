using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float speed;
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
