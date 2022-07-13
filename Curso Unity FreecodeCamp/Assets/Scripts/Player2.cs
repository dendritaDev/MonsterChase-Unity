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
    private string GROUND_TAG2 = "Ground";
    private string ENEMY_TAG2 = "Enemy";

    private bool isGroundedP2;


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
        PlayerJump2();
    }

    void PlayerMoveKeyBoard2()
    {
        movementX2 = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movementX2, 0f, 0f) * Time.deltaTime * moveForce2;

    }

    void AnimatePlaeyer2()
    {
        if(movementX2 < 0) 
        {
            anim2.SetBool(WALK_ANIMATION2, true); 
            sr2.flipX = true; 
        }
        else if (movementX2 > 0) 
        {
            anim2.SetBool(WALK_ANIMATION2, true);
            sr2.flipX = false; 

        }
        else //estamos quietos
        {
            anim2.SetBool(WALK_ANIMATION2, false);
        }
        
    }

    void PlayerJump2()
    {
        if ( Input.GetButton("Jump") && isGroundedP2)
        {
            myBody2.AddForce(new Vector2(0f, jumpForce2), ForceMode2D.Impulse); 
            isGroundedP2 = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG2))
            isGroundedP2 = true;
            
        

        if (collision.gameObject.CompareTag(ENEMY_TAG2))
            Destroy(gameObject); 
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag(ENEMY_TAG2)) 
            Destroy(gameObject);
        

    }

}
