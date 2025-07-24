using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ScoreManager))]
public class ScoreManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector(); // Mevcut alanları çiz

        ScoreManager scoreManager = (ScoreManager)target;

        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("🧪 Test & Debug Tools", EditorStyles.boldLabel);

        // Skor ekleme testi
        if (GUILayout.Button("➕ Test: +10 Score"))
        {
            scoreManager.AddScore(10);
            Debug.Log("➕ 10 puan eklendi.");
        }

        // Mevcut skoru sıfırla
        if (GUILayout.Button("🔄 Reset Current Score"))
        {
            scoreManager.ResetScore();
            Debug.Log("🧹 Mevcut skor sıfırlandı.");
        }

        // Yüksek skoru sıfırla (PlayerPrefs dahil)
        if (GUILayout.Button("🔥 Reset High Score (PlayerPrefs)"))
        {
            scoreManager.EditorResetHighScore();
        }
    }
}
