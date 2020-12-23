using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Proyecto26;
using TMPro;
using UnityEngine.UI;
using System;

public class ObtenerDatos : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] UICargarINfo uiCargarInfo;
    string urlImagen="";
    string urlLogo = "";
    Emprendimiento emprendimiento = new Emprendimiento();
    [Header("Id de la infografia en la base de datos")]
    [SerializeField] string fase;
    [SerializeField] string idInfo;
    [SerializeField] Renderer lugarImagen;          
    [SerializeField] TextMeshPro nombreInfo;
    [SerializeField] Renderer lugarLogo;
    [Header("No llenar")]
    public string youtubeUrl;
    public string nameInfo;
    
    void Start()
    {
        RetrieveFromDatabase();
        
    }

    

    IEnumerator cargarImagen(string urlImagen, string urlLogo)
    {
        UnityWebRequest imgRequest = UnityWebRequestTexture.GetTexture(urlImagen);
        yield return imgRequest.SendWebRequest();
        if (imgRequest.isNetworkError || imgRequest.isHttpError)
        {
            Debug.LogError(imgRequest.error);
            yield break;
        }
        lugarImagen.material.mainTexture = DownloadHandlerTexture.GetContent(imgRequest);

        UnityWebRequest logoRequest = UnityWebRequestTexture.GetTexture(urlLogo);
        yield return logoRequest.SendWebRequest();
        if (logoRequest.isNetworkError || logoRequest.isHttpError)
        {
            Debug.LogError(logoRequest.error);
            yield break;
        }      
        lugarLogo.material.mainTexture = DownloadHandlerTexture.GetContent(logoRequest);
        uiCargarInfo.infosCargadas++;
        Debug.Log("Carga3");
    }

    void AsignarContenido()
    {      
        urlImagen = emprendimiento.infographic;
        urlLogo = emprendimiento.logo;
        StartCoroutine(cargarImagen(urlImagen,urlLogo));
        nombreInfo.text = emprendimiento.name;
        nameInfo = emprendimiento.name;
        youtubeUrl = emprendimiento.video;
        
    }
    public void PostToDatabase()
    {
        int nuevoLike = Int32.Parse(emprendimiento.like);
        nuevoLike++;
        emprendimiento.like = nuevoLike.ToString();
        RestClient.Put("https://expoemprendeutpl.firebaseio.com/presencial/fase-" + fase + "/" + idInfo + ".json", emprendimiento);
        Debug.Log("Ya puse tu hola mundo chancado");

    

    }

    private void RetrieveFromDatabase()
    {
        RestClient.Get<Emprendimiento>("https://expoemprendeutpl.firebaseio.com/presencial/fase-" + fase +"/" + idInfo + ".json").Then(response =>
        {
            emprendimiento = response;
            AsignarContenido();          
            Debug.Log(urlImagen);
            Debug.Log(urlLogo);

        });
    }

}

