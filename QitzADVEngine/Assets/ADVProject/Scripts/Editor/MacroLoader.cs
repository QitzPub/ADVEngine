using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;

public class MacroLoader : EditorWindow
{
    private static List<string> nameList = new List<string>();
    private static List<string> costumeList = new List<string>();
    private static List<string> faceList = new List<string>();

    private static bool isOpenName = false;
    private static bool isOpenCostume = false;
    private static bool isOpenFace = false;
    
    private static Vector2 leftScrollPos = Vector2.zero;

    private static readonly string dataPath = "/ADVProject/Scripts/Editor/Resources/";
    private static readonly string commandPath = "/ADVProject/Scripts/DataStore/";
    
    [MenuItem("Tools/MacroLoader")]
    static void Open()
    {
        nameList.Clear();
        costumeList.Clear();
        faceList.Clear();
        EditorWindow.GetWindow<MacroLoader>( "MacroLoaderEditor" );
        ReadList(nameList, "NameList");
        ReadList(costumeList, "CostumeList");
        ReadList(faceList, "FaceList");
    }

    private void OnGUI()
    {
        EditorGUILayout.LabelField( "マクロの人物名、服装、表情のEditorです" );
        if (GUILayout.Button("Save"))
        {
            string template = Resources.Load<TextAsset>("ClassTemplate").text;

            template = template.Replace("#NameList#", SaveList(nameList, Application.dataPath + dataPath + "NameList"));
            template = template.Replace("#CostumeList#", SaveList(costumeList, Application.dataPath + dataPath + "CostumeList"));
            template = template.Replace("#FaceList#", SaveList(faceList, Application.dataPath + dataPath + "FaceList"));

            File.WriteAllText(Application.dataPath + commandPath + "ParseCommandList.cs", template);
        }
        leftScrollPos = EditorGUILayout.BeginScrollView( leftScrollPos,GUI.skin.box );
        
        bool isOpen = EditorGUILayout.Foldout(isOpenName, "人物名");
        if (isOpen != isOpenName)
        {
            isOpenName = isOpen;
        }
        if(isOpen){
        for (int i = 0; i < nameList.Count; i++)
            
            {
                nameList[i] = EditorGUILayout.TextField("", nameList[i]);
            }

        if (GUILayout.Button("+"))
        {
            nameList.Add("");
        }
        }
        
        isOpen = EditorGUILayout.Foldout(isOpenCostume, "服装");
        if (isOpen != isOpenCostume)
        {
            isOpenCostume = isOpen;
        }
        if(isOpen){
            for (int i = 0; i < costumeList.Count; i++)
            {
                costumeList[i] = EditorGUILayout.TextField("", costumeList[i]);
            }
            if (GUILayout.Button("+"))
            {
                costumeList.Add("");
            }
        }
        
        isOpen = EditorGUILayout.Foldout(isOpenFace, "表情");
        if (isOpen != isOpenFace)
        {
            isOpenFace = isOpen;
        }
        if(isOpen){
            for (int i = 0; i < faceList.Count; i++)
            {
                faceList[i] = EditorGUILayout.TextField("", faceList[i]);
            }
            if (GUILayout.Button("+"))
            {
                faceList.Add("");
            }
        }
        EditorGUILayout.EndScrollView();
    }

    private static void ReadList(List<string> list, string fileName)
    {
        string text = Resources.Load<TextAsset>(fileName).text;
        using (StringReader reader = new StringReader(text))
        {
            while (reader.Peek() != -1)
            {
                list.Add(reader.ReadLine());
            }
        }
    }

    private static string SaveList(List<string> list, string WritePath)
    {
        string str = "";
        string ListText = "";
        foreach (string name in list)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrEmpty(name))
            {
                continue;
            }

            ListText += name + "\n";
            str += "\t\t\"" + name + "\",\n";       
        }
        File.WriteAllText(WritePath+".txt", ListText);

        return str;
    }
}
