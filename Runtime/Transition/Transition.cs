using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour {
    public static Transition ST;

    // Parameters
    public bool autoFadeIn = true;

    // Components
    Animator myAnimator;

    // Internal
    bool sameScene, sameSceneAutoIn;
    AsyncOperation loadingScene;
    TransitionCallback sameSceneCallback;

    // Delegates
    public delegate void TransitionCallback();

    public static void Goto(string scene) {
        // Create if isn't instantiated already
        if (ST == null) {
            ST = Instantiate(GlobalReferences.transitionPrefab);
        }

        // Disable auto fade in for this instance
        ST.autoFadeIn = false;
        ST.sameScene = false;

        // Load requested scene
        ST.loadingScene = SceneManager.LoadSceneAsync(scene);
        ST.loadingScene.allowSceneActivation = false;
        TransitionManager.Instance.PrepareSceneIntro(scene);

        // Fade out
        ST.myAnimator.Play("Out");
    }

    public static void SameSceneTransition(TransitionCallback callback = null, bool autoIn = true) {
        // Create if isn't instantiated already
        if (ST == null) {
            ST = Instantiate(GlobalReferences.transitionPrefab);
        }

        // Disable auto fade in for this instance
        ST.autoFadeIn = false;

        // Assign callback
        ST.sameSceneCallback = callback;
        ST.sameSceneAutoIn = autoIn;
        ST.sameScene = true;

        // Fade out
        ST.myAnimator.Play("Out");
    }

    void OnDestroy() {
        // Release reference
        ST = null;
    }

    public static void FadeIn() {
        if (ST == null) return;

        ST.myAnimator.Play("In");
    }

    public void FadeInDone() {
        Destroy(gameObject);
    }

    public void FadeOutDone() {
        if (sameScene) {
            sameSceneCallback?.Invoke();
            if (sameSceneAutoIn) StartCoroutine(FadeInSkipFrame());
        }
        else {
            loadingScene.allowSceneActivation = true;
        }
    }

    IEnumerator FadeInSkipFrame() {
        // Skip 2 frames
        yield return null;
        yield return null;

        // Fade in
        myAnimator.Play("In");
    }

    void Start() {
        if (autoFadeIn) {
            myAnimator.Play("In");
        }
    }

    void Awake() {
        ST = this;

        // Components
        myAnimator = GetComponent<Animator>();
    }
}