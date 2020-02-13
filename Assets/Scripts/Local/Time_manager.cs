//Скрипт отвечающий за ход времени в игре
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time_manager : MonoBehaviour {

	//Остановить время
	public void Time_stop(){
		Time.timeScale = 0;
	}

	//Остановить время
	public void Time_play(){
		Time.timeScale = 1;
	}

	//Замедлить время
	public void Time_slowdown(float tm){
		Time.timeScale = tm;
	}
}
