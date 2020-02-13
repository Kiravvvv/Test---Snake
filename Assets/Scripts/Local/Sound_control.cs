//Скрипт который содержит звуки.
//Вешать на всё, что издаёт звуки.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

enum Type_sound
{
    Music,
    Effect
}

public class Sound_control : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler
{
    [Tooltip("В зависимости от этого будет применятся настройка громкости музыки или звуков")]
    [Header("Тип издаваемых звуков")]
    [SerializeField]
    Type_sound Type = Type_sound.Music;

    [Header("Компонент динамик")]
    public AudioSource Audioo = null;

    [Header("Активность объекта")]
    [Tooltip("Звук который будет проигрыватся при включение объекта")]
    [SerializeField]
    AudioClip Sound_enable = null;

    [Tooltip("Звук который будет проигрыватся при выключение/уничтожение объекта")]
    [SerializeField]
    AudioClip Sound_disable = null;

    [Header("Если это UI")]
    [Tooltip("Звук который будет проигрыватся при наведение курсора на объект")]
    [SerializeField]
    AudioClip Sound_OnPointerEnter = null;

    [Tooltip("Звук который будет проигрыватся при нажимание")]
    [SerializeField]
    AudioClip Sound_OnPointerDown = null;

    [Tooltip("Звук который будет проигрыватся при отпускание")]
    [SerializeField]
    AudioClip Sound_OnPointerUp = null;

    [Header("Если это игровой объект")]
    [Tooltip("Звук который будет проигрыватся при клике по этому объекту")]
    [SerializeField]
    AudioClip Sound_click = null;

    [Header("Прочие звуки")]
    [Header("Проигрываемые звуков и музыки")]
    [Tooltip("Звуки которые можно использовать как зацикленным образом, так и как одноразовые")]
    [SerializeField]
    AudioClip Sound_and_loop_1 = null;

    [Tooltip("Звуки которые можно использовать как зацикленным образом, так и как одноразовые")]
    [SerializeField]
    AudioClip Sound_and_loop_2 = null, Sound_and_loop_3 = null, Sound_and_loop_4 = null, Sound_and_loop_5 = null;

    [Tooltip("Одноразовые звуки")]
    [SerializeField]
    AudioClip Sound_6 = null, Sound_7 = null, Sound_8 = null, Sound_9 = null, Sound_10 = null;

    [Tooltip("Спецефичные звуки")]
    [SerializeField]
    AudioClip Attack = null, Dead = null, Walk = null, Run = null, Jump = null;

    private float Default_value;

    void Awake()
    {
        if (Audioo == null && GetComponent<AudioSource>())
            Audioo = GetComponent<AudioSource>();
        else {
            if(Type == Type_sound.Effect)
            Audioo = GameObject.Find("Audio").transform.Find("Effect").GetComponent<AudioSource>();
            else if (Type == Type_sound.Effect)
            Audioo = GameObject.Find("Audio").transform.Find("Music").GetComponent<AudioSource>();
        }


        Default_value = Audioo.volume;

        if (Audioo)
            Preparation_sound();


        if (FindObjectOfType<Setting_menu>()){
            if (Type == Type_sound.Music)
                Setting_menu.Instance.Music_d += Change_value;
            else
                Setting_menu.Instance.Effect_sound_d += Change_value;
        }

    }

    void OnEnable()
    {
        Preparation_sound();

        if (Sound_enable != null)
            Audioo.PlayOneShot(Sound_enable);

    }

    private void OnDisable()
    {
        if (Sound_disable != null && Audioo != null)
            Audioo.PlayOneShot(Sound_disable);
    }

    private void OnMouseDown()
    {
        if (Sound_click != null)
            Audioo.PlayOneShot(Sound_click);
    }


    public void OnPointerEnter(PointerEventData eventData)//Звук который будет проигрыватся при наведение курсора на объект
    {
        if (Sound_OnPointerEnter != null)
            Audioo.PlayOneShot(Sound_OnPointerEnter);
    }

    public void OnPointerDown(PointerEventData eventData)//Звук который будет проигрыватся при нажимание на кнопку
    {
        if (Sound_OnPointerDown != null)
            Audioo.PlayOneShot(Sound_OnPointerDown);
    }

    public void OnPointerUp(PointerEventData eventData)//Звук который будет проигрыватся при отпускание кнопки
    {
        if (Sound_OnPointerUp != null)
            Audioo.PlayOneShot(Sound_OnPointerUp);
    }

    void Change_value(float _value)//Изменение громкости
    {
        if (Audioo)
        {
            Audioo.volume = Default_value * _value;
        }
    }
   
    public void Preparation_sound() //Настройка звука в начале
    {

        if (Type == Type_sound.Music)
        {
            if (PlayerPrefs.HasKey("Music_value"))
                Audioo.volume = Default_value * PlayerPrefs.GetFloat("Music_value");
            else
                Audioo.volume = Default_value * 1;
        }

        else
        {
            if (PlayerPrefs.HasKey("Effect_sound_value"))
                Audioo.volume = Default_value * PlayerPrefs.GetFloat("Effect_sound_value");
            else
                Audioo.volume = Default_value * 1;
        }
    }

    //Запускаемые звуки которые зациклены
    public void Sound_play_loop_1()
    {
        Audioo.clip = Sound_and_loop_1;
        Audioo.loop = true;
        Audioo.Play();
    }

    public void Sound_play_loop_2()
    {
        if (Audioo)
        {
            Audioo.clip = Sound_and_loop_2;
            Audioo.loop = true;
            Audioo.Play();
        }
    }

    public void Sound_play_loop_3()
    {
        if (Audioo)
        {
            Audioo.clip = Sound_and_loop_3;
            Audioo.loop = true;
            Audioo.Play();
        }
    }

    public void Sound_play_loop_4()
    {
        if (Audioo)
        {
            Audioo.clip = Sound_and_loop_4;
            Audioo.loop = true;
            Audioo.Play();
        }
    }

    public void Sound_play_loop_5()
    {
        if (Audioo)
        {
            Audioo.clip = Sound_and_loop_5;
            Audioo.loop = true;
            Audioo.Play();
        }
    }

    //Другие звуки для использования одноразовые
    public void Sound_play_1()
    {
        if (Audioo)
            Audioo.PlayOneShot(Sound_and_loop_1);
    }

    public void Sound_play_2()
    {
        if (Audioo)
            Audioo.PlayOneShot(Sound_and_loop_2);
    }

    public void Sound_play_3()
    {
        if (Audioo)
            Audioo.PlayOneShot(Sound_and_loop_3);
    }

    public void Sound_play_4()
    {
        if (Audioo)
            Audioo.PlayOneShot(Sound_and_loop_4);
    }

    public void Sound_play_5()
    {
        if (Audioo)
            Audioo.PlayOneShot(Sound_and_loop_5);
    }

    public void Sound_play_6()
    {
        if (Audioo)
            Audioo.PlayOneShot(Sound_6);
    }

    public void Sound_play_7()
    {
        if (Audioo)
            Audioo.PlayOneShot(Sound_7);
    }

    public void Sound_play_8()
    {
        if (Audioo)
            Audioo.PlayOneShot(Sound_8);
    }

    public void Sound_play_9()
    {
        if (Audioo)
            Audioo.PlayOneShot(Sound_9);
    }

    public void Sound_play_10()
    {
        if (Audioo)
            Audioo.PlayOneShot(Sound_10);
    }

    public void Sound_Attack()
    {
        if (Audioo)
            Audioo.PlayOneShot(Attack);
    }

    public void Sound_Walk()
    {
        if (Audioo)
            Audioo.PlayOneShot(Walk);
    }

    public void Sound_Run()
    {
        if (Audioo)
            Audioo.PlayOneShot(Run);
    }

    public void Sound_Jump()
    {
        if (Audioo)
            Audioo.PlayOneShot(Jump);
    }

    public void Sound_Dead()
    {
        if (Audioo)
            Audioo.PlayOneShot(Dead);
    }

}
