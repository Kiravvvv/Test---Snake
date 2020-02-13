//Скрипт для частей хвоста
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail_segment : MonoBehaviour
{
    [HideInInspector]
    public float Speed = 0;//Скорость

    Transform My_transform = null;//Трансформ объекта

    Transform Target = null;//То что будет приследовать сегмент

    bool Stop_bool = false;//Остановить

    private void Awake()
    {
        My_transform = transform;
    }

    private void OnEnable()
    {
        if (GameObject.FindObjectOfType<Administrator_game>())
            Administrator_game.Instance.D_End_game += Stop;
    }

    private void OnDisable()
    {
        if (GameObject.FindObjectOfType<Administrator_game>())
            Administrator_game.Instance.D_End_game -= Stop;
    }

    void Stop()
    {
        Stop_bool = true;
    }

    public void Preparation(Transform _target, float _speed)//Подготовка
    {
        Target = _target;
        Speed = _speed;
    }

    private void Update()
    {
        if(!Stop_bool)
        Movement();
    }

    void Movement()//Движение
    {
        My_transform.LookAt(Target);
        My_transform.position = Vector3.Lerp(My_transform.position, Target.position, Speed * Time.deltaTime);
    }
}
