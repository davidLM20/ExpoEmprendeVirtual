using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public class ObtenerImagen : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] string urlImagen;
    [SerializeField] Renderer lugarImagen;
    void Start()
    {
        StartCoroutine(cargarImagen(urlImagen));
    }

    IEnumerator cargarImagen(string urlImagen)
    {
        UnityWebRequest imgRequest = UnityWebRequestTexture.GetTexture(urlImagen);
        yield return imgRequest.SendWebRequest();
        if (imgRequest.isNetworkError || imgRequest.isHttpError)
        {
            Debug.LogError(imgRequest.error);
            yield break;
        }
        lugarImagen.material.mainTexture = DownloadHandlerTexture.GetContent(imgRequest);
        Debug.Log("Carga3");
    }

}
