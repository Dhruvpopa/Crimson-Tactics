using UnityEngine;
using UnityEditor;

public class ObstacleEditorWindow : EditorWindow
{
    ObstacleData obstacleData;

    [MenuItem("Tools/Obstacle Editor")]
    public static void ShowWindow()
    {
        GetWindow<ObstacleEditorWindow>("Obstacle Editor");
    }

    void OnGUI()
    {
        obstacleData = (ObstacleData)EditorGUILayout.ObjectField("Obstacle Data", obstacleData, typeof(ObstacleData), false);

        if (obstacleData == null) return;

        EditorGUILayout.Space();

        for (int y = 10; y >= 1; y--)
        {
            EditorGUILayout.BeginHorizontal();
            for (int x = 1; x <= 10; x++)
            {
                int index = (y - 1) * 10 + (x - 1);
                obstacleData.obstacleMap[index] = GUILayout.Toggle(obstacleData.obstacleMap[index], "");
            }
            EditorGUILayout.EndHorizontal();
        }

        if (GUILayout.Button("Save"))
        {
            EditorUtility.SetDirty(obstacleData);
            AssetDatabase.SaveAssets();
        }
    }
}
