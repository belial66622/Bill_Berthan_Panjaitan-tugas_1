using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onklik : MonoBehaviour
{
    [SerializeField]
    private LayerMask ss;
    [SerializeField]
    private Camera main;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           // Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray ray = main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo,float.MaxValue,ss))
            {
                Debug.Log("masuh");
                Ionklik klik = hitInfo.collider.GetComponent<Ionklik>();
                if (klik != null)
                klik.onklika(1); 
               
            }

            //Debug.Log(ray);
        }
    }

}
