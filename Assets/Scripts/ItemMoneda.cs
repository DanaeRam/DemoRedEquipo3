using Unity.VisualScripting;
using UnityEngine;

public class ItemMoneda : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            AudioSource efecto = GetComponent<AudioSource>();
            efecto.Play();
            SaludPersonaje.instance.monedas++;
            HUD.instance.ActualizarMonedas();
            //Para acceder a los hijos se hace mediante transform
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject, 0.5f);

        }
    }
}
