using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.IMGUI.Controls;

public class SimpleTreeViewWindow : EditorWindow {

    [SerializeField] private TreeViewState _treeViewState;
    [SerializeField] private SimpleTreeView _simpleTreeView;
    private Object target;
    private Color color;

    private void OnEnable()
    {
        if (_treeViewState == null)
            _treeViewState = new TreeViewState();
        _simpleTreeView = new SimpleTreeView(_treeViewState);
    }

    private void OnGUI()
    {
        Rect objRect = new Rect(0, 0, position.width/2, 15);
        Rect colorRect = new Rect(position.width / 2, 0, position.width / 2, 15);
        Rect buttonLookAtRect = new Rect(0, 20, position.width, 15);
        Rect buttonColorRect = new Rect(0, 40, position.width, 15);
        //Rect buttonRect = new Rect(0, 15, position.width, 15);

        //target = EditorGUI.ObjectField(objRect, target, typeof(Transform));
        target = EditorGUI.ObjectField(objRect, target, typeof(Transform), true);
        
        if(GUI.Button(buttonLookAtRect, "Look at object"))
        {
            if(target != null)
            {
                foreach (GameObject selected in Selection.gameObjects)
                {
                    selected.transform.LookAt((target as Transform), Vector3.up);
                }
            }
        }

        color = EditorGUI.ColorField(colorRect, color);
        if (GUI.Button(buttonColorRect, "Paint object"))
        {
            foreach (GameObject selected in Selection.gameObjects)
            {
                Renderer[] renderers = selected.GetComponentsInChildren<Renderer>();
                foreach (Renderer r in renderers)
                {
                    r.sharedMaterial.color = color;
                }
            }
        }

        

    }

    [MenuItem("TreeView Examples/Object Tester")]
    static void ShowWindow()
    {
        var window = GetWindow<SimpleTreeViewWindow>();
        window.titleContent = new GUIContent("My Window");
        window.Show();
    }


}
