using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class urlManager : MonoBehaviour
{
    
    public  Dictionary<string, string> url = new Dictionary<string, string>() ;

    public void IrA(string nombreRedSocial)
    {
        Application.OpenURL(url[nombreRedSocial]);
        Application.ExternalEval("window.open('"+ url[nombreRedSocial]+ "');");

    }
    
}