using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receiver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OmEnable() //esto se llama cada vez que un objeto es enabled
    {
        Sender.playerDiedInfo += PlayerDiedListener; //te suscribe al evento, al periodico.
    }

    private void OnDisable() //esto se llama cada vez que un objeto es disabled
    {
        Sender.playerDiedInfo -= PlayerDiedListener; //te desuscribe del evento, del servicio de que te envien un periodico

    }
    void PlayerDiedListener(bool alive)
    {
        print("Event has called this function to execute +" + alive);
    }
}
