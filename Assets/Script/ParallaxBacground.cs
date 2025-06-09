using UnityEngine;

public class ParallaxBacground : MonoBehaviour
{
    [SerializeField] private Transform cam;        // Kamera referansý
    [SerializeField] private float moveSpeed = 1f; // Parallax hýzý
    [SerializeField] private float resetDistance = 18f; // Resetleme eþiði (arka plan geniþliði kadar)

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        // Arka planý sürekli sola kaydýr
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        // Eðer kamera pozisyonu, bu arka planýn pozisyonunu reset mesafesi kadar geçtiyse:
        if (cam.position.x >= transform.position.x + resetDistance)
        {
            transform.position = new Vector3(transform.position.x + resetDistance * 2f, transform.position.y, transform.position.z);
        }
    }
}
