using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //mendapatkan posisi bintang
        Vector2 position = transform.position;

        //hitung posisi bintang yang baru
        position = new Vector2 (position.x, position.y + speed * Time.deltaTime);

        //update posisi bintang
        transform.position = position;

        //batas bawah layar
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //batas atas layar
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
    
        //jika bintang diluar layar bawah maka posisi bintang
        // berada diatas layar dan secara random diantara kiri dan kanan layar
        if (transform.position.y < min.y)
        {
            transform.position = new Vector2 (Random.Range(min.x, max.x), max.y);
        }
    }
}
