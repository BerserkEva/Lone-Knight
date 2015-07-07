using UnityEngine;
using System.Collections;

public class BossMover : MonoBehaviour {

	private float speed = 2.0f;
	private bool visible;
	public Camera camera;

	void Start()
	{
		renderer.enabled = false;
	}



	void Update ()
	{
		if (transform.position.x == camera.transform.position.x);
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
