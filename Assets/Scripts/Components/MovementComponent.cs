using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    [SerializeField] [Range(1,10)] public float speed = 10f;
    public float Speed { get => speed; set => speed = value; }
}
