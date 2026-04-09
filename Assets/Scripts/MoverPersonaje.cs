using UnityEngine;  //Importa una libreria

public class MoverPersonaje : MonoBehaviour
{
    // Datos
    public float velocidadX = 5f;  //Visible en el editor

    [SerializeField]
    private float velocidadY = 5f;

    private Rigidbody2D rb;

    // Metodos

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        
        velocidadX = 8f;
        velocidadY = 5f;

        rb = GetComponent<Rigidbody2D>();
        print("Iniciando personaje");
    }

    // Update is called once per frame
    void Update(){
        
        float movHorizontal = Input.GetAxis("Horizontal");
        float movVertical = Input.GetAxis("Vertical");

        if (movVertical > 0){ // Saltar?
            rb.linearVelocityY = movVertical * velocidadY;
        } else {
            rb.linearVelocityX = movHorizontal * velocidadX;
        }

        //rb.linearVelocity = new Vector2(movHorizontal * velocidadX, movVertical * velocidadY);
        
        if (movHorizontal != 0){
            print(movHorizontal);
        } 
    }
}
