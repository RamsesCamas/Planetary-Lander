using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    private Vector3 v_thrust_earth_gravity; 

    private float gravityValue = 9.807f;

    void Start(){
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update(){
        
    }

    private void FixedUpdate(){
        rb.useGravity = false;
        rb.AddForce(new Vector3(0,-1.0f,0)*rb.mass*gravityValue);
        //rb.AddForce(transform.up * 10.0f); Equivale a la gravedad de la tierra
        if(Input.GetAxis("Vertical")>00.1f){
            v_thrust_earth_gravity = transform.up * 11.0f;
            rb.AddForce(v_thrust_earth_gravity);
        }
        if(Input.GetAxis("Horizontal")>00.1f || Input.GetAxis("Horizontal") < 00.1f ){
            rb.AddForce(transform.right * 5.0f * Input.GetAxis("Horizontal"));
        }
    }

    public void LunarGravity(){
        gravityValue = 1.62f;
    }

    public void MarsGravity(){
        gravityValue = 3.721f;
    }

    public void VenusGravity(){
        gravityValue = 8.87f;
    }

    public void EuropaGravity(){
        gravityValue = 1.315f;
    }
    public void SunGravity(){
        gravityValue = 274f;
    }

}
