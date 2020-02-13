using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour {

	[Tooltip("Чёрный фон для затемнения")]
	[SerializeField]
	GameObject Fon_black = null;

    [Header("Ссылка на игровое меню")]
    [SerializeField]
    GameObject Canvas_game_menu = null;

    [Header("Номер сцены которую нужно загрузить")]
    [SerializeField]
    int Scene_number_ID = 0;

    [Header("Клавиша вкл/выкл меню ")]
    [SerializeField]
    KeyCode Exit_key = KeyCode.Escape;

    [Header("Ссылки на игровые вкладки")]
    [SerializeField]
    List<GameObject> Bookmark = new List<GameObject>();

    private void Awake()
    {
        if (Fon_black.activeSelf == false)
            Fon_black.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(Exit_key))
        {
            Enter_button();
        }

    }

    void Enter_button()//Включение и отключение игрового меню
    {
        if (!Canvas_game_menu.activeSelf)
            Canvas_game_menu.SetActive(true);
        else
        {
            bool null_bookmark = true;

            for (int x = 0; x < Bookmark.Count; x++)
            {
                if (Bookmark[x].activeSelf)
                {
                    null_bookmark = false;
                    Bookmark[x].SetActive(false);
                }
            }
            if (null_bookmark)
                Canvas_game_menu.SetActive(false);
        }
    }

    //Выход в главное меню
    public void Exit(){
		Fon_black.transform.Find("Fon_black_end").gameObject.SetActive (true);
        Fon_black.transform.Find("Fon_black_end").GetComponent<Load_scene>().Scene_number = Scene_number_ID;
        Time.timeScale = 1;
        Canvas_game_menu.SetActive (false);
	}

	//Перезагрузить сцену
	public void Restart(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex) ; 
		gameObject.SetActive (false);
		Time.timeScale = 1;
	}

	//Продолжить дальше
	public void Continue(){
        Canvas_game_menu.SetActive (false);
		Time.timeScale = 1;
	}
		
}
