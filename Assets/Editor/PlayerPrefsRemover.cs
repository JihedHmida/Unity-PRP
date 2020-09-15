using UnityEngine;
using UnityEditor;

public class PlayerPrefsRemover : EditorWindow
{

    [MenuItem("Tools/Delete Player Prefs")]
    public static void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Player Prefs Deleted ! ");
    }
}
