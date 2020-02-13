//Скрипт ссылка на сайт или ещё куда
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Link : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	[Tooltip("Ссылка")]
	[SerializeField]
	string link = "https://vk.com/pixel_star";

	[Tooltip("Цвет при наведение и убирание курсора")]
	[SerializeField]
	Color color_enter = Color.green, color_exit = Color.black;

	public void OnPointerEnter(PointerEventData eventData)
	{
		transform.Find("Text").GetComponent<Text>().color = color_enter; 
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		transform.Find("Text").GetComponent<Text>().color = color_exit; 
	}


	public void Active() 
	{ 
		Application.OpenURL (link); 
	} 
}
