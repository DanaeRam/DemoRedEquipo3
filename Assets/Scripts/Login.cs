using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    private TextField usuarioInput;
    private TextField passwordInput;
    private Button botonLogin;
    private Label mensajeLabel;

    [SerializeField] private string urlLogin = "http://localhost:3000/login";
    [SerializeField] private string siguienteEscena = "EscenaMenu";

    public static int SesionId = -1;

    [System.Serializable]
    public class LoginResponse
    {
        public bool ok;
        public int sesionId;
    }

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        usuarioInput = root.Q<TextField>("UsuarioInput");
        passwordInput = root.Q<TextField>("PasswordInput");
        botonLogin = root.Q<Button>("BotonLogin");
        mensajeLabel = root.Q<Label>("MensajeLabel");

        passwordInput.isPasswordField = true;
        botonLogin.clicked += IniciarSesion;
    }

    private void OnDisable()
    {
        botonLogin.clicked -= IniciarSesion;
    }

    private void IniciarSesion()
    {
        string usuario = usuarioInput.value.Trim();
        string password = passwordInput.value.Trim();

        if (usuario == "" || password == "")
        {
            mensajeLabel.text = "Llena todos los campos";
            return;
        }

        StartCoroutine(LoginCoroutine(usuario, password));
    }

    private IEnumerator LoginCoroutine(string usuario, string password)
    {
        string json = "{\"usuario\":\"" + usuario + "\",\"password\":\"" + password + "\"}";
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);

        using (UnityWebRequest request = new UnityWebRequest(urlLogin, "POST"))
        {
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                LoginResponse respuesta = JsonUtility.FromJson<LoginResponse>(request.downloadHandler.text);

                if (respuesta.ok)
                {
                    SesionId = respuesta.sesionId;
                    SceneManager.LoadScene(siguienteEscena);
                }
                else
                {
                    mensajeLabel.text = "Credenciales incorrectas";
                }
            }
            else
            {
                mensajeLabel.text = "Error de conexión";
            }
        }
    }
}