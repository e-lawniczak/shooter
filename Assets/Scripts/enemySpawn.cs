using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System;
using static Player;

public class enemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public static int enemyCount;
    

    private float originalSpawnTimer = 400f;
    private float spawnTimer;
    private int enemyMaxCount = 20;

    public static Renderer rend;

    void Start() {
        rend = GetComponent<Renderer>();
        Thread.Sleep(1000);
        for (int i = 0; i < 5; i++)
        {
            SpawnRandom();
        }
        spawnTimer = 200f;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyCount < enemyMaxCount && spawnTimer <= 0){
            SpawnRandom();
            spawnTimer = originalSpawnTimer;
        }else{
            spawnTimer --;
        }
        
        if(enemyCount < 2){
            for (int i = 0; i < 5; i++)
            {
                SpawnRandom();
            }
    }
        
    }
    public void SpawnRandom()
     {
        enemyCount ++;
        Vector3 dim = rend.bounds.size;

        Vector3 spawnPoint = new Vector3 (UnityEngine.Random.Range(0, dim.x) - dim.x/2, dim.y + 0.5f, UnityEngine.Random.Range(0, dim.z) - dim.z/2);

        if(Math.Abs(spawnPoint.x - Player.playerTransform.position.x) > 15f || Math.Abs(spawnPoint.y - Player.playerTransform.position.y) > 15f){
            spawnPoint = Player.playerTransform.InverseTransformPoint(Player.playerTransform.position);
        }
        Instantiate(enemy,spawnPoint,Quaternion.identity);
     }
}
