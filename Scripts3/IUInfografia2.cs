using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;
using UnityEngine.Video;

public class IUInfografia2 : MonoBehaviour, IAction
{
 
    [SerializeField] GameObject uiInforafia;
    [SerializeField] CursorController cc;
    [SerializeField] ObtenerDatos2 obtenerDatos;
    
    [SerializeField] VideoPlayer videoController;
    [SerializeField] Text nombreEnVideo;
    [SerializeField] Button b;

    
    void Start()
    {            
        uiInforafia.transform.localScale = new Vector3(0, 0, 0);
        
    }

 
    public void Activate()
    {      
        LeanTween.scale(uiInforafia, new Vector3(1, 1, 1), 0.3f);
        videoController.url = obtenerDatos.youtubeUrl;
        nombreEnVideo.text = obtenerDatos.nameInfo;
        b.onClick.AddListener(delegate () { obtenerDatos.PostToDatabase(); });
        cc.ShowCursor();
    }

    public void Desctivar()
    {
        LeanTween.scale(uiInforafia, new Vector3(0, 0, 0), 0.3f);
        b.onClick.RemoveAllListeners();
        cc.HideCursor();
    }

    

   


}
