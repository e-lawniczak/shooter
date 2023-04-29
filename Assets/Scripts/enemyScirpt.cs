using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static enemySpawn;
using static Player;
using static scoreScript;


public class enemyScirpt : MonoBehaviour
{

    public Rigidbody rb;
    private float movementSpeed = 35f; 

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    private Renderer map;
    private Vector3 dim;
    private Quaternion rotation;
    private Vector3 target;

    private float rotationSpeed = 45f;
    // Start is called before the first frame update
    void Start()
    {
        map = enemySpawn.rend;
        dim = map.bounds.size;
        target = new Vector3(0f, transform.position.y, 0f);
        rotation = Quaternion.LookRotation(Vector3.zero - transform.position);
        rotation.x = 0;
        rotation.z = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed);

    }

    private void OnTriggerEnter(Collider other){
        if(other.tag == "bullet"){
            Destroy(this.gameObject);
            enemySpawn.enemyCount --;
            scoreScript.scoreNumber ++;
            scoreScript.score.text = scoreScript.scoreNumber.ToString();
        }
        if(other.tag =="enemy"){
            Vector3 randomTarget = new Vector3 (Random.Range(0f, 10f), transform.position.y, Random.Range(0f, 10f));
            rotation = Quaternion.LookRotation(randomTarget - transform.position);
            rotation.x = 0;
            rotation.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed);
        }else{
            Vector3 randomTarget = new Vector3 (Random.Range(0f, 10f), transform.position.y, Random.Range(0f, 10f));
            rotation = Quaternion.LookRotation(Player.playerTransform.position - transform.position);
            rotation.x = 0;
            rotation.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed);
        }

      
    }

   
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * movementSpeed;
    }
}
