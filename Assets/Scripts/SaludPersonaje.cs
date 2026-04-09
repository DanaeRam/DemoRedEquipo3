using UnityEngine;

public class SaludPersonaje : MonoBehaviour
{
  public int vidas = 3;
  public static SaludPersonaje instance;

  public int monedas = 0;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
}
