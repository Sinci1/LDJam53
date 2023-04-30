using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSelectButton : MonoBehaviour
{
    [Header("General")]
    public int levelNumber;
    public bool isLocked;
    private Button button;
    private Image image;
    private TMP_Text text;
    private void Awake()
    {
        if (levelNumber > 1) { isLocked = true; }
        button = gameObject.GetComponent<Button>();
        image = gameObject.GetComponent<Image>();
        text = gameObject.GetComponentInChildren<TMP_Text>();
        if (isLocked)
        {
            /*ColorBlock cb = new ColorBlock();
            cb.normalColor = new Color(0.1f, 0.1f, 0.1f, 1f);
            cb.highlightedColor = new Color(0.1f, 0.1f, 0.1f, 1f);
            cb.pressedColor = new Color(0.1f, 0.1f, 0.1f, 1f);
            cb.selectedColor = new Color(0.1f, 0.1f, 0.1f, 1f);
            cb.disabledColor = new Color(0.1f, 0.1f, 0.1f, 1f);

            button.colors = cb;*/
            button.enabled = false;
            image.color = new Color(0.1f, 0.1f, 0.1f, 1f);
            text.color = new Color(0f, 0f, 0f, 1f);

        }
    }
}
