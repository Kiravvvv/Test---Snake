//Скрипт управления камерой(камера следует за игроком)
//Если игрок передвигаеться физикой, то не забыть включить ему интерполяцию.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_control : MonoBehaviour {

    enum Type_camera
    {
        Horizontal_and_Vertical,
        Horizontal,
        Vertical,
        Vector3D,
        Vector3_X_and_Z
    }

    [Header("Тип слежения камеры")]
    [SerializeField]
    Type_camera Camera_type = Type_camera.Horizontal_and_Vertical;

    [Header("Дополнительное смещение камеры")]
    [SerializeField]
    Vector3 Offset = new Vector3(0,0,0);

    [Header("Объект который приследует камера")]
	[SerializeField]
	Transform Target = null;

	[Header("Коэффициент сглаживания")]
	[SerializeField]
	float Smoothing = 2;

		void FixedUpdate()
	{
        if(Target != null)
        Movement_camera();
    }

    void Movement_camera()//Перемещение камеры
    {
        //Плавное "скольжение" к преследуемому объекту
        if (Camera_type == Type_camera.Horizontal_and_Vertical)
            transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, -10), new Vector3(Target.position.x + Offset.x, Target.position.y + Offset.y, -10), Time.deltaTime * Smoothing);
        else if (Camera_type == Type_camera.Horizontal)
            transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, -10), new Vector3(Target.position.x + Offset.x, transform.position.y, -10), Time.deltaTime * Smoothing);
        else if (Camera_type == Type_camera.Vertical)
            transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, -10), new Vector3(transform.position.x, Target.position.y + Offset.y, -10), Time.deltaTime * Smoothing);
        else if (Camera_type == Type_camera.Vector3D)
            transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(Target.position.x + Offset.x, Target.position.y + Offset.y, Target.position.z + Offset.z), Time.deltaTime * Smoothing);
        else if (Camera_type == Type_camera.Vector3_X_and_Z)
            transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(Target.position.x + Offset.x, transform.position.y + Offset.y, Target.position.z + Offset.z), Time.deltaTime * Smoothing);
    }
}
