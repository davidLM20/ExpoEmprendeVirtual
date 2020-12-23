using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelAsensor : MonoBehaviour, IAction
{
    [SerializeField]
    GameObject canvasAsensor;
    CursorController cursorController;
    void Start()
    {
        cursorController = FindObjectOfType<CursorController>();
        canvasAsensor.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Activate()
    {
        canvasAsensor.SetActive(true);
        cursorController.ShowCursor();
    }
    public void Desactivar()
    {
        canvasAsensor.SetActive(false);
        cursorController.HideCursor();
    }
}
