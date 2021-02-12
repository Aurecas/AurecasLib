using System.Collections;
using UnityEngine;

[ExecuteInEditMode]
public class CameraFollow : MonoBehaviour {

    public GameObject follow;
    [Tooltip("Deslocamento do alvo")]
    public Vector3 direction;
    [Tooltip("Distância entre o alvo e a câmera")]
    public float distance;
    [Tooltip("Se a camera segue o alvo ou não")]
    public bool cameraFixed;
    [Tooltip("O quão devagar a camera se movimenta para seguir o alvo")]
    public float tweenFactor = 10f;

    //Animation stuff

    AnimationCurve currentAnimation;
    float timer; //Um timer, pra andar pela animação
    float curveValue = 1;
    float animationDuration = 2;

    private void FixedUpdate() {

        direction.Normalize();

        timer += Time.fixedDeltaTime; //incrementa o timer com o tempo, no começo do gameobject ele vai ser 0
        if (currentAnimation != null) {
            curveValue = currentAnimation.Evaluate(timer / animationDuration);
        }
 

        Vector3 q = transform.position;
        q += (follow.transform.position + direction * curveValue - q) / tweenFactor * Time.fixedDeltaTime * 60f;
        transform.position = q;
    }

    public void PlayCameraAnimation(AnimationCurve distanceAnimation, float duration) {
        this.currentAnimation = distanceAnimation;
        this.animationDuration = duration;
        timer = 0;
    }

    private void Update() {

        direction.Normalize();

        if (!Application.isPlaying) { 
            if (cameraFixed) {
                // transform.position = follow.transform.position + direction;
                transform.position = follow.transform.position + direction*distance;

            }
        }
    }

    public void Shake(float amount) {
        transform.position = transform.position + Random.insideUnitSphere * amount;
        //Handheld.Vibrate();
    }

    public void Shake(float delay, float amount) {
        StartCoroutine(_Shake(delay, amount));
    }

    private IEnumerator _Shake(float delay, float amount) {
        yield return new WaitForSecondsRealtime(delay);
        Shake(amount);
    }
}
