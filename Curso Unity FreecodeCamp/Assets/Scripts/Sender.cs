using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sender : MonoBehaviour
{

    //public delegate void PlayerDied(); //compañia de periodicos
    //public static event PlayerDied playerDiedInfo; //periodico como tal

    public delegate void PlayerDied(bool isAlive);
    public static event PlayerDied playerDiedInfo;

    private bool isAlive;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("ExecuteEvent", 5f); //esto hace que se llame a la funcion execute event, despues de que hayan pasado cinco segundos una vez se haya ejecutado esta linea y creo que despues se llama constantemente
    
       
    }

    void ExecuteEvent()
    {
        if (playerDiedInfo != null)
        {
            playerDiedInfo(true); // en el momento en el que se crea el gameobject, como en reciver tenemos mpuesto Sender.playerDiedInfo += PlayerDiedListener. Esto ya no seria null y por tanto
            //no seria null
        }
    }

  
}
