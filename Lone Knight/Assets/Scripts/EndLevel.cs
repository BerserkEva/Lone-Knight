using UnityEngine;
using System.Collections;

public class EndLevel : MonoBehaviour {

	//private gameController GameController;
	private int counter = 0;
	private float speed = 2.0f;
	private bool visible;
	public Camera camera;


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Boundary")
		{
			return;				
		}

		if (other.gameObject.tag == "player" && other.gameObject.tag == "Finish") 
		{
			counter += 1;
			Debug.Log (counter);
			checkHit ();
		}
	}

	void checkHit()
	{
		if (counter == 5)
		{
			Destroy(gameObject);
			Application.LoadLevel("title screen");
		}
	}

	void Start()
	{
		renderer.enabled = false;
	}

	void Update ()
	{
		Vector3 pos = Camera.main.WorldToViewportPoint (camera.transform.position);
		if (transform.position.x > pos.x)
		{
			renderer.enabled = false;

		}

		else if (transform.position.x <= pos.x);
		{
			visible = renderer.isVisible;
			renderer.enabled = true;
		}
		
		if (visible && renderer.enabled == true)
		{
			Debug.Log("Found");
			if(transform.position.y == 9.0f)
			{
				rigidbody.velocity = transform.up * -speed;
			}
			if(transform.position.y == -9.0f)
			{
				rigidbody.velocity = transform.up * speed;
			}
		}
		
	}
}
