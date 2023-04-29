using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    //Variables

    public Rigidbody body;

    public float movementSpeed = 20f; 
    public float rotationSpeed = 10f; 

    public static int health = 5; 

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    public GameObject bulletSpawnPoint;
    public GameObject bullet;
    public int originalWaitTime = 35;
    private int waitTime = 50;
    private bool mouseDown ;

    public static Transform playerTransform;

    private void Start() {
         playerTransform = transform;
    }

    void Update() {

        rotatePlayer();
        movePlayer();

        //detecting fire
        if(Input.GetMouseButtonDown(0))
        {
            mouseDown =true;
        }else if(Input.GetMouseButtonUp(0)){
            mouseDown = false;
        }
        if(mouseDown){
            shoot();
        }

    }


    private void OnTriggerEnter(Collider other){
         if(other.tag == "enemy"){
            health--;
            if(health==0){
                Destroy(this.gameObject);
            }
        }
        
    }
    

    private void rotatePlayer(){
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float hitDist = 0.0f;
        Vector3 target = new Vector3();

        if(playerPlane.Raycast(ray, out hitDist))
        {
            target = ray.GetPoint(hitDist);
            Quaternion rotation = Quaternion.LookRotation(target - transform.position);
            rotation.x = 0;
            rotation.z = 0;

            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
            bulletSpawnPoint.transform.rotation = Quaternion.Slerp(bulletSpawnPoint.transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }

        Debug.DrawRay(transform.position, target, Color.red);
    }

    private void movePlayer(){
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0,Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * movementSpeed;
        body.velocity = moveVelocity;
    }

    private void shoot(){

        if(waitTime > 0){
            waitTime -= 1;
        }else{
            Instantiate(bullet.transform, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
            waitTime = originalWaitTime;
        }
    
    }
  
 }
