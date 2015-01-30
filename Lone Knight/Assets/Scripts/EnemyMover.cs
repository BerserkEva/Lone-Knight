using UnityEngine;
using System.Collections;

public class EnemyMover : MonoBehaviour
{
	private float speed = 10;
	//public Camera b;
	//private float random = Random.Range(-13, 13);
	//private float q = b.transform.position.x;
	//private float qi = q/2;

	void Start ()
	{
		Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
		viewPos.x = Mathf.Clamp01(viewPos.x);
		viewPos.y = Mathf.Clamp01(viewPos.y);
		transform.position = Camera.main.ViewportToWorldPoint(viewPos);

		/*if (transform.position.x < viewPos.x )
		{
			if(transform.position.y > 0 && transform.position.y < 9)
			{
				rigidbody.velocity = (transform.right * -speed) + (transform.up * -speed);
			}
			else if(transform.position.y < 0 && transform.position.y > -9)
			{
				rigidbody.velocity = (transform.right * -speed) + (transform.up * speed);
			}
			else
			{
				rigidbody.velocity = transform.right * -speed;
			}
		}*/
		rigidbody.velocity = transform.right * -speed;

	}
}
