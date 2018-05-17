using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager Instance { set; get; }

    private PlayerMotor motor;

    private bool isGameStarted = false;

    //puntuacion

    private float score;
    private float coins;
    private float finalScore;



   public bool IsGameStarted{
        get{
            return isGameStarted;
        }
    }
	private void Awake()
	{
        Instance = this;

        motor = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMotor>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(isGameStarted){
            score += (Time.deltaTime * 2);
            print("la puuntuacion actual es: " + score.ToString("0"));
        }
	}

    public void StartGame(){
        isGameStarted = true;
        motor.StartRun();
    }

    public void GetCollectable(int collectableAmnt){
        coins++;
        score += collectableAmnt;
    }

    public void GameOver(){
        finalScore = score + coins;
    }

    public void PlayAgain(){
        //iniciar el nivel nuevamente
        Invoke("LoadScene", 1f);
    }

    void LoadScene(){
        SceneManager.LoadScene(0);
    }
}
