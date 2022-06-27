using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour
{
    public GameObject Stars; //prefab star
    public int MaxStars; //max star

    //array warna
    Color[] starColor = {
        new Color (0.5f, 0.5f, 1f), //biru
        new Color (0, 1f, 1f), //Hijau
        new Color (1f, 1f, 0), //kuning
        new Color (1f, 0, 0), //merah
    };

    // Start is called before the first frame update
    void Start()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2(0,0));
        Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2(1,1));
    
        //loop untuk membuat bintang
        for (int i = 0; i < MaxStars; i++)
        {
            GameObject star = (GameObject)Instantiate(Stars);

            //atur warna bintang
            star.GetComponent<SpriteRenderer>().color = starColor[i % starColor.Length];

            //atur posisi bintang
            star.transform.position = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));

            //atur kecepatan bintang
            star.GetComponent<Stars>().speed = -(1f * Random.value + 0.5f);

            //buat star sebuah child pada StarGenerator
            star.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
