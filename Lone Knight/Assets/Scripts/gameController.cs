using UnityEngine;
using System.Collections;

public class gameController : MonoBehaviour {

	public GameObject Hazard;
	public Vector3 SpawnValues;
	public int hazardCount;

	private Boundary boundary;
	//private Vector3 pos = new Vector3(150.0f, 0.0f, 0.0f); 

	public float spawnWait;
	public float startWait;
	public float waveWait;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	public GUIText lifeText;

	private bool gameOver;
	private bool stopped;
	private bool restart;
	private bool pause;

	private int score;
	private int lives;
	private int timeElapsed;
	private float pos;

	public Camera camera;
	public GameObject player;

	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}

	void UpdateLife()
	{
		lifeText.text = "Life : " + lives;
	}

	void Start()
	{
		score = 0;
		gameOver = false;
		restart = false;
		stopped = false;
		pause = false;
		gameOverText.text = "";
		restartText.text = "";
		lives = 3;
		//timeElapsed = 0;
		//pos = camera.transform.position.x;


		UpdateScore ();
		UpdateLife ();
		StartCoroutine ("SpawnWaves");

		/*if (stopped == false)
		{
			StopCoroutine ("SpawnWaves");
		}*/

	}
	
	IEnumerator SpawnWaves()
	{
		/*if(camera.transform.position.x >= 140)
		{
			stopped = true;
		}

		if(stopped)
		{
			yield break;
		}*/

		yield return new WaitForSeconds(startWait);
		while (!gameOver && !pause) 
		{

			for (int i = 0; i < hazardCount; i++) 
			{

				Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
				viewPos.x = Mathf.Clamp01(viewPos.x);
				viewPos.y = Mathf.Clamp01(viewPos.y);
				transform.position = Camera.main.ViewportToWorldPoint(viewPos);

				Vector3 SpawnPosition = new Vector3 ((SpawnValues.x + camera.transform.position.x), Random.Range(-SpawnValues.y , SpawnValues.y), SpawnValues.z);
				Quaternion SpawnRotation = Quaternion.identity;
				Instantiate (Hazard, SpawnPosition, SpawnRotation);

				if(stopped)
				{
					yield break;
				}

				yield return new WaitForSeconds (spawnWait);
			}

			if(stopped)
			{
				yield break;
			}

			yield return new WaitForSeconds(waveWait);


			if (gameOver)
			{
				restartText.text = "Press R to restart.";
				restart = true;
				break;

			}
		}
	}

	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	public void RemoveLife()
	{
		lives -= 1;
		UpdateLife ();
	}

	public void GameOver()
	{
		gameOverText.text = "Game Over";
		gameOver = true;
	}



	void Update()
	{
		timeElapsed++;
		if (restart)
		{
			if(Input.GetKeyDown(KeyCode.R))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}

		if (!pause)
		{
			Time.timeScale = 1.0f;
		} 
		else 
		{
			Time.timeScale = 0.0f;
		}



		if(Input.GetKeyDown(KeyCode.P))
	    {
			if(pause == true)
			{
				pause = false;
			}

			else
			{
				pause = true;
			}

		}

		if (camera.transform.position.x >= 140)
		{
			StopCoroutine ("SpawnWaves");
		}


	}


	/*private void stoppeding1()
	{
		//yield return new WaitForSeconds (startWait);
		while (!gameOver) 
		{
			if (Camera.main.transform.position.x < 150.0f) 
			{
				float translation = Time.deltaTime * 2;
				Camera.main.transform.Translate (translation, 0, 0);
			}
			else 
			{
				Camera.main.transform.position = pos;
			break;
			}
		}
	}*/
}
