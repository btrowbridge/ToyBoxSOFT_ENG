using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Diagnostics;

public class GameManager : MonoBehaviour {

	public int winScore = 1; 	//used for win condition
	[SerializeField]private float timer = 0.0f; 	//used for player record time system
    [SerializeField]private bool counting = true;

    public Text scoreText;		//Displays score text
    public Text healthText;		//Displays health text
	public Text timeText;

    public GameObject gameOverScreen;
    public Text gameOverText;

	public int playerScore = 0;	//players score for win condition

    public int playerHealth = 10; //player's health for lose condition



	// Use this for initialization
	void Awake () {
        healthText.text = "Health: " + playerHealth.ToString();
        scoreText.text = "Score: " + playerScore.ToString();
        timeText.text = "Time: " + timer;
        counting = true;
        StartCoroutine(startCounting());
    }
    //timer
    IEnumerator startCounting() {
       UnityEngine.Debug.Log("Counting");
        while (counting)
        {
            UnityEngine.Debug.Log("Counted");
            yield return new WaitForSeconds (1);
            timer++;
            timeText.text = "Time: " + timer; //updates the timer text
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        timeText.text = "Time: " + timer;

    }

    //called when player takes damage
    public void playerTakesDamage(int value) {
        playerHealth -= value;
        healthText.text = "Health: " + playerHealth.ToString();  //update text
        if (playerHealth <= 0)
        {
            UnityEngine.Debug.Log("Lose");
            counting = false;
            GameLose();
        }
    }

	//called when Player scores points
	public void playerAddsToScore (int value){
		playerScore += value;
		scoreText.text = "Score: " + playerScore.ToString(); //update text
        if (playerScore == winScore)
        {
            UnityEngine.Debug.Log("Win");
            counting = false;
            GameWin();
        }

    }



	//adds players time to the scoreboard
	 public static void  addToScoreBoard(float timeScore){
        //
        //scoreboard holds ten values and sorts them

        //Note: PlayerPrefs is a system static hash
        //For this purpose we label the scores Score0, Score1, Score3 ... Score0 being the fastest time

        //loop through scores
        UnityEngine.Debug.Log("Adding score to scoreboard");
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

    //called when player reaches game win condition
    public void GameWin()
    {

        counting = false;

        float timeScore = (float)timer; //convert score to milliseconds
        
        addToScoreBoard(timeScore); //add time to scoreboard

        gameOverText.text = "You Win! \n Play again?";
        gameOverScreen.SetActive(true);
        //call the gui
        UnityEngine.Debug.Log("Trigger win screen", this);
    }

    //called on game lost
    public void GameLose (){
        //stop the timer
        counting = false;
        //call the gui
        gameOverText.text = "You Lose! \n Play again?";
        gameOverScreen.SetActive(true);

        UnityEngine.Debug.Log("Trigger lose screen", this);
	}
}
