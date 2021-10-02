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
        if(Input.GetAxis("Vertical")>00.1f){
            rb.AddForce(transform.up * 30.0f);
        }
        if(Input.GetAxis("Horizontal")>00.1f){
            rb.AddForce(transform.right * 10.0f);
        }
    }
}
