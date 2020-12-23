using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour, IAction
{   
    GameObject canvasRedesSociales;
    CursorController cursorController;
    urlManager urlManager;

    [Header("Links Redes sociales")]
    public string facebook;
    public string instagram;
    public string twitter;
    void Awake()
    {

        urlManager = FindObjectOfType<urlManager>();
        cursorController = FindObjectOfType<CursorController>();
        canvasRedesSociales = GameObject.Find("UIRedesSociales");
    }
    

    public void Activate()
    {

        urlManager.url.Clear();
        urlManager.url.Add("Facebook", facebook);
        urlManager.url.Add("Instagram", instagram);
        urlManager.url.Add("Twitter", twitter);
        canvasRedesSociales.SetActive(true);
        cursorController.ShowCursor();
    }
    

}