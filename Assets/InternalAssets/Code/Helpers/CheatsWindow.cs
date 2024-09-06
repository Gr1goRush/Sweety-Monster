#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public class CheatsWindow : EditorWindow
{
    [MenuItem("Cheats/Default")]
    public static void ShowWindow()
    {
        CheatsWindow window = GetWindow<CheatsWindow>("Cheats");
        window.Show();
    }

    private void OnGUI()
    {
        GUILayout.Label("Cheats", EditorStyles.boldLabel);
        
        Space();
        Space();

        GUILayout.Label("MoneyCheats");
        Space();
        if (GUILayout.Button("Add 100 coins", GUILayout.ExpandWidth(true)))
        {
            PlayerBalance.AddMoney(100);
        }

        if (GUILayout.Button("Remove 100 coins", GUILayout.ExpandWidth(true)))
        {
            PlayerBalance.RemoveMoney(100);
        }
        Space();

        if (Application.isEditor)
        {
            GUILayout.Label("Save cheats");
            Space();
            if (GUILayout.Button("Delete Save", GUILayout.ExpandWidth(true)))
            {
                PlayerPrefs.DeleteAll();
            }
        }
    }

    private void Space()
    {
        GUILayout.Label(" ");
    }
}
#endif
