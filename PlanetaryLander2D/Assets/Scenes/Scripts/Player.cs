using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public ParticleSystem Fire_Thrust_Bottom;
    public ParticleSystem Fire_Thrust_Left;
    public ParticleSystem Fire_Thrust_Right;
    // Start is called before the first frame update
    private Vector3 v_thrust_earth_gravity; 

    private float gravityValue = 9.807f;

    public bool inWindZone = false;
    private bool isPlanet = false;

    public GameObject windZone;
    private int count = 0;

    void Start(){
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update(){
        
    }

    private void FixedUpdate(){
        rb.useGravity = false;
        rb.AddForce(new Vector3(0,-1.0f,0)*rb.mass*gravityValue);

        if(Input.GetAxis("Vertical")>0.01f){
            v_thrust_earth_gravity = transform.up * 11.0f;
            rb.AddForce(v_thrust_earth_gravity);
            if(!Fire_Thrust_Bottom.isPlaying){
                Fire_Thrust_Bottom.Play();
            }
        }else if(Fire_Thrust_Bottom.isPlaying){
                Fire_Thrust_Bottom.Stop();
            }

        if(Input.GetAxis("Horizontal")>0.01f || Input.GetAxis("Horizontal") < -0.01f ){
            rb.AddForce(transform.right * 5.0f * Input.GetAxis("Horizontal"));
            if(!Fire_Thrust_Right.isPlaying && Input.GetAxis("Horizontal") < -0.01f ){
                Fire_Thrust_Right.Play();
            }else if(!Fire_Thrust_Left.isPlaying && Input.GetAxis("Horizontal") > 0.01f ){
                Fire_Thrust_Left.Play();
            }
        }
        
        if(Fire_Thrust_Left.isPlaying && Input.GetAxis("Horizontal")<0.01f){
                Fire_Thrust_Left.Stop();
            }
        if(Fire_Thrust_Right.isPlaying && Input.GetAxis("Horizontal") > -0.01f){
                Fire_Thrust_Right.Stop();
            }

        if(isPlanet){
            windZone.GetComponent<WindArea>().transform.position = new Vector3(0.0f, 0.0f,42.3f);
        }else{
            windZone.GetComponent<WindArea>().transform.position = new Vector3(0.0f, -36.7f,42.3f);
        }
        
        if(inWindZone){
          if(count == 500){
              windZone.GetComponent<WindArea>().direction = new Vector3(Random.Range(-1.0f,1.0f),0,0); 
              count = 0;
          }
          rb.AddForce(windZone.GetComponent<WindArea>().direction * windZone.GetComponent<WindArea>().strenght);
          count++;
        }
    }

    public void LunarGravity(){
        gravityValue = 1.62f;
        isPlanet = false;
    }

    void OnTriggerEnter(Collider coll){
        if(coll.gameObject.tag == "WindArea" && isPlanet){
            windZone = coll.gameObject;
            inWindZone = true;
        }
    }

    void OnTriggerExit(Collider coll){
        if(coll.gameObject.tag == "WindArea" && isPlanet){
            inWindZone = false;
        }
    }

    public void MarsGravity(){
        gravityValue = 3.721f;
        isPlanet = true;
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
