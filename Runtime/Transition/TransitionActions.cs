using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionActions : MonoBehaviour
{
    public void Goto(string scene) {
        Transition.Goto(scene);
    }

    public void FadeIn() {
        Transition.FadeIn();
    }
}
