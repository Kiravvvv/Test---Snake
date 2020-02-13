//Скрипт для назначения клавиш управления
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Input_setting : MonoBehaviour
{
    [Tooltip("Текст кнопки")]
    [SerializeField]
    private Text Button_text = null;

    [Tooltip("Ключ при сохранение данных")]
    [SerializeField]
    private string Save_key_name = null;

    [Tooltip("Клавиша по умолчанию")]
    [SerializeField]
    private KeyCode Default_key_code;

    private IEnumerator Coroutine;
    private string TmpKey;//Буфер названия назначенной клавиши

    private void Start()
    {
        if (PlayerPrefs.HasKey(Save_key_name))
        {
            Button_text.text = PlayerPrefs.GetString(Save_key_name);
            string key_name = PlayerPrefs.GetString(Save_key_name);
            Default_key_code = (KeyCode)System.Enum.Parse(typeof(KeyCode), key_name);
        }
        else
        {
            PlayerPrefs.SetString(Save_key_name, Default_key_code.ToString());
            Button_text.text = Default_key_code.ToString();
        }


    }

    public void ButtonSetKey() // событие кнопки, для перехода в режим ожидания
    {
        TmpKey = Button_text.text;
        Button_text.text = "???";
        Coroutine = Wait();
        StartCoroutine(Coroutine);
    }

    // Ждем, когда игрок нажмет какую-нибудь клавишу, для привязки
    // Если будет нажата клавиша 'Escape', то отмена
    IEnumerator Wait()
    {
        while (true)
        {
            yield return null;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Button_text.text = TmpKey;
                StopCoroutine(Coroutine);
            }

            foreach (KeyCode k in KeyCode.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(k) && !Input.GetKeyDown(KeyCode.Escape))
                {
                    Default_key_code = k;
                    Button_text.text = k.ToString();
                    PlayerPrefs.SetString(Save_key_name, k.ToString());

                    if (FindObjectOfType<Setting_menu>())
                        Setting_menu.Instance.Input_key_control();

                    StopCoroutine(Coroutine);
                }
            }
        }
    }
}
