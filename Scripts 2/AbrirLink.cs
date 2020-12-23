using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirLink : MonoBehaviour
{


    
    public string link;

    public void Abrir(string link)
    {

        Application.ExternalEval("window.open('" + link + "');");
        Debug.Log(link);
    }
}
