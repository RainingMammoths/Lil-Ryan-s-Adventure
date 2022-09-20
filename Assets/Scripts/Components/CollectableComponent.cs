using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CollectableComponent : MonoBehaviour
{
    [Tooltip("Values: score")] [SerializeField] string _type;
    [Range(-100,100)][Tooltip("Values: -100 to 100")] [SerializeField] int _value;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (_type == "score")
            {
                var manager = collision.gameObject.GetComponent<PlayerManager>();
                manager.Score(_value);
            }
        }
        Destroy(gameObject);
    }
}
