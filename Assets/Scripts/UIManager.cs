using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class UIManager
{
    [SerializeField] private static Sprite spriteUIBG_;
    private static Sprite spriteAvatar_;
    private static bool isShown;
    private static GameObject canvas_;
    private static RectTransform canvasRect_;
    // Start is called before the first frame update
    static void Start()
    {
        canvas_ = GameObject.Find("Canvas");
        canvasRect_ = canvas_.GetComponent<RectTransform>();
    }

    private static void DisplayChat(ChatOption option, float posY)
    {
        GameObject textGO = new GameObject(option.Speaker, typeof(RectTransform));
        textGO.transform.SetParent(canvas_.transform);
        RectTransform rect = textGO.transform as RectTransform;
        Vector3 correctedPos = new Vector3(canvasRect_.position.x - canvasRect_.sizeDelta.x * .5f, canvasRect_.position.y - canvasRect_.sizeDelta.y * .5f, 0f);
        rect.sizeDelta = new Vector2(canvasRect_.rect.size.x * .7f, canvasRect_.rect.size.y * .1f);
        rect.localPosition = new Vector3(0f, canvasRect_.position.y - canvasRect_.sizeDelta.y * .5f - posY, 0f);
        textGO.AddComponent<CanvasRenderer>();
        var rend = textGO.AddComponent<SpriteRenderer>();
        rend.sprite = spriteUIBG_;
        Debug.Log(spriteUIBG_);

        var displayedText = textGO.AddComponent<Text>();
        displayedText.text = option.Message;
        displayedText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
    }
}
