using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;

    private Vector3 tempPos;

    [SerializeField]
    private float minX, maxX;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform; //aqui le decimos que nos encuentre un gameobject con el tag  "PLayer" y que nos coja su info del componente transofrm y se lo de a nuestra variable player.
    }

    // Update is called once per frame
    void LateUpdate() //como queremos que el seguimiento de la camara se de despues del update del player, lo ponemos en lo que se llama lateupdate, que sería como un update pero que se da despues de que todos los updates se hayan dado. 
        //es decir el lateupdate se da despues de que se hayan hecho todos los calculos habidos en update: p.e la posicion del player ya se haya recalculado
    {
        tempPos = transform.position; //Le asignamos a tempPos la posicion de la camara
        tempPos.x = player.position.x;//le damos al eje X de tempPos la posicion x del player

        if(tempPos.x < minX)
        {
            tempPos.x = minX;
        }
        else if (tempPos.x > maxX)
        {
            tempPos.x = maxX;
        }

        transform.position = tempPos; //como estamos en el script del gameobject camera hacemos que la posicion de su compomente transform sea igual a la variable temPos.

    }
}
