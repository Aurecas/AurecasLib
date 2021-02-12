using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeUI : MonoBehaviour {

    //Parameters
    public float fadeSpeed = 1;

    //Internal
    bool intro = true;
    bool outro = false;
    float alpha = 1;
    Image image;
    string nextScene;

    // Start is called before the first frame update
    void Start() {
        alpha = 1;
        outro = false;
        intro = true;
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update() {
        if (intro) {
            alpha -= Time.unscaledDeltaTime / fadeSpeed;
            if (alpha < 0) {
                alpha = 0;
                intro = false;
            }
        }
        if (outro) {
            alpha += Time.unscaledDeltaTime / fadeSpeed;
            if (alpha > 1) {
                alpha = 1;
                outro = false;
                if (nextScene.Length > 0) {
                    SceneManager.LoadScene(nextScene);
                }
            }
        }
        Color c = image.color;
        c.a = alpha;
        image.color = c;

        image.raycastTarget = intro || outro;

    }

    public void LoadScene(string sceneName) {
        nextScene = sceneName;
        intro = false;
        outro = true;
    }
}
