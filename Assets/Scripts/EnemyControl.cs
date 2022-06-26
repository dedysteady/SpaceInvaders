using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{

    float speed; //speed untuk enemy

    // Start is called before the first frame update
    void Start()
    {
        speed = 2f;        
    }

    // Update is called once per frame
    void Update()
    {
        //mendapatkan posisi musuh
        Vector2 position = transform.position;

        //menghitung posisi musuh terbaru
        position = new Vector2 (position.x, position.y - speed * Time.deltaTime);

        //update posisi musuh
        transform.position = position;
        
        //bottom-left screen
        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2(0,0));

        //Musuh keluar layar bawah, maka akan dihancurkan
        if(transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }
}
