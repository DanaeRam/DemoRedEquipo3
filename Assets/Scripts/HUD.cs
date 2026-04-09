using System;
using UnityEngine;
using UnityEngine.UIElements;


public class HUD : MonoBehaviour
{
    public static HUD instance;

    private VisualElement vida_1;
    private VisualElement vida_2;
    private VisualElement vida_3;
    private Label numMonedas;

    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        vida_1 = root.Q<VisualElement>("Vida_1");
        vida_2 = root.Q<VisualElement>("Vida_2");
        vida_3 = root.Q<VisualElement>("Vida_3");

        numMonedas = root.Q<Label>("NumeroMonedas");
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void ActualizarVidas()
    {
        int vidas = SaludPersonaje.instance.vidas;

        if (vidas == 0)
        {
            vida_1.style.display = DisplayStyle.None;
        }
        else if (vidas == 1)
        {
            vida_2.style.display = DisplayStyle.None;
        }
        else if (vidas == 2)
        {
            vida_3.style.display = DisplayStyle.None;
        }
    }

    internal void ActualizarMonedas()
    {
        int monedas = SaludPersonaje.instance.monedas;
        numMonedas.text = SaludPersonaje.instance.monedas.ToString();
    }
}
