using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject PlayerBulletGO; //Prefab PlayerBulletGO
    public GameObject posisiPeluru1;
    public GameObject posisiPeluru2;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //menembak ketika menekan spacebar
        if(Input.GetKeyDown("space"))
        {
            //Instantiate peluru pertama
            GameObject peluru1 = (GameObject)Instantiate (PlayerBulletGO);
            peluru1.transform.position = posisiPeluru1.transform.position; //Mengatur inisial posisi peluru

            //Instantiate peluru kedua
            GameObject peluru2 = (GameObject)Instantiate (PlayerBulletGO);
            peluru2.transform.position = posisiPeluru2.transform.position; //Mengatur inisial posisi peluru
        }


        float x = Input.GetAxisRaw ("Horizontal"); //nilai akan menjadi -1, 0 atau 1 (Kiri, Kosong, Kanan)
        float y = Input.GetAxisRaw ("Vertical"); //nilai akan menjadi -1, 0 atau 1 (Bawah, Kosong, Atas)

        Vector2 direction = new Vector2 (x, y).normalized;

        //Panggil fungsi dan atur posisi pemain
        Move (direction);
    }

    void Move(Vector2 direction)
    {
        //Mencari batasan layar terhadap pergerakan player (kiri, kanan, atas dan bawah)
        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2(0,0)); //bottom-left (corner) screen
        Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2(1,1)); //top-right (corner) screen

        max.x = max.x - 0.225f; //Mengurangi lebar sprite player setengah
        max.x = max.x + 0.225f; //Menambah lebar sprite player setengah

        max.y = max.y - 0.225f; //Mengurangi tinggi sprite player setengah
        max.x = max.x + 0.225f; //Menambah tinggi sprite player setengah

        Vector2 pos = transform.position; //Mendapatkan posisi terbaru player
        pos += direction * speed * Time.deltaTime; //Menghitung posisi baru

        //Memastikan posisi baru tidak diluar layar
        pos.x = Mathf.Clamp (pos.x, min.x, max.x);
        pos.y = Mathf.Clamp (pos.y, min.y, max.y);

        //update posisi player
        transform.position = pos;
    }
}
