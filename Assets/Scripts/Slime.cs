using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime
{
    [SerializeField] int maxHealth_;
    [SerializeField] int health_;
    // Start is called before the first frame update

    public Slime()
    {
        var kazkas = new MovementComponent();
    }
}
