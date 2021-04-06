using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalReferences : MonoBehaviour {
    public static Transition transitionPrefab;

    // References
    public Transition _transitionPrefab;

    void Awake() {
        // Assign instance data to the static vars
        transitionPrefab = _transitionPrefab;

        // Destroy me
        Destroy(this);
    }
}