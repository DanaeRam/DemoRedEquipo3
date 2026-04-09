using UnityEngine;
using UnityEngine.InputSystem;

public class MoverConInputAction : MonoBehaviour
{
    [SerializeField]
    private InputAction accionMover; // En las 4 direcciones

    [SerializeField]
    private InputAction accionSaltar; // Salto con espacio

    private float velocidadX = 7f;

    private float velocidadY = 7f;

    private Rigidbody2D rb; //Para saltar y caminar (horizontal)



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        // Habilitar el InputAction
        accionMover.Enable();
        rb = GetComponent<Rigidbody2D>();
    }

    void OnEnable(){
        accionSaltar.Enable();
        accionSaltar.performed += saltar;
    }

    void OnDisable(){
        accionSaltar.Disable();
        accionSaltar.performed -= saltar;
    }

    public void saltar(InputAction.CallbackContext context){
        //Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.linearVelocityY = velocidadY * 1;
    }

    // Update is called once per frame
    void Update(){
        // Leer Entrada
        Vector2 movimiento = accionMover.ReadValue<Vector2>();
        //transform.position = (Vector2)transform.position + Time.deltaTime * velocidadX * movimiento;
        rb.linearVelocityX = velocidadX * movimiento.x;
    }
}