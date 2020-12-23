using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorIURS : MonoBehaviour
{
    [SerializeField]GameObject canvasRedesSociales;
    [SerializeField]CursorController cursorController;
    void Start()
    {
        canvasRedesSociales.SetActive(false);
    }

    public void Desactivar()
    {
        canvasRedesSociales.SetActive(false);
        cursorController.HideCursor();
    }



}
