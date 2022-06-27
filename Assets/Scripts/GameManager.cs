using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playButton;
    public GameObject playerShip;
    public GameObject enemySpawner;
    public GameObject GameOverUI;
    public GameObject scoreTextUI;
    public GameObject shootButton;

    public enum GameManagerState
    {
        Opening,
        Gameplay,
        GameOver,
    }

    GameManagerState GMState;

    // Start is called before the first frame update
    void Start()
    {
        GMState = GameManagerState.Opening;
    }

    // Update is called once per frame
    void UpdateGameManagerState()
    {
        switch (GMState)
        {
            case GameManagerState.Opening:

                //hide gameover
                GameOverUI.SetActive(false);

                //tombol play aktif
                playButton.SetActive(true);

                //hide shoot button
                shootButton.SetActive(false);
                
                break;
            
            case GameManagerState.Gameplay:

                //reset score
                scoreTextUI.GetComponent<GameScore>().Score = 0;
                
                //Tombol Play tidak aktif
                playButton.SetActive(false);

                //open shoot button
                shootButton.SetActive(true);

                //mengatur Player aktif dan init nyawa player
                playerShip.GetComponent<PlayerControl>().Init();

                //mulai enemy spawn
                enemySpawner.GetComponent<EnemySpawner>().StartEnemySpawn();

                break;

            case GameManagerState.GameOver:
                
                //stop enemy spawn
                enemySpawner.GetComponent<EnemySpawner>().StopEnemySpawn();

                //display gameover
                GameOverUI.SetActive(true);

                //hide shoot button
                shootButton.SetActive(false);

                //Ubah ke state game manager opening slama 8 detik
                Invoke("ToOpeningState", 5f);

                break;
        }
    }

    //fungsi untuk mengatur game manager state
    public void SetGameManagerState (GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState ();
    }

    //Tombol play akan memanggil fungsi ini
    //ketika player mengklik tombol
    public void StartGamePlay()
    {
        GMState = GameManagerState.Gameplay;
        UpdateGameManagerState();
    }

    //fungsi ke opening state
    public void ToOpeningState()
    {
        SetGameManagerState (GameManagerState.Opening);
    }
}
