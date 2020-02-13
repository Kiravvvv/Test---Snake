//Кастыль, что бы включить быстро меню и выключить
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_star_on_and_off : MonoBehaviour
{
    [SerializeField]
    GameObject Menu = null;

    private void Awake()
    {
        if(!PlayerPrefs.HasKey("Key_walk_forward"))
        Menu.SetActive(true);
    }

    void Start()
    {
        if (!PlayerPrefs.HasKey("Key_walk_forward"))
            Menu.SetActive(false);
    }

}
