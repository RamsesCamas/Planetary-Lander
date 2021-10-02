using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    private void FixedUpdate(){
        //rb.AddForce(transform.up * 10.0f); Equivale a la gravedad de la tierra
        if(Input.GetAxis("Vertical")>00.1f){
            Vector3 v_thrust_earth_gravity = transform.up * 10.0f;
            rb.AddForce(v_thrust_earth_gravity);
        }
        if(Input.GetAxis("Horizontal")>00.1f){
            rb.AddForce(transform.right * 5.0f);
        }
    }
}
