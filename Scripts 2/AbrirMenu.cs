using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirMenu : MonoBehaviour, IAction
{
    [SerializeField] GameObject uiInforafia;
    [SerializeField] CursorController cc;
    public void Activate()
    {
        uiInforafia.SetActive(true);
        cc.ShowCursor();
    }

    public void Desactivar()
    {
        uiInforafia.SetActive(false);
        cc.HideCursor();
    }

    
}
