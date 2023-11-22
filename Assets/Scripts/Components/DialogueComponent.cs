using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueComponent : MonoBehaviour
{
    [SerializeField] private List<ChatOption> chatOptions = new List<ChatOption>();

    public void Dialogue(GameObject go)
    {
        int i = 1;
        foreach (ChatOption chatOption in chatOptions)
        {
            if (chatOption.Condition?.IsConditionMet(go) != false)
            {
                //DisplayChat(chatOption, 12 * i);
                i++;
            }
        }
    }

    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
