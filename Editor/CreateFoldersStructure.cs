using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Windows;
using UnityEngine.WSA;

public class CreateFoldersStructure : EditorWindow
{
    private static string _projectName = "_notebook_project";

    [MenuItem("My Windows/Create Default Folders")]
    private static void SetUpFolders()
    {
        CreateFoldersStructure window = ScriptableObject.CreateInstance<CreateFoldersStructure>();
        window.position = new Rect(Screen.width / 2, Screen.height / 2, 400, 150);
        window.ShowPopup();
    }

    private static void CreateAllFolders()
    {

        if (!Directory.Exists($"Assets/{_projectName}"))
        {
            Directory.CreateDirectory($"Assets/{_projectName}");
        }

        List<string> folders = new List<string>()
            {
                //art
                "Art",
                "Art/Textures",

                //audio
                "Audio",
                "Audio/Sounds",

                //code
                "Code",
                "Code/Scripts",
                "Code/Scripts/Utils",

                //level
                "Level",
                "Level/Scenes",
                "Level/Prefabs",
            };

        foreach (string folder in folders)
        {
            if (!Directory.Exists($"Assets/{_projectName}/{folder}"))
            {
                Directory.CreateDirectory($"Assets/{_projectName}/{folder}");
            }
        } 

        AssetDatabase.Refresh();
    }

    private void OnGUI()
    {
        EditorGUILayout.LabelField("Insert the project name as the root folder");

        _projectName = EditorGUILayout.TextField("Project Name: ", _projectName);
        Repaint();
        GUILayout.Space(70);
        if (GUILayout.Button("Generate!"))
        {
            CreateAllFolders();
            Close();
        }
    }
}
