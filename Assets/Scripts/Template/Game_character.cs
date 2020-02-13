//Набор параметров для персонажей
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Game_character : Game_object
{
    [Tooltip("Скорость")]
    [SerializeField]
    protected float Speed = 1f;

    [Tooltip("Физика")]
    [SerializeField]
    protected Rigidbody Body = null;

    protected Transform My_transform = null;//Трансформ объекта 

    protected override void Start()
    {
        My_transform = transform;

        if(GetComponent<Rigidbody>())
        Body = GetComponent<Rigidbody>();
        base.Start();
    }
}
