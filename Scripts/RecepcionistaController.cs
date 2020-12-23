using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecepcionistaController : MonoBehaviour,IAction
{


    [SerializeField] Menu menuManager;


    public void Activate()
    {
        
        menuManager.MostarOcultarMenu("Menu Lobby General");
    }
}
