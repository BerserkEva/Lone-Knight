using UnityEngine;
using System.Collections;

public class BossMover : MonoBehaviour {

	private float speed = 2.0f;
	private int counter = 0;
	public BossMover current;

	void Start()
	{
		current = this;
	}

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

	public void Move ()
	{
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
