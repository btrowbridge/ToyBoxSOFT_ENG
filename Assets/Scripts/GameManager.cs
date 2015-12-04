using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Diagnostics;

public class GameManager : MonoBehaviour {

	private int winScore = 6; 	//used for win condition
	private Stopwatch timer; 	//used for player record time system

    public Text scoreText;		//Displays score text
    public Text healthText;		//Displays health text
	public Text timeText;

	public int playerScore = 0;	//players score for win condition
	public int playerHealth = 10; //player's health for lose condition



	//resets the game data
    public void initializeGame() { 
		playerScore = 0;
		playerHealth = 10;
		healthText.text = playerHealth.ToString();
		scoreText.text = playerScore.ToString();
		timeText.text = 0.ToString();
	}


	// Use this for initialization
	void Start () {

	}

	//reset game and start the timer
	void GameStart(){
		initializeGame ();			//reset game data
		timer = new Stopwatch ();   //create new stopwatch
        timer.Start();				//start the timer
	}
	
	// Update is called once per frame
	void Update () {
		timeText.text = timer.Elapsed.ToString(); //updates the timer text

		//Check win and lose conditions
		if (playerScore == winScore) {
			GameWin ();
		} else if (playerHealth == 0) {
			GameLose ();
		}
	}

	//called when player takes damage
	public void playerTakesDamage (int value){
		playerHealth -= value;
		healthText.text = playerHealth.ToString(); //update text
	}

	//called when Player scores points
	public void playerAddsToScore (int value){
		playerScore += value;
		scoreText.text = playerScore.ToString(); //update text

	}

	//called when player reaches game win condition
	public void GameWin (){

		timer.Stop(); //stop the timer

		float timeScore = timer.ElapsedMilliseconds; //convert score to milliseconds

		addToScoreBoard (timeScore);	//add time to scoreboard

		//call the gui
		UnityEngine.Debug.Log ("Trigger win screen", this);
	}

	//adds players time to the scoreboard
	void addToScoreBoard(float timeScore){
		//
		//scoreboard holds ten values and sorts them

		//Note: PlayerPrefs is a system static hash
		//For this purpose we label the scores Score0, Score1, Score3 ... Score0 being the fastest time

		//loop through scores
		for (int i = 0; i < 10; i++) {

			//if the key exists
			if(PlayerPrefs.HasKey("Score"+i)){
				//compare score to the value
				if(timeScore <= PlayerPrefs.GetFloat("Score"+i)){

					//if new score is less than or equal to existing score,
					for(int j = 10; j > i; j--){
						//from last to current position, set each score to the score that falls before it
						if(PlayerPrefs.HasKey("Score"+(j-1)))//avoids null
							PlayerPrefs.SetFloat("Score"+j,PlayerPrefs.GetFloat("Score"+(j-1)));
					}

					//then set the new score to this position
					PlayerPrefs.SetFloat("Score"+i, timeScore);
					break;
				}
			}
			else{
				//if the key is empty this is the last score on the list
				//set this score in this position
				PlayerPrefs.SetFloat("Score" + i,timeScore);
				break;
			}
			
		}
		
		//save these scores
		PlayerPrefs.Save ();
	}

	//called on game lost
	public void GameLose (){
		//stop the timer
		timer.Stop ();
		//call the gui
		UnityEngine.Debug.Log("Trigger lose screen", this);
	}
}
