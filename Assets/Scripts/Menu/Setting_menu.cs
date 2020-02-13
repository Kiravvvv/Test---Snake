//Скрипт настроек и задаёт положение настроек согласно сохранению
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting_menu : Singleton<Setting_menu>
{

    [Header("Настройки эффектов")]
    [Tooltip("Ползунок громкости эффектов")]
    [SerializeField]
    private Slider Effect_sound_slider = null;

    [Tooltip("Картинка громкости эффектов")]
    [SerializeField]
    Image Image_effect_sound = null;

    [Tooltip("Картинки громкости эффектов")]
    [SerializeField]
    Sprite[] Sprites_effect_sound = new Sprite[0];

    public delegate void Effect_sound_delegate(float _value);//Делегат изменения громкости эффектов
    public Effect_sound_delegate Effect_sound_d;//Экземпляр делегата изменения громкости эффектов

    [Header("Настройки музыки")]
    [Tooltip("Ползунок громкости музыки")]
    [SerializeField]
    private Slider Music_slider = null;

    [Tooltip("Картинка громкости музыки")]
    [SerializeField]
    Image Image_music = null;

    [Tooltip("Картинки громкости музыки")]
    [SerializeField]
    Sprite[] Sprites_music = new Sprite[0];

    public delegate void Music_delegate(float _value);//Делегат изменения громкости музыки
    public Music_delegate Music_d;//Экземпляр делегата изменения громкости музыки

    [Header("Настройки оповещения")]
    [Tooltip("Галочка оповещения")]
    [SerializeField]
    private Toggle Alert_toggle = null;

    [Tooltip("Картинка оповещения")]
    [SerializeField]
    Image Image_alert = null;

    [Tooltip("Картинки оповещения")]
    [SerializeField]
    Sprite[] Sprites_alert = new Sprite[0];

    [Header("Настройки оповещения")]
    [Tooltip("Галочка вибрации")]
    [SerializeField]
    private Toggle Vibration_toggle = null;

    [Tooltip("Картинка вибрации")]
    [SerializeField]
    Image Image_vibration = null;

    [Tooltip("Картинки вибрации")]
    [SerializeField]
    Sprite[] Sprites_vibration = new Sprite[0];

    [Header("Выбранный язык")]
    [Tooltip("Список выбора языка")]
    [SerializeField]
    private Dropdown Language_option = null;

    [Tooltip("Картинка языка")]
    [SerializeField]
    Image Image_language = null;

    [Tooltip("Картинки языков")]
    [SerializeField]
    Sprite[] Sprites_language = new Sprite[0];

    public delegate void Language_delegate(int _index);//Делегат изменения языка
    public Language_delegate Language_d;//Экземпляр делегата изменения языка

    public delegate void Input_key_delegate();//Делегат изменения клавиш управления
    public Input_key_delegate Input_key_d;//Экземпляр делегата изменения клавиш управления

    void OnEnable()
    {
        Start_preparation();
    }

    void Start_preparation()//Подготовка при открытие меню
    {
        if (PlayerPrefs.HasKey("Effect_sound_value"))
            Effect_sound_slider.value = PlayerPrefs.GetFloat("Effect_sound_value");

        if (PlayerPrefs.HasKey("Music_value"))
            Music_slider.value = PlayerPrefs.GetFloat("Music_value");

        if (PlayerPrefs.HasKey("Alert_bool"))
        {
            if (PlayerPrefs.GetInt("Alert_bool") == 1)
                Alert_toggle.isOn = true;
            else
                Alert_toggle.isOn = false;
        }

        if (PlayerPrefs.HasKey("Vibration_bool"))
        {
            if (PlayerPrefs.GetInt("Vibration_bool") == 1)
                Vibration_toggle.isOn = true;
            else
                Vibration_toggle.isOn = false;
        }

        if (PlayerPrefs.HasKey("Language_option"))
            Language_option.value = PlayerPrefs.GetInt("Language_option");

        Preparation();
    }

    void Preparation()//Перепроверка и подготовка
    {
        if (Image_effect_sound && PlayerPrefs.HasKey("Effect_sound_value"))
        {
            if (PlayerPrefs.GetFloat("Effect_sound_value") == 1)
                Image_effect_sound.sprite = Sprites_effect_sound[0];
            else if (PlayerPrefs.GetFloat("Effect_sound_value") < 1 && PlayerPrefs.GetFloat("Effect_sound_value") > 0.5f)
                Image_effect_sound.sprite = Sprites_effect_sound[1];
            else if (PlayerPrefs.GetFloat("Effect_sound_value") > 0 && PlayerPrefs.GetFloat("Effect_sound_value") < 0.5f)
                Image_effect_sound.sprite = Sprites_effect_sound[2];
            else if (PlayerPrefs.GetFloat("Effect_sound_value") == 0)
                Image_effect_sound.sprite = Sprites_effect_sound[3];
        }

        if (Image_music && PlayerPrefs.HasKey("Music_value"))
        {
            if (PlayerPrefs.GetFloat("Music_value") == 1)
                Image_music.sprite = Sprites_music[0];
            else if (PlayerPrefs.GetFloat("Music_value") < 1 && PlayerPrefs.GetFloat("Music_value") > 0.5f)
                Image_music.sprite = Sprites_music[1];
            else if (PlayerPrefs.GetFloat("Music_value") > 0 && PlayerPrefs.GetFloat("Music_value") < 0.5f)
                Image_music.sprite = Sprites_music[2];
            else if (PlayerPrefs.GetFloat("Music_value") == 0)
                Image_music.sprite = Sprites_music[3];
        }

        if (Image_alert && PlayerPrefs.HasKey("Alert_bool"))
        {
            if (PlayerPrefs.GetInt("Alert_bool") == 1)
                Image_alert.sprite = Sprites_alert[0];
            else
                Image_alert.sprite = Sprites_alert[1];
        }

        if (Image_vibration && PlayerPrefs.HasKey("Vibration_bool"))
        {
            if (PlayerPrefs.GetInt("Vibration_bool") == 1)
                Image_vibration.sprite = Sprites_vibration[0];
            else
                Image_vibration.sprite = Sprites_vibration[1];
        }

        if (Image_language && PlayerPrefs.HasKey("Language_option"))
        {
            Image_language.sprite = Sprites_language[PlayerPrefs.GetInt("Language_option")];
        }

    }

    public void Input_key_control()//Изменение клавиш управления
    {
        Input_key_d?.Invoke();
    }

    public void Language_control(int _index)//Изменение языка
    {
        PlayerPrefs.SetInt("Language_option", _index);
        PlayerPrefs.Save();

        Language_d?.Invoke(_index);

        Preparation();
    }

    public void Sound_effect_control(float _value)//Изменение звука эффектов
    {
        PlayerPrefs.SetFloat("Effect_sound_value", _value);
        PlayerPrefs.Save();

        Effect_sound_d?.Invoke(_value);

        Preparation();
    }

    public void Sound_music_control(float _value)//Изменение звука музыки
    {
        PlayerPrefs.SetFloat("Music_value", _value);
        PlayerPrefs.Save();


        Music_d?.Invoke(_value);

        Preparation();
    }

    public void Alert_control(bool _bool)//Изменение оповещения
    {
        PlayerPrefs.SetInt("Alert_bool", _bool? 1:0);

        PlayerPrefs.Save();
        Preparation();
    }

    public void Vibration_control(bool _bool)//Изменение вибрации
    {
        PlayerPrefs.SetInt("Vibration_bool", _bool ? 1 : 0);

        PlayerPrefs.Save();
        Preparation();
    }
}
