using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    float speed; //kecepatan peluru
    Vector2 _direction; //arah peluru
    bool isSet; //Mengetahui kapan arah peluru diatur

    void Awake()
    {
        speed = 5f;
        isSet = false; //Arah belum di set
    }
    
    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetDirection(Vector2 direction)
    {
        //normalized arah
        _direction = direction.normalized;

        //arah sudah di set 
        isSet = true; 
    }

    // Update is called once per frame
    void Update()
    {
        if (isSet)
        {
            //mendapatkan posisi peluru
            Vector2 position = transform.position;

            //menghitung posisi peluru yang baru
            position += _direction * speed * Time.deltaTime;

            //update posisi peluru
            transform.position = position;

            //batas bawah screen
            Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2(0,0));

            //batas atas screen
            Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2(1,1)); 

            //Peluru keluar layar atas, maka akan dihancurkan
            if((transform.position.x < min.x) || (transform.position.x > max.x) ||
                (transform.position.y < min.y) || (transform.position.y > max.y))
            {
                Destroy(gameObject);
            }
        }
    }
}
