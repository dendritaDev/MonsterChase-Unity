using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
  

    public void PlayGame() //para que cuando apretemos un boton se ejecute eto tenemos que hacerla publica y en el boton UI en el apartado ONclick() meter este game object y seleccionar la funcion
    {
        int selectedCharacter =
            int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        //esto lo que hace es convertir la representacion de un numero en string en un numero real (int). Rollo "1" a 1.

        GameManager.instance.CharIndex = selectedCharacter; //llamamos a el script game manager, a su static y como es static podemos acceder a todo lo public y accedemos a charindex y le damos selected character

        //static variable: es una varable de una clase, (las funcioens tmb pueden ser staticas) que pueden ser accedidas desde otra clase sin definir un objeto como tal.
        //P.e:
        //Si tenemos una clase warrior con dos npublic static variables un name y un power, desde aqui mismo sin declarar nada de warrior ni incluir nada, podriamos hacer:
        //Warrior.name = "Uri";
        //Warrior.power =5;
        //Y eso lo podemos ahcer sin incluir nada ni crear un objeto rollo Warrior w1;



        SceneManager.LoadScene("GamePlay"); //esto lo que hace es que si se pulsa el boton, se pasa a la escena de gameplay.
    }


}
