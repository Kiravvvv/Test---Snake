//Набор параметров для обычных объектов
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Game_object : MonoBehaviour
{

    [Tooltip("Количество жизней")]
    [SerializeField]
    int Maximum_health = 10;

    int Active_health = 0;//Параметр для манипуляции с жизнями


    protected virtual void Start()
    {
        Active_health = Maximum_health;
    }

    public void Change_health(int _change)//Изменение здоровья
    {
        Active_health += _change;

        if (Active_health <= 0)
        {
            Active_health = 0;
            Death();
        }
        else if (Active_health > Maximum_health)
            Active_health = Maximum_health;
    }

    protected virtual void Death()//Смерть/разрушение объекта
    {
        Destroy(gameObject);
    }
}
