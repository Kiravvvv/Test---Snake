using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	[Tooltip("Чёрный фон для затемнения")]
	[SerializeField]
	GameObject Fon_black = null;

    private void Awake()
    {
        if (Fon_black.activeSelf == false)
            Fon_black.SetActive(true);
    }

    //Запустить затемнение и Загрузить уровень
    public void Start_game(){
        Fon_black.transform.Find("Fon_black_end").gameObject.SetActive(true);

    }

	//Выйти из игры
	public void Exit(){
		Application.Quit ();
	}
}
