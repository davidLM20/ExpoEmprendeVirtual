using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPCBehaviour : MonoBehaviour

{
    
    
    [SerializeField]
    Animator standAnimator;




    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.FindGameObjectWithTag("Player"))
        {
            Vector3 proximidad = transform.position - GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;

            if (proximidad.magnitude < 4)
            {
                standAnimator.SetBool("Proximidad", true);

            }
            else
            {

                standAnimator.SetBool("Proximidad", false);
            }
        }



       
        
    }


}
