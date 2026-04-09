using UnityEngine;
using UnityEngine.UIElements;

public class Login : MonoBehaviour
{
    private TextField usuarioInput;
    private TextField passwordInput;
    private Button botonLogin;
    private Label mensajeLabel;

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        usuarioInput = root.Q<TextField>("UsuarioInput");
        passwordInput = root.Q<TextField>("PasswordInput");
        botonLogin = root.Q<Button>("BotonLogin");
        mensajeLabel = root.Q<Label>("MensajeLabel");

        passwordInput.isPasswordField = true;

        botonLogin.clicked += OnLoginClick;
    }

    private void OnLoginClick()
    {
        string usuario = usuarioInput.value;
        string password = passwordInput.value;

        if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(password))
        {
            mensajeLabel.text = "Llena todos los campos por favor";
        }
        else
        {
            mensajeLabel.text = "Datos recibidos correctamente";
        }
    }
}