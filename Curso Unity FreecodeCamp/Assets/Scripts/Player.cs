using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Como los hemos hecho public, los vemos en la interfaz de unity. Estos valores seran los que saldran x defecto para player, que los cambiemos en la interfaz, no quiere decir
    //que cambien aqui. Por defecto siempre seran los que hayamos puesto aqui.

    //public float moveForce = 10f;
    //public float jumpForce = 11f;

    /*[SerializeField]*/ //--> si ponemos esto antes de una variable private, lo que nos permite es que sean realmente private y no se puedan acceder desde otras clases
                         //pero que aun asi APAREZCAN y puedan ser modificadas en la INTERFAZ de UNITY.

    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;

    //Declaración de componentes
    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    private Animator anim;
    private string WALK_ANIMATION = "Walk";
    private string GROUND_TAG = "Ground";

    private bool isGrounded;
    

    // Start is called before the first frame update
    void Start()
    {

        //Obtencion de la referencia de la informacion de los componentes: Si no hacemos previamente antes esto, nos dará error pq nos dirá que la referencia del objeto que intetnamos utilizar es nula:
        myBody = GetComponent<Rigidbody2D>(); //esto sería lo mismo que hacer un serialized en la declaracion de los componentes y despues arrastrar en la interfaz de unity cada cosa. P.e en mybody arrastrar el compomente de Rigibdbody2d.
                                              //Tambien podriamos hacer lo mismo ^ si hacemos que la variable sea publica
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyBoard();
        AnimatePlaeyer();
        PlayerJump();
    }

    private void FixedUpdate() //Update se llama cada frame. Mientras que FixedUpdate no se llama cada frame, sino cada 0.02s. Esto se puede ver cada cuanto es en: Edit - project settings - Time: "Fixed Timestep"
                               //Esto se hace para tema de rendimiento. En fixedupdate ponemos funciones que no necesitamos que esten haciendose literalmente cada frame. FixedUpdate se suele usar por ese mismo motivo para calculos físicos o cosas asi
    { 
        PlayerJump();
    }

    void PlayerMoveKeyBoard()
    {
        movementX = Input.GetAxisRaw("Horizontal"); //GetAxis hace una variacion mas pequeña: 0, 0.2, 0.4, 0.6... Meintras que para variaciones mas grandes es mejor GetAxisRaw
        //"Horizontal" funcionará para: Tecla D y para la Flecha de la derecha (positivamente), mientras que Tecla A y flecha izquierda (negativamente)

        //movementX podrá ser 3 valores: -1(cuando vamos a la izquierda), 0 (cuando el perosnaje está quieto), 1(cuando vamos a la derecha). 

        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;

        //Time.deltaTime: Si no lo multiplicasemos por deltatime se moveria MUCHISIMO. Deltatime es el tiempo que ha pasado desde el ultimo frame. Un valor muy pequeño con lo que disminuye mucho la cantidad de lo que se le suma
        //Despues lo multiplicamos por moveForce para aumentar esta cantidad por lo que nos interese.
        
    }

    void AnimatePlaeyer()
    {
        if(movementX < 0) //moviéndo a la derecha
        {
            anim.SetBool(WALK_ANIMATION, true); //aqui hacemos que el bool de anim que definimos en la animacion walk sea true y por tanto se active la animacion: Eso es lo que hace la funcionSetbool es un setter, al que le tenemos que dar el nombre del
            //bool y el valor que le queremos dar
            sr.flipX = true; //para que mire a la izquierda y no camine de espaldas
        }
        else if (movementX > 0) //moviendo a la izquierda
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false; //vuelva a mirar a la derecha

        }
        else //estamos quietos
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
        
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded) //usa el boton de defecto de cada plataforma para hacer un salto. En PC: espacio, en PS4: boton A, en XBOX: boton A. 
                                         //esto es presionar. Tambien tenemos GetButtonUp (cuando se suelta retorna true).
                                         //GetButton (cuando se mantiene retorna true constantemente).
        {
            Debug.Log("Jump Pressed");
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse); //Aqui le damos a la Y el jumpForce. El .Impulse es un tipo de fuerza que se hace con una fuerza de impulso.
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //esto sno permite detectar colisiones entre 2 objetos
    {
        if(collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
            Debug.Log("We landed on ground");
        }
    }

}
