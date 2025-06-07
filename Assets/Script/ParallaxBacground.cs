using UnityEngine;

public class ParallaxBacground : MonoBehaviour
{
    [SerializeField] private Transform _cam;
    [SerializeField] private float _moveSpped;

    private void Update()
    {
        transform.Translate(-1 * _moveSpped * Time.deltaTime , 0f , 0f);
        if(_cam.position.x >= transform.position.x + 18f)
        {
            transform.position = new Vector2(_cam.position.x + 18f, transform.position.y);
        }
    }
}
