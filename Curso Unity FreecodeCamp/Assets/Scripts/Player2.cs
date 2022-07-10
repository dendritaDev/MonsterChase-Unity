using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    //Como los hemos hecho public, los vemos en la interfaz de unity. Estos valores seran los que saldran x defecto para player, que los cambiemos en la interfaz, no quiere decir
    //que cambien aqui. Por defecto siempre seran los que hayamos puesto aqui.

    //public float moveForce = 10f;
    //public float jumpForce = 11f;

    /*[SerializeField]*/ //--> si ponemos esto antes de una variable private, lo que nos permite es que sean realmente private y no se puedan acceder desde otras clases
                         //pero que aun asi APAREZCAN y puedan ser modificadas en la INTERFAZ de UNITY.

    [SerializeField]
    private float moveForce2 = 10f;
    [SerializeField]
    private float jumpForce2 = 11f;

    private float movementX2;

    //Declaración de componentes
    private Rigidbody2D myBody2;
    private SpriteRenderer sr2;
    private Animator anim2;
    private string WALK_ANIMATION2 = "Player2-Walk";
    

    // Start is called before the first frame update
    void Start()
    {

        //Obtencion de la referencia de la informacion de los componentes: Si no hacemos previamente antes esto, nos dará error pq nos dirá que la referencia del objeto que intetnamos utilizar es nula:
        myBody2 = GetComponent<Rigidbody2D>(); //esto sería lo mismo que hacer un serialized en la declaracion de los componentes y despues arrastrar en la interfaz de unity cada cosa. P.e en mybody arrastrar el compomente de Rigibdbody2d.
                                              //Tambien podriamos hacer lo mismo ^ si hacemos que la variable sea publica
        anim2 = GetComponent<Animator>();
        sr2 = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyBoard2();
        AnimatePlaeyer2();
    }

    void PlayerMoveKeyBoard2()
    {
        movementX2 = Input.GetAxisRaw("Horizontal"); //GetAxis hace una variacion mas pequeña: 0, 0.2, 0.4, 0.6... Meintras que para variaciones mas grandes es mejor GetAxisRaw
        //"Horizontal" funcionará para: Tecla D y para la Flecha de la derecha (positivamente), mientras que Tecla A y flecha izquierda (negativamente)

        //movementX podrá ser 3 valores: -1(cuando vamos a la izquierda), 0 (cuando el perosnaje está quieto), 1(cuando vamos a la derecha). 

        transform.position += new Vector3(movementX2, 0f, 0f) * Time.deltaTime * moveForce2;

        //Time.deltaTime: Si no lo multiplicasemos por deltatime se moveria MUCHISIMO. Deltatime es el tiempo que ha pasado desde el ultimo frame. Un valor muy pequeño con lo que disminuye mucho la cantidad de lo que se le suma
        //Despues lo multiplicamos por moveForce para aumentar esta cantidad por lo que nos interese.
        
    }

    void AnimatePlaeyer2()
    {
        if(movementX2 < 0) //moviéndo a la derecha
        {
            anim2.SetBool(WALK_ANIMATION2, true); //aqui hacemos que el bool de anim que definimos en la animacion walk sea true y por tanto se active la animacion
            sr2.flipX = true; //para que mire a la izquierda y no camine de espaldas
        }
        else if (movementX2 > 0) //moviendo a la izquierda
        {
            anim2.SetBool(WALK_ANIMATION2, true);
            sr2.flipX = false; //vuelva a mirar a la derecha

        }
        else //estamos quietos
        {
            anim2.SetBool(WALK_ANIMATION2, false);
        }
        
    }



}
