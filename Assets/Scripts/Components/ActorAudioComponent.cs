using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Actor))]
public class ActorAudioComponent : MonoBehaviour
{
    private Actor actorScript_;
    // Start is called before the first frame update
    protected void Start()
    {
        actorScript_= GetComponent<Actor>();
        actorScript_.OnAttack += PlaySound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlaySound(object sender, System.EventArgs e)
    {
        // Play Sound
    }
}
