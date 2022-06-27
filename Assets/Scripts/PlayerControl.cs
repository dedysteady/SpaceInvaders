using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject PlayerBullet; //Prefab PlayerBulletGO
    public GameObject posisiPeluru1;
    public GameObject posisiPeluru2;
    public GameObject Explosion; //Prefan explosion
    public GameObject audioSource;

    public Text NyawaText;

    const int MaxNyawa = 3;
    int Nyawa;

    public float speed;

    float accelStartY; //untuk dapat nilai akselerasi Y

    public void Init()
    {
        Nyawa = MaxNyawa;

        //Update Nyawa Text
        NyawaText.text = Nyawa.ToString(); 

        //reset posisi Player ke tengah layar
        transform.position = new Vector2 (0,0);

        //mengaktifkan nyawa
        gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start ()
    {
        //mendapatkan inisial akselerasi y
        accelStartY = Input.acceleration.y;
    }

    // Update is called once per frame
    void Update()
    {
        //akselerasi
        float x = Input.acceleration.x;
        float y = Input.acceleration.y - accelStartY;

        //vector dengan akselerasi
        Vector2 direction = new Vector2 (x, y);

        if (direction.sqrMagnitude > 1)
        {
            direction.Normalize();
        }

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

    //fungsi untuk player menembak
    public void Shoot()
    {
        audioSource.GetComponent<SoundManager>().TembakanPlayer();
       
        //Instantiate peluru pertama
        GameObject peluru1 = (GameObject)Instantiate (PlayerBullet);
        peluru1.transform.position = posisiPeluru1.transform.position; //Mengatur inisial posisi peluru

        //Instantiate peluru kedua
        GameObject peluru2 = (GameObject)Instantiate (PlayerBullet);
        peluru2.transform.position = posisiPeluru2.transform.position; //Mengatur inisial posisi peluru
    }


    void OnTriggerEnter2D (Collider2D col)
    {
        //deteksi collider pada player
        if ((col.tag == "EnemyShipTag") || (col.tag == "EnemyBulletTag"))
        {
            PlayerExplosion();
            Nyawa--; //nyawa berkurang
            NyawaText.text = Nyawa.ToString(); //update nyawa UI

            if (Nyawa == 0)
            {
                //ubah state game manager ke game over
                gameManager.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.GameOver);
                
                gameObject.SetActive(false);
            }
        }
    }

    //Fungsi untuk instantiate explosion
    void PlayerExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(Explosion);
        
        //set posisi explosion
        explosion.transform.position = transform.position;
    }
}
