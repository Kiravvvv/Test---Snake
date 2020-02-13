using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_control : Game_character
{
    [Tooltip("Камера")]
    [SerializeField]
    Camera Cam = null;

    [Tooltip("Префаб сегмента хвоста")]
    [SerializeField]
    GameObject Prefab_tail = null;

    CharacterController CharacterController_ = null;//Контроллер персонажа

    bool Stop_movement = false;//Остановить

    List<Transform> Tail_segments = new List<Transform>();//Лист сегментов хвоста

    protected override void Start()
    {
        if (!CharacterController_ && GetComponent<CharacterController>())
            CharacterController_ = GetComponent<CharacterController>();

        base.Start();

        Tail_segments.Add(My_transform);
    }

    private void OnEnable()
    {
        if(GameObject.FindObjectOfType<Administrator_game>())
        Administrator_game.Instance.D_Add_score += Add_segment;
    }

    private void OnDisable()
    {
        if (GameObject.FindObjectOfType<Administrator_game>())
            Administrator_game.Instance.D_Add_score -= Add_segment;
    }

    void Update()
    {
        if (!Stop_movement)
        {
            Movement_();

            Rotation();
        }
    }

    void Add_segment()
    {
     Transform last_segment = Tail_segments[Tail_segments.Count - 1];
        float speed_segment = Tail_segments.Count == 1 ? Speed : last_segment.GetComponent<Tail_segment>().Speed*0.98f;

      GameObject tail = Instantiate(Prefab_tail, last_segment.position, Quaternion.identity);

      tail.GetComponent<Tail_segment>().Preparation(last_segment, speed_segment);
        Tail_segments.Add(tail.transform);
    }

    void Movement_()//Передвижение
    {
        int vector_forward = 1;//Направление движения вперёд

        Vector3 direction = My_transform.TransformDirection(Vector3.forward * vector_forward);

        float cur_speed = Speed;

        CharacterController_.SimpleMove(direction * cur_speed);

    }

    void Rotation()//Поворот
    {
        Vector3 mousePosMain = Input.mousePosition;
        mousePosMain.z = Cam.transform.position.y;
        Vector3 curPosition = Cam.ScreenToWorldPoint(mousePosMain);
        Vector3 lookPos = curPosition - transform.position;
        lookPos.y = 0;
        transform.rotation = Quaternion.LookRotation(lookPos);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall" || other.tag == "Tail")
            End_game();
    }

    void End_game()//Конец игры
    {
        GetComponent<Sound_control>().Sound_play_1();
        Administrator_game.Instance.D_End_game.Invoke();
        Stop_movement = true;
    }

}
