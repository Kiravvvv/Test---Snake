//Скрипт создания подбираемых очков
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature_score_obj : Singleton<Creature_score_obj>
{
    [Tooltip("Через сколько будет создан")]
    [SerializeField]
    float Time_spawn = 2f;

    [Tooltip("Префаб")]
    [SerializeField]
    GameObject Prefab_score = null;

    bool Stop_bool = false;//Остановить

    float Timer = 0;//Таймер отсчёта

    List<Transform> Pool_score_obj = new List<Transform>();//Список объектов которые сейчас не действуют

    private void OnEnable()
    {
        if (GameObject.FindObjectOfType<Administrator_game>())
        {
            Administrator_game.Instance.D_End_game += Stop;
        }
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


    public void Add_pool(Transform _t)//Добавить в пул
    {
        Pool_score_obj.Add(_t);
    }

    public void Remove_pool(Transform _t)//Убрать из пула
    {
        Pool_score_obj.Remove(_t);
    }

    private void Update()
    {
        if (!Stop_bool)
            Time_down();
    }

    void Time_down()//Отсчитывать время
    {
            if (Timer > 0)
                Timer -= Time.deltaTime;
            else
            {
                Spawn();
                Timer = Time_spawn;
            }
    }

        void Spawn()//Заспавнить
        {
            Transform obj = null;

            if (Pool_score_obj.Count > 0)
            {
                obj = Pool_score_obj[0];
            obj.gameObject.SetActive(true);
            }
            else
            {
                GameObject obj_instantiate = Instantiate(Prefab_score);
                obj = obj_instantiate.transform;
                Add_spawn_list.Instance.Add_item_pool(obj);
            }

            float pos_x = Random.Range(-9, 9);
            float pos_z = Random.Range(-6, 6);

        obj.position = new Vector3(pos_x, 0.5f, pos_z);
        }
}
