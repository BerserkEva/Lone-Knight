using UnityEngine;
using System.Collections;

public class EndLevel : MonoBehaviour {

	//private gameController GameController;
	private int counter = 0;
	//bool visible = renderer.isVisible;
	/*void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			GameController = gameControllerObject.GetComponent<gameController>();
		}
		
		if (gameControllerObject == null)
		{
			Debug.Log("Can't find game controller Script.");
		}
	}*/

	/*void OnTriggerEnter(Collider other)
	{
		int counter = 0;

		/*counter++;
		Debug.Log (counter);
		if (counter == 10) 
		{
			Destroy (gameObject);
		}*/

		/*if (other.tag == "Boundary") 
		{
			return;
		}

		if(other.tag == "Player")
	    {
			counter++;
			Debug.Log (counter);
			if (counter == 10) 
			{
			Destroy (other.gameObject);
			}
			//Application.LoadLevel ("title screen");
		}*/
	/*	if (other.tag == "Finish")
		{
			Debug.Log (counter);
			counter++;		
			if (counter == 10) 
			{

				Destroy (other.gameObject);
			}
		}
	}*/

	void OnCollisionEnter(Collision other)
	{
		//if (other.gameObject.name == "Finish") 
		//{
			//if(other.gameObject.renderer.isVisible)
			//{
				//Debug.Log(other.gameObject.renderer.isVisible);
				counter += 1;
				Debug.Log(counter);
				checkHit ();
			//}
		//}
	}

	void checkHit()
	{
		if (counter == 5)
		{
			Destroy(gameObject);
		}
	}
}
