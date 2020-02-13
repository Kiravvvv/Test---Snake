//Скрипт по добавлению заспавненых объектов в закладку пулов
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Add_spawn_list : Singleton<Add_spawn_list>
{
    [Tooltip("Объекты закладки для пулов")]
    Transform Objects_pool = null, Characters_pool = null, Items_pool = null, Projectiles_pool = null;

    [Tooltip("Объекты закладки для заспавненых")]
    Transform Objects_spawn = null, Characters_spawn = null, Items_spawn = null, Projectiles_spawn = null;

    private void Awake()
    {
        Preparation();
    }

    void Preparation()//Подготовка и проверка
    {
        for (int x = 0; x < 4; x++)
        {
            string name_obj = "";//Имя закладки

            GameObject obj = null;//Кэш под закладку

            switch (x)
            {
                case 0:
                    name_obj = "Objects";
                    break;
                case 1:
                    name_obj = "Characters";
                    break;
                case 2:
                    name_obj = "Items";
                    break;
                case 3:
                    name_obj = "Projectiles";
                    break;

            }//Выбор названия закладки

            if (transform.Find(name_obj))
                obj = transform.Find(name_obj).gameObject;
            else
            {
                obj = new GameObject();
                obj.transform.SetParent(transform);
                obj.name = name_obj;
            }

            switch (x)
            {
                case 0:
                    Objects_spawn = obj.transform;
                    break;
                case 1:
                    Characters_spawn = obj.transform;
                    break;
                case 2:
                    Items_spawn = obj.transform;
                    break;
                case 3:
                    Projectiles_spawn = obj.transform;
                    break;

            }//Назначение закладок в кэш

        }

        if (!transform.Find("Pool_list"))
        {
            GameObject pool_list_obj = new GameObject();
            pool_list_obj.transform.SetParent(transform);
            pool_list_obj.name = "Pool_list";

            for(int x = 0; x < 4; x++)
            {
                string name_obj = "";

                switch (x)
                {
                    case 0:
                        name_obj = "Objects";
                        break;
                    case 1:
                        name_obj = "Characters";
                        break;
                    case 2:
                        name_obj = "Items";
                        break;
                    case 3:
                        name_obj = "Projectiles";
                        break;

                }

                GameObject obj = new GameObject();
                obj.transform.SetParent(pool_list_obj.transform);
                obj.name = name_obj;

                switch (x)
                {
                    case 0:
                        Objects_pool = obj.transform;
                        break;
                    case 1:
                        Characters_pool = obj.transform;
                        break;
                    case 2:
                        Items_pool = obj.transform;
                        break;
                    case 3:
                        Projectiles_pool = obj.transform;
                        break;

                }
                
            }
            
        }
        else
        {
            for (int x = 0; x < 4; x++)
            {
                string name_obj = "";//Имя закладки

                GameObject obj = null;//Кэш под закладку

                switch (x)
                {
                    case 0:
                        name_obj = "Objects";
                        break;
                    case 1:
                        name_obj = "Characters";
                        break;
                    case 2:
                        name_obj = "Items";
                        break;
                    case 3:
                        name_obj = "Projectiles";
                        break;

                }//Выбор названия закладки

                if (transform.Find("Pool_list").Find(name_obj))
                    obj = transform.Find("Pool_list").Find(name_obj).gameObject;
                else
                {
                    obj = new GameObject();
                    obj.transform.SetParent(transform.Find("Pool_list").transform);
                    obj.name = name_obj;
                }

                switch (x)
                {
                    case 0:
                        Objects_pool = obj.transform;
                        break;
                    case 1:
                        Characters_pool = obj.transform;
                        break;
                    case 2:
                        Items_pool = obj.transform;
                        break;
                    case 3:
                        Projectiles_pool = obj.transform;
                        break;

                }//Назначение закладок в кэш

            }
        }
    }

    //Для пуловых объектов
    public void Add_objects_pool(Transform _obj_transform)
    {
        _obj_transform.SetParent(Objects_pool);
    }

    public void Add_characters_pool(Transform _obj_transform)
    {
        _obj_transform.SetParent(Characters_pool);
    }

    public void Add_item_pool(Transform _obj_transform)
    {
        _obj_transform.SetParent(Items_pool);
    }

    public void Add_projectiles_pool(Transform _obj_transform)
    {
        _obj_transform.SetParent(Projectiles_pool);
    }

    //Для временно заспавненых объектов
    public void Add_objects_spawn(Transform _obj_transform)
    {
        _obj_transform.SetParent(Objects_spawn);
    }

    public void Add_characters_spawn(Transform _obj_transform)
    {
        _obj_transform.SetParent(Characters_spawn);
    }

    public void Add_item_spawn(Transform _obj_transform)
    {
        _obj_transform.SetParent(Items_spawn);
    }

    public void Add_projectiles_spawn(Transform _obj_transform)
    {
        _obj_transform.SetParent(Projectiles_spawn);
    }
}
