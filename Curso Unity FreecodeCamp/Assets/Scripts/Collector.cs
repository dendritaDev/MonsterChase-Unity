using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private string ENEMY_TAG = "Enemy";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(ENEMY_TAG))
        {
            Destroy(collision.gameObject); //aqui no destruimos el gameobject del script, es decir, el collector, sino el gameobject con el que este gameobject ha chocado, es decir: enemy
        }
    }
}
