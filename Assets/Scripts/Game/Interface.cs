//Показывает количество очков
using System.Collections;
using System.Collections.Generic;
//Для интерфейса
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    [Tooltip("Показатель очков")]
    [SerializeField]
    Text Score_text = null;

    [Tooltip("Меню конца игры")]
    [SerializeField]
    GameObject End_menu = null;

    int Score_value = 0;//Количество очков

    private void OnEnable()
    {
        if (GameObject.FindObjectOfType<Administrator_game>())
        {
            Administrator_game.Instance.D_Add_score += Add_score;
            Administrator_game.Instance.D_End_game += End_game;
        }
    }

    private void OnDisable()
    {
        if (GameObject.FindObjectOfType<Administrator_game>())
        {
            Administrator_game.Instance.D_Add_score -= Add_score;
            Administrator_game.Instance.D_End_game -= End_game;
        }
    }

    void Add_score()//Добавить очко
    {
        Score_value++;
        Score_text.text = Score_value.ToString();
    }

    void End_game()
    {
        End_menu.SetActive(true);
    }
}
