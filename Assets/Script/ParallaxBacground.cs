using UnityEngine;

public class ParallaxBacground : MonoBehaviour
{
    [SerializeField] private Transform cam;        // Kamera referans�
    [SerializeField] private float moveSpeed = 1f; // Parallax h�z�
    [SerializeField] private float resetDistance = 18f; // Resetleme e�i�i (arka plan geni�li�i kadar)

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        // Arka plan� s�rekli sola kayd�r
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        // E�er kamera pozisyonu, bu arka plan�n pozisyonunu reset mesafesi kadar ge�tiyse:
        if (cam.position.x >= transform.position.x + resetDistance)
        {
            transform.position = new Vector3(transform.position.x + resetDistance * 2f, transform.position.y, transform.position.z);
        }
    }
}
