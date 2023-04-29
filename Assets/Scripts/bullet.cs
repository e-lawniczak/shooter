using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public float maxDistance;

    // Update is called once per frame
    void Update()
    {
        shoot();
    }
    private void OnTriggerEnter(Collider other){
        Debug.Log( "trigger");
        Debug.Log( other.name );
        Destroy(this.gameObject);
    }

    

    private void shoot(){
        transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
        maxDistance += 1 * Time.deltaTime;

    }
    



}
