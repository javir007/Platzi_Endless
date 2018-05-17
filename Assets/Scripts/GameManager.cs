using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance { set; get; }

    private PlayerMotor motor;

    private bool isGameStarted = false;



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
		
	}

    public void StartGame(){
        isGameStarted = true;
        motor.StartRun();
    }
}
