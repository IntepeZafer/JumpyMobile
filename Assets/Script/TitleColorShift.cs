using TMPro;
using UnityEngine;
public class TitleColorShift : MonoBehaviour
{
    private TMPro.TextMeshProUGUI tmp;
    private float hue;
    private TMP_Text textMesh;
    private Mesh mesh;
    private Vector3[] vertices;

    void Awake()
    {
        textMesh = GetComponent<TMP_Text>();
    }

    void Start()
    {
        tmp = GetComponent<TMPro.TextMeshProUGUI>();
    }

    void Update()
    {
        hue += Time.deltaTime * 0.1f;
        tmp.color = Color.HSVToRGB(hue % 1f, 1f, 1f);

        textMesh.ForceMeshUpdate();
        mesh = textMesh.mesh;
        vertices = mesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            float wave = Mathf.Sin(Time.time * 3f + i * 0.1f) * 50f;
            vertices[i].y += wave;
        }
        mesh.vertices = vertices;
        textMesh.canvasRenderer.SetMesh(mesh);
    }
}
