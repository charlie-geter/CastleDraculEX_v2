using UnityEngine;
using UnityEditor;
using System.Collections;

/// <summary>
/// Clear missing scripts.
/// http://wiki.unity3d.com/index.php?title=FindMissingScripts
/// </summary>

public class FindMissingScriptsRecursively : EditorWindow {
static int go_count = 0, components_count = 0, missing_count = 0;
 
    [MenuItem("Window/FindMissingScriptsRecursively")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(FindMissingScriptsRecursively));
    }
 
    public void OnGUI()
    {
        if (GUILayout.Button("Find Missing Scripts in selected GameObjects"))
        {
            FindInSelected();
			EditorGUILayout.LabelField("Time since start: ", 
           string.Format("Searched {0} GameObjects, {1} components, found {2} missing", go_count, components_count, missing_count));

		}
		
		/*if (GUILayout.Button ("Clear Missing Scripts in selected GameObjects"))
		{
			ClearInSelected();
			EditorGUILayout.LabelField("Time since start: ", 
           string.Format("Searched {0} GameObjects, {1} components, cleared {2} missing", go_count, components_count, missing_count));

		}*/
		
		    }
    private static void FindInSelected()
    {
        GameObject[] go = Selection.gameObjects;
        go_count = 0;
		components_count = 0;
		missing_count = 0;
        foreach (GameObject g in go)
        {
   			FindInGO(g);
        }
        Debug.Log(string.Format("Searched {0} GameObjects, {1} components, found {2} missing", go_count, components_count, missing_count));
    }
 
    private static void FindInGO(GameObject g)
    {
        go_count++;
        Component[] components = g.GetComponents<Component>();
        for (int i = 0; i < components.Length; i++)
        {
        components_count++;
        if (components[i] == null)
            {
            missing_count++;
            Debug.Log(g.name + " has an empty script attached in position: " + i, g);
            }
        }
        // Now recurse through each child GO (if there are any):
        foreach (Transform childT in g.transform)
            {
            //Debug.Log("Searching " + childT.name  + " " );
            FindInGO(childT.gameObject);
            }
	}
	
	private static void ClearInSelected()
    {
        GameObject[] go = Selection.gameObjects;
        go_count = 0;
		components_count = 0;
		missing_count = 0;
        foreach (GameObject g in go)
        {
   			ClearInGO(g);
        }
        Debug.Log(string.Format("Searched {0} GameObjects, {1} components, cleared {2} missing", go_count, components_count, missing_count));
    }
 
    private static void ClearInGO(GameObject g)
    {
        go_count++;
        Component[] components = g.GetComponents<Component>();
        /*for (int i = 0; i < components.Length; i++)
        {
        components_count++;
        if (components[i] == null)
            {
            missing_count++;
			//GameObject comp = g.GetComponent(null);
			//Component c = g.GetComponent ("null");
			DestroyImmediate(components[i], true);
            //Debug.Log(g.name + " has an empty script attached in position: " + i, g);
			//i--;
            }
        }*/
		foreach (Component c in components) {
			components_count++;
			if(c == null) {
				missing_count++;
				//MonoBehaviour comp = g.GetComponent<MonoBehaviour>();
				// annoying - you can't delete a "null", but the only way to find these components is null. 
				//It doesn't seem to want to delete any monobehavior it finds, either, because they're null after you pull them in.
				DestroyImmediate(c, true);
			}
		}
        // Now recurse through each child GO (if there are any):
        foreach (Transform childT in g.transform)
            {
            //Debug.Log("Searching " + childT.name  + " " );
            ClearInGO(childT.gameObject);
            }
	}
}