using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    [SerializeField] //esto es que escondamos la variable en la interfaz de unity, esto lo hacemos pq la necesitamos q sea publica pero no queremos que se vea
    public int speed;
    private Rigidbody2D myBody;

    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();

      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myBody.velocity = new Vector2(speed, myBody.velocity.y); //podemos hacer fisicas tanto con cosas como AddForce, como modificando las velocidades.  Para x le damos la speed que hemos creado. Para la y le damos la misma que ya tenia,
                                                                 //puesto que no tenemos intencion de que la velocidad en Y del personaje cambie 
                                                                 //La velocidad es algo que se suma a la posicion cada frame
    }


} //class
