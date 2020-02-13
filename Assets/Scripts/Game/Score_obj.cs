//Подбираемые очки 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_obj : MonoBehaviour
{
    [Tooltip("Частицы")]
    [SerializeField]
    GameObject Prefab_particle_explosion = null;

    private void OnEnable()
    {
        if (GameObject.FindObjectOfType<Administrator_game>())
            Creature_score_obj.Instance.Remove_pool(transform);
    }

    private void OnDisable()
    {
        if (GameObject.FindObjectOfType<Administrator_game>())
            Creature_score_obj.Instance.Add_pool(transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player_control>())
        {
            Instantiate(Prefab_particle_explosion, transform.position, Quaternion.identity);
            Administrator_game.Instance.D_Add_score.Invoke();
            gameObject.SetActive(false);
        }
    }

}
