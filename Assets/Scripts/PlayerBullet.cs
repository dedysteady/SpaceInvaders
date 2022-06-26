using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 8f;        
    }

    // Update is called once per frame
    void Update()
    {
        //mendapatkan posisi peluru 
        Vector2 position = transform.position; 

        //menghitung posisi peluru terbaru
        position = new Vector2 (position.x, position.y + speed * Time.deltaTime);

        //update posisi peluru
        transform.position = position;
        
        //top-right screen
        Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2(1,1)); 

        //Peluru keluar layar atas, maka akan dihancurkan
        if(transform.position.y > max.y)
        {
            Destroy(gameObject);
        }
    }
}
