using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;

    float maxWaktuSpawn = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnEnemy", maxWaktuSpawn);

        //Meningkatkan spawn rate setiap 30 detik
        InvokeRepeating ("IncreaseSpawnRate", 0f, 30f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //fungsi spawn musuh
    void SpawnEnemy()
    {
        //batas bawah layar
        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2(0,0));

        //batas atas layar
        Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2(1,1));

        //instantiate musuh
        GameObject _Enemy = (GameObject)Instantiate (Enemy);
        _Enemy.transform.position = new Vector2 (Random.Range (min.x, max.x), max.y);

        //Menentukan kapan musuh nge-spawn
        NextSpawnEnemy ();
    }

    void NextSpawnEnemy()
    {
        float waktuSpawn;

        if(maxWaktuSpawn > 1f)
        {
            //memilih nomor antara 1 sampai maxWaktuSpawn
            waktuSpawn = Random.Range(1f, maxWaktuSpawn);
        }
        else
        {
            waktuSpawn = 1f;
        }

        Invoke ("SpawnEnemy", waktuSpawn);
    }

    void IncreaseSpawnRate()
    {
        if (maxWaktuSpawn > 1f)
        {
            maxWaktuSpawn--;
        }

        if (maxWaktuSpawn == 1f)
        {
            CancelInvoke ("IncreaseSpawnRate");
        }
    }
}
