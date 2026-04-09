using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Menu : MonoBehaviour
{
   private UIDocument menu;
   private Button botonJugarX;
   private Button botonJugarMapa;

    void OnEnable()
    {
        menu = GetComponent<UIDocument>();
        var root = menu.rootVisualElement;

        botonJugarX = root.Q<Button>("BotonJugarX");
        botonJugarMapa = root.Q<Button>("BotonJugarMapa");

        //Callbacks
        botonJugarX.RegisterCallback<ClickEvent>(AbrirJugarX);
        botonJugarMapa.RegisterCallback<ClickEvent>(AbrirJugarMapa);
    }


    void OnDisable()
    {
        botonJugarX.UnregisterCallback<ClickEvent>(AbrirJugarX);
        botonJugarMapa.UnregisterCallback<ClickEvent>(AbrirJugarMapa);
    }
    void AbrirJugarX(ClickEvent evt)
    //La esceneas se pueden cargar asincronas o no
    //Las asincronas sirven para cuando se requiere cargar muchos datos
    //.LoadScene(), dentro de los parentesis se le pasa el nombre o el índice
    {
        SceneManager.LoadScene("SampleScene");
    }

    void AbrirJugarMapa(ClickEvent evt)
    {
        SceneManager.LoadScene("EscenaMapa");
    }
}
