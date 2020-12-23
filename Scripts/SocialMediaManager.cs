using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SocialMediaManager : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject button;
    [Header("Color Settings")]
    [Space(10)]

    public bool facebook;



    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {

       

        if (facebook)
        {
            button.SetActive(true) ;
        }
        else {
            button.SetActive(false) ;
        
        }


    }
}
