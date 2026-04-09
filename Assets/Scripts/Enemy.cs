using UnityEngine;

public class Enemy : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D Collision)
    {
        if(Collision.CompareTag("Player"))
        {
            SaludPersonaje.instance.vidas--;
            print("Vidas: " + SaludPersonaje.instance.vidas);
            HUD.instance.ActualizarVidas();
            if(SaludPersonaje.instance.vidas == 0)
            {
                Destroy(Collision.gameObject, 0.1f);

                AudioSource efecto = GameObject.Find("EfectoMuere").GetComponent<AudioSource>();
                efecto.Play();
            }
        }
    }
    
}
