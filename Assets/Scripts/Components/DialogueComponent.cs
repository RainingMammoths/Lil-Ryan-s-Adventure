using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueComponent : MonoBehaviour
{
    [SerializeField] private List<ChatOption> chatOptions = new List<ChatOption>();
    private GameObject canvas;

    public void Dialogue(int option, GameObject go)
    {
        Debug.Log("talking");
        if (chatOptions[option].Condition?.IsConditionMet(go) != false)
        {
            GameObject textGO = new GameObject(chatOptions[option].Speaker + option);
            textGO.transform.SetParent(canvas.transform);
            //var displayedText = canvas.AddComponent<Text>();
            //displayedText.text = chatOptions[option].Message;
            //displayedText.transform.position = new Vector3(1f, 1f, 0f);
        }
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
