using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance; //esto es el game manager, puesto que es de tipo game manager. Es decir esto es un objeto de game manager, que esta en modo static
    //por lo tanto podremos acceder a todo lo de este script desde otro script como el MainMenuController

    [SerializeField]
    private GameObject[] characters;

    private int _charIndex;
    public int CharIndex
    {
        get { return _charIndex; }
        set { _charIndex = value; }
    }

    private void Awake()
    {
        if(instance == null) //esto seria en singleton Pattern para que solo haya un gameobject de este gameobject que tiene este script
        {
            instance = this;
            DontDestroyOnLoad(gameObject); //esto hace que no se destruya el gameobject cuando se pase a otra escena 
        }
        else //como primero va el main menu y ya se crea un instance, este else es para que en la segunda escena no se cree otro gameManager, y que hayan dos, algo que no queremos. Porque sino
             //cuando en mainmenu llamemos a gamemanager, tendremos dos y el programa podria dar errores y confundirse.
        {
            Destroy(gameObject);
        }
           
    }
    private void OnEnable() 
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "GamePlay")
        {
            Instantiate(characters[CharIndex]);
        }
    }
}
