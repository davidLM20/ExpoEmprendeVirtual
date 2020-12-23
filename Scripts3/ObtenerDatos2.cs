using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Proyecto26;
using TMPro;
using UnityEngine.UI;
using System;

public class ObtenerDatos2 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] UICargarINfo uiCargarInfo;
    string urlImagen="";
    string urlLogo = "";

    Emprendimiento2 emprendimiento = new Emprendimiento2();

    [Header("Id de la infografia en la base de datos")]
    [SerializeField] string fase;
    [SerializeField] string idInfo;
             
    [SerializeField] TextMeshPro nombreInfo;
    [SerializeField] Renderer lugarLogo;
    [Header("No llenar")]
    public string youtubeUrl;
    public string nameInfo;
    
    void Start()
    {
        RetrieveFromDatabase();        
    }

    

    IEnumerator cargarImagen(string urlLogo)
    {
        

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
        
        urlLogo = emprendimiento.logo;
        StartCoroutine(cargarImagen(urlLogo));
        nombreInfo.text = emprendimiento.name;
        nameInfo = emprendimiento.name;
        youtubeUrl = emprendimiento.video;
        
    }
    public void PostToDatabase()
    {

        int nuevoLike = Int32.Parse(emprendimiento.like);
        nuevoLike++;
        emprendimiento.like = nuevoLike.ToString();
        RestClient.Put("https://expoemprendeutpl.firebaseio.com/distancia/fase-" + fase + "/" + idInfo + ".json", emprendimiento);
        Debug.Log("Ya puse tu hola mundo chancado");
        
    }
    private void RetrieveFromDatabase()
    {
        RestClient.Get<Emprendimiento2>("https://expoemprendeutpl.firebaseio.com/distancia/fase-" + fase +"/" + idInfo + ".json").Then(response =>
        {
            emprendimiento = response;
            AsignarContenido();          
            Debug.Log(urlImagen);
            Debug.Log(urlLogo);

        });
    }

}

