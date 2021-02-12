using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ProgressBar : MonoBehaviour
{
    public Image fillBar;
    public float value;
    public float maxValue = 100;

    public bool vertical = false;
    public Text textValue;
    public string textFormat;

    public void SetValue(float value, float maxValue)
    {
        this.value = value;
        this.maxValue = maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        float v = value / maxValue;

        RectTransform rectTransform = GetComponent<RectTransform>();
        if (!vertical)
            fillBar.rectTransform.offsetMax = new Vector2((v - 1) * rectTransform.rect.width, fillBar.rectTransform.offsetMax.y);
        else
            fillBar.rectTransform.offsetMax = new Vector2(fillBar.rectTransform.offsetMax.x, (v - 1) * rectTransform.rect.height);

        if(textValue != null)
        {
            textValue.text = string.Format(textFormat, value, maxValue);
        }
    }
}
