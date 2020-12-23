using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CrearInstancias : MonoBehaviour
{


    [SerializeField]
    GameObject stand;
    [SerializeField]
    Transform[] lugar;
    
    int numeroEmpresas =7;
    GameObject standInst;

    int[] numeroEmpresasXPiso = new int[10];


    //Numero por le cual va a iniciar y finalizar, para la obtencion de datos
    int nInicio;
    int nFin;



    string[] nombreEmpresa= new string[] {
        "Banco de loja",
        "Banco de Pichincha",
        "Nestle",
        "Pincheria Josue",
        "Cafeteria Mario",
        "Asados David",
        "UTPL"};

    string[] linkFacebook = new string[] {
        "https://www.facebook.com/BancodeLoja/",
        "https://www.facebook.com/BancoGuayaquil/",
        "https://www.facebook.com/Nestle.Ecuador/?brand_redir=268308303274000",
        "",
        "",
        "",
        "",
        "",
        "",
        ""};

    string[] linkInstagram = new string[] {
        "https://www.instagram.com/bancodeloja/?hl=es-la",
        "https://www.instagram.com/bancoguayaquil/?hl=es-la",
        "https://www.instagram.com/nestleecuador/?hl=es-la",
        "",
        "",
        "",
        "",
        "",
        "",
        ""};

    string[] linkTwitter = new string[] {
        "https://twitter.com/bancodeloja_?lang=es",
        "https://twitter.com/BancoGuayaquil?ref_src=twsrc%5Egoogle%7Ctwcamp%5Eserp%7Ctwgr%5Eauthor",
        "https://www.instagram.com/nestleecuador/?hl=es-la",
        "",
        "",
        "",
        "",
        "",
        "",
        ""};



    
    void Awake()
    {

        ObtenerNumEmpresasXPiso();


        if (SceneManager.GetActiveScene().name.Equals("LobbyGeneral"))
        {
            nInicio = 0;
            nFin = numeroEmpresasXPiso[0];

        }
        else if(SceneManager.GetActiveScene().name.Equals("Piso1"))
        {
            nInicio = 6;
            nFin = numeroEmpresasXPiso[1];
        }
        AnadirDatos(nInicio, nFin);


    }

    void ObtenerNumEmpresasXPiso()
    {
        int aux = 0;
        int cont = 5;
        int j = 0;

        for (int i = 0; i < numeroEmpresas; i++)
        {
            aux++;
            numeroEmpresasXPiso[j] = aux;          
            if (aux > cont)
            {
                cont += 6;
                j++;
            }
        }
    }


    void AnadirDatos(int inicio, int fin)
    {

        Debug.Log(inicio);
        Debug.Log(fin);
        int pos = 0;
        for (int i = inicio; i < fin; i++)
        {
            standInst = Instantiate(stand, lugar[pos].position, lugar[pos].rotation);
            pos++;
            standInst.name = nombreEmpresa[i];
            standInst.GetComponentInChildren<TextMeshPro>().text = nombreEmpresa[i];
            standInst.GetComponentInChildren<PanelController>().facebook = linkFacebook[i];
            standInst.GetComponentInChildren<PanelController>().instagram = linkInstagram[i];
            standInst.GetComponentInChildren<PanelController>().twitter = linkTwitter[i];

        }

    }
   

}
