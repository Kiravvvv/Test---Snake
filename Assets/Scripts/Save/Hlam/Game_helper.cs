//Скрипт который будет следить за объектами на сцене
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Библеотека для работы с XML
using System.Xml.Linq;
//Работа с сохранениями файлов
using System.IO;
//Для работы с форматами при переводе из XML в float
using System.Globalization;

public class Game_helper : MonoBehaviour {

	//Путь сохраняемого файла с сохранениями Xml
	private string Path;
    
	//Лист(список) сохраняемых предметов на сцене 
	public List<Save_Object> Objects = new List<Save_Object>();

    private void Awake(){
		
		//Маршрут сохранения и загрузки
		//Если игра на ПК
		if (Application.platform != RuntimePlatform.Android) {
			System.IO.Directory.CreateDirectory(Application.dataPath + "/Save_game");
			Path = Application.dataPath + "/Save_game/Save_game_" + Application.productName + ".xml";
		}
		//Если игра на Андроид
		else {
			System.IO.Directory.CreateDirectory(Application.persistentDataPath + "/Save_game");
			Path = Application.persistentDataPath + "/Save_game/Save_game_" + Application.productName + ".xml";
		}
	}

	//Сохранить все объекты в документ
	public void Save(){
		//Создаёт корневое название для документа сохранения
		XElement root = new XElement ("Root");

		//Цикл добавляющий поочерёдно все объекты в файл сохранения XML
		foreach (Save_Object obj in Objects) {
			root.Add (obj.GetElement ());
		}

		//Сохранить документ XML
		XDocument Save_document = new XDocument (root);

		File.WriteAllText(Path, Save_document.ToString());
	}

	//Загрузить сохранённые данные
	public void Load(){

//		XElement root = null;

		//Если нету сохранения
//		if (!File.Exists (Path)) {
			//Если есть сохранение начальной сцены
//			if (File.Exists (Application.persistentDataPath + "/test_save.xml"))
				//Берём из документа корневой элемент
//				root = XDocument.Parse (File.ReadAllText (Application.persistentDataPath + "/test_save.xml")).Element ("Root");
//		}
		//Если найдено сохранение
//		else {
//			root = XDocument.Parse (File.ReadAllText (Path)).Element ("Root");

//		}

//		if (root == null) {
//			Debug.Log ("Не получилось загрузить уровень");
//			return;
//		}

		XElement root = null;

		//Если найдено сохранение
		root = XDocument.Parse (File.ReadAllText (Path)).Element ("Root");

		//XElement instance_game = root.Element ("Game");

		//Сгенерировать сцену
		Generate_scene(root);

	}
    
    //Генерация сцены
    private void Generate_scene(XElement Root){

		//Цикл уничтожающий стартовые объекты
		foreach (Save_Object obj in Objects) {
			obj.Destroy_self ();
		}


		//Цикл переберающий элементы объектов
		foreach (XElement instance in Root.Elements("Instance")) {
            Vector3 position = Vector3.zero;
            Vector3 rotation = Vector3.zero;

            var c = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            c.NumberFormat.NumberDecimalSeparator = "."; // Разделитель. Если у тебя запятая, тогда ставь ","


            //Перенести позицию объекта из документа сохранения.

            position.x = float.Parse(instance.Attribute("P_x").Value, c);
            position.y = float.Parse(instance.Attribute("P_y").Value, c);
            position.z = float.Parse(instance.Attribute("P_z").Value, c);
            //float position_y = System.Single.Parse(instance.Attribute("P_y").Value, System.Globalization.NumberStyles.Number);
            //float position_z = float.Parse(instance.Attribute ("P_z").Value, System.CultureInfo.InvariantCulture);

            //Перенести позицию объекта из документа сохранения.
            rotation.x = float.Parse(instance.Attribute("R_x").Value, c);
            rotation.y = float.Parse(instance.Attribute("R_y").Value, c);
            rotation.z = float.Parse(instance.Attribute("R_z").Value, c);

            //Перенести поворот объекта из документа сохранения.
            //rotation = Quaternion.Euler(float.Parse (instance.Attribute ("R_x").Value), float.Parse (instance.Attribute ("R_y").Value), float.Parse (instance.Attribute ("R_z").Value));

            //Загрузить объект из префаба
            //Instantiate(Resources.Load<GameObject>(instance.Value), position, Quaternion.identity);
            Instantiate(Resources.Load<GameObject>(instance.Value), position, Quaternion.Euler(rotation));
	}

}
}
