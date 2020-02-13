//Скрипт для того, что бы он добавлял объект в скрипт сохнанения сцены
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Библеотека для работы с XML
using System.Xml.Linq;

public class Save_Object : MonoBehaviour {

	[Tooltip("Местоположение префаба")]
	[SerializeField]
	private string Prefab_project_position = "Prefabs/3D/";

	//Ссылка на скрипт следящий за объектами
	private Game_helper Helper;

	private void Awake(){
		
		//Поиск скрипта и заполнения на него ссылки
		Helper = FindObjectOfType<Game_helper> ();
	}

	private void Start () {
		//Добавляет этот объект в список сохраняемых объектов на сцене
		Helper.Objects.Add (this);
	}

	private void OnDestroy(){
		//Вычёркивает этот объект из списка сохраняемых объектов при его уничтожение
		Helper.Objects.Remove (this);
	}

	public XElement GetElement(){
		//Сохраняемый параметр расположения в прострастве в атрибут XML
		//XAttribute P_x = new XAttribute("P_x", transform.position.x);
		XAttribute P_x = new XAttribute("P_x", transform.position.x);
		XAttribute P_y = new XAttribute("P_y", transform.position.y);
		XAttribute P_z = new XAttribute("P_z", transform.position.z);

		XAttribute R_x = new XAttribute("R_x", transform.eulerAngles.x);
		XAttribute R_y = new XAttribute("R_y", transform.eulerAngles.y);
		XAttribute R_z = new XAttribute("R_z", transform.eulerAngles.z);

		//Составление атрибута XML
		XElement element = new XElement ("Instance", Prefab_project_position, P_x, P_y, P_z, R_x, R_y, R_z);

		//Вернуть всё собранное обратно в скрипт задействующий эту функцию
		return element;
	}

	//Функция уничнотожения объекта
	public void Destroy_self(){
		Destroy (gameObject);
	}

}
