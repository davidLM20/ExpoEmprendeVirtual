using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioCamara : MonoBehaviour
{
    [SerializeField] GameObject PlayerCamera;
    [SerializeField]  GameObject MainCamera;
   

    // Start is called before the first frame update
    void Start()
    {
       
    }
    
    public void ActivarVideo()
    {
        PlayerCamera.SetActive(false);
        MainCamera.SetActive(true);

    }
    public void DesctivarVideo()
    {
        PlayerCamera.SetActive(true);
        MainCamera.SetActive(false);
        

    }

    
    
}
