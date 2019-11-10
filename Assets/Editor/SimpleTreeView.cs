using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.IMGUI.Controls;

public class SimpleTreeView : TreeView
{

    public SimpleTreeView(TreeViewState treeViewState) : base(treeViewState)
    {
        Reload();
    }

    /*protected override TreeViewItem BuildRoot()
    {
        var root = new TreeViewItem { id = 0, depth = -1, displayName = "Root" };
        var allItems = new List<TreeViewItem>
        {
            new TreeViewItem { id =0, depth = 0, displayName = "Evolution"},
            new TreeViewItem { id =1, depth = 1, displayName = "Animals"},
            new TreeViewItem { id =2, depth = 2, displayName = "Mammals"},
            new TreeViewItem { id =3, depth = 3, displayName = "Tiger"},
            new TreeViewItem { id =4, depth = 3, displayName = "Elephant"},
            new TreeViewItem { id =5, depth = 3, displayName = "Okapi"},
            new TreeViewItem { id =6, depth = 3, displayName = "Armadillo"},
            new TreeViewItem { id =7, depth = 2, displayName = "Reptiles"},
            new TreeViewItem { id =8, depth = 3, displayName = "Crocodile"},
            new TreeViewItem { id =9, depth = 3, displayName = "Liszrd"},
        };
        SetupParentsAndChildrenFromDepths(root, allItems);
        return root;

    }*/

    protected override TreeViewItem BuildRoot()
    {
        var root = new TreeViewItem { id = 0, depth = -1, displayName = "Root" };
        var evolution = new TreeViewItem { id = 0, displayName = "Evolution" };
        var animals = new TreeViewItem { id = 1, displayName = "Animals" };
        var mammals = new TreeViewItem { id = 2, displayName = "Mammals" };
        var tiger = new TreeViewItem { id = 3, displayName = "Tiger" };
        var elephant = new TreeViewItem { id = 4, displayName = "Elephant" };
        var okapi = new TreeViewItem { id = 5, displayName = "Okapi" };
        var armadillo = new TreeViewItem { id = 6, displayName = "Armadillo" };
        var reptiles = new TreeViewItem { id = 7, displayName = "Reptiles" };
        var crocodile = new TreeViewItem { id = 8, displayName = "Crocodile" };
        var lizard = new TreeViewItem { id = 9, displayName = "Liszrd" };

        root.AddChild(animals);
        animals.AddChild(mammals);
        animals.AddChild(reptiles);
        mammals.AddChild(tiger);
        mammals.AddChild(elephant);
        mammals.AddChild(okapi);
        mammals.AddChild(armadillo);
        reptiles.AddChild(crocodile);
        reptiles.AddChild(lizard);

        SetupDepthsFromParentsAndChildren(root);
        return root;
            
    }

    public List<GameObject> SetSelection(GameObject[] gos)
    {
        return new List<GameObject>(gos);
    }

}
