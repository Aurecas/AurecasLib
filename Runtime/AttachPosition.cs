using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class AttachPosition : MonoBehaviour
{
    public GameObject targetObject;
    void Update()
    {
        if (targetObject) {
            transform.position = targetObject.transform.position;
        }
    }
}
