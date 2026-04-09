using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Logout : MonoBehaviour
{
    private Button botonCerrarSesion;

    [SerializeField] private string urlLogout = "http://localhost:3000/logout";
    [SerializeField] private string escenaLogin = "LoginScene";

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        botonCerrarSesion = root.Q<Button>("BotonCerrarSesion");
        botonCerrarSesion.clicked += CerrarSesion;
    }

    private void OnDisable()
    {
        botonCerrarSesion.clicked -= CerrarSesion;
    }

    public void CerrarSesion()
    {
        StartCoroutine(LogoutCoroutine());
    }

    private IEnumerator LogoutCoroutine()
    {
        string json = "{\"sesionId\":" + Login.SesionId + "}";
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);

        using (UnityWebRequest request = new UnityWebRequest(urlLogout, "POST"))
        {
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();
        }

        Login.SesionId = -1;
        SceneManager.LoadScene(escenaLogin);
    }
}