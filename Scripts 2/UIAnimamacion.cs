using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIAnimamacion : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void OnEnable()
    {
        transform.localScale = new Vector3(0, 0, 0);
        LeanTween.scale(gameObject, new Vector3(1, 1, 1), 0.3f).setDelay(0.5f);
    }

    public void cerrar()
    {
        transform.localScale = new Vector3(0, 0, 0);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
