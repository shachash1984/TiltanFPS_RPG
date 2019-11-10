using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.IMGUI.Controls;

public class SimpleTreeViewWindow2 : EditorWindow {

    [SerializeField] private TreeViewState _treeViewState;
    [SerializeField] private SimpleTreeView _simpleTreeView;
    private List<GameObject> selected;


    private void OnEnable()
    {
        if (_treeViewState == null)
            _treeViewState = new TreeViewState();
        _simpleTreeView = new SimpleTreeView(_treeViewState);
    }

    [MenuItem("TreeView Examples/Hierarchy Tester")]
    static void ShowWindow()
    {
        var window = GetWindow<SimpleTreeViewWindow2>();
        window.titleContent = new GUIContent("Hierarchy");
        window.Show();
    }

    private void OnSelectionChange()
    {
        selected = _simpleTreeView.SetSelection(Selection.gameObjects);
        _simpleTreeView.Reload();
    }

    private void OnGUI()
    {
        GUILayout.Label("Evolution", EditorStyles.boldLabel);
        _simpleTreeView.OnGUI(new Rect(0, 60, position.width, position.height));
        GUILayout.BeginArea(new Rect(0, _simpleTreeView.totalHeight + 30, position.width, position.height));
        GUILayout.Label("Food", EditorStyles.boldLabel);
        GUILayout.EndArea();

    }
}
