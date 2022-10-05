using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueComponent : MonoBehaviour
{
    [SerializeField] private List<ChatOption> chatOptions = new List<ChatOption>();
    private GameObject canvas;

    public void Dialogue(GameObject go)
    {
        int i = 1;
        foreach (ChatOption chatOption in chatOptions)
        {
            if (chatOption.Condition?.IsConditionMet(go) != false)
            {
                DisplayChat(chatOption, 10 * i);
                i++;
            }
        }
    }

    private void DisplayChat(ChatOption option, float posY)
    {
        GameObject textGO = new GameObject(option.Speaker, typeof(RectTransform));
        RectTransform rect = textGO.transform as RectTransform;
        //rect.sizeDelta(100f, 20);
        textGO.AddComponent<CanvasRenderer>();
        var displayedText = textGO.AddComponent<Text>();
        textGO.transform.SetParent(canvas.transform);
        displayedText.text = option.Message;
        displayedText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        displayedText.transform.position = new Vector3(100f, posY, 0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
