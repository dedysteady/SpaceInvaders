using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject EnemyBullet; //prefab EnemyBullet

    // Start is called before the first frame update
    void Start()
    {
        Invoke ("TembakanMusuh", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TembakanMusuh()
    {
        //mendapatkan reference ke pesawat player
        GameObject playerShip = GameObject.Find ("Player");

        if (playerShip != null) //jika player tidak mati
        {
            //instantiate peluru musuh
            GameObject bullet = (GameObject)Instantiate(EnemyBullet);

            //mengatur inisial posisi peluru
            bullet.transform.position = transform.position;

            //menghitung arah peluru menuju pesawat player
            Vector2 direction = playerShip.transform.position - bullet.transform.position;

            //mengatur arah peluru
            bullet.GetComponent<EnemyBullet>().SetDirection(direction);
        }
    }
}
