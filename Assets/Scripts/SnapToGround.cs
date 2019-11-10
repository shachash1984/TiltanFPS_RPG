using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class SnapToGround : MonoBehaviour {

    public bool isOn = true;

    private void Update()
    {
        if (isOn)
        {
            Vector3 newPos = transform.position;
            newPos.y = 0;
            transform.position = newPos;
        }
        else
        {
            transform.Translate(Vector3.up * ((float)EditorApplication.timeSinceStartup % 10) );
        }
    }
}
