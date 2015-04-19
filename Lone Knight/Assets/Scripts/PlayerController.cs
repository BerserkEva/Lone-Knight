using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xmin, xmax, ymin,ymax;
}

public class PlayerController : MonoBehaviour {
	
	public float speed;
	public float acceleration;
	public float tilt;
	public Boundary boundary;
	
	//private Vector3 currentSpeed;
	//private float maxSpeed = 12;
	
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private Transform savedTransform;
	private float dragSpeed = 0.1f;
	[SerializeField]
	float _vert = 2.5f, _hor = 2.5f;
	Vector2 startPos;

	private float nextFire;
	private int counter = 0;

	void Start()

	{
		savedTransform = transform;
		startPos = savedTransform.position;
	}

	void Update()
	{
		Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
		viewPos.x = Mathf.Clamp01(viewPos.x);
		viewPos.y = Mathf.Clamp01(viewPos.y);
		transform.position = Camera.main.ViewportToWorldPoint(viewPos);

		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) 
		{					//Touch touch = Input.GetTouch(0);
			Vector2 deltaPosition = Input.GetTouch(0).deltaPosition;
			Vector2 moved = new Vector2(deltaPosition.x, deltaPosition.y);

			transform.position = Camera.main.ScreenToWorldPoint(moved);

			/*switch(Input.GetTouch(0).phase)
			{
			case TouchPhase.Began:
				break;

			case TouchPhase.Moved:
				DragObject(deltaPosition);
				break;

			case TouchPhase.Ended:
				break;
			}*/
		}

			/*if(touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
			{
				Vector2 TouchPo1sition = Camera.main.ScreenToWorldPoint(new Vector2(touch.position.x, touch.position.y));
				transform.position = Vector2.Lerp (transform.position, TouchPosition, 2.0f);
			}*/

			if (Input.GetButton ("Fire1") && Time.time > nextFire) 
			{
				nextFire = Time.time + fireRate;
				Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			} 
		
			if (shot.rigidbody.position.x > boundary.xmax) 
			{
				Destroy (shot);
			}
	}

	/*void DragObject(Vector2 deltaPosition)
	{
		savedTransform.position = new Vector2 (Mathf.Clamp((deltaPosition.x * dragSpeed) + savedTransform.position.x, 
		                                                   startPos.x - _hor, startPos.y - _hor),
		                                       Mathf.Clamp((deltaPosition.y * dragSpeed) + savedTransform.position.y, 
		            										startPos.y - _vert, startPos.x - _vert));

	}*/

	//input
	void FixedUpdate ()
	{
		float moveHoriztontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		Vector3 movement = new Vector3(moveHoriztontal, moveVertical, 0.0f);
		rigidbody.velocity = movement * speed;
		//currentSpeed = rigidbody.velocity;
		
		//if (currentSpeed.x < maxSpeed) 
		//{
		//	currentSpeed.x += acceleration;
		//}

		/*Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
		viewPos.x = Mathf.Clamp01(viewPos.x);
		viewPos.y = Mathf.Clamp01(viewPos.y);
		rigidbody.position = new Vector3 
			(
				Mathf.Clamp(rigidbody.position.x, boundary.xmin, boundary.xmax),
				Mathf.Clamp(rigidbody.position.y, boundary.ymin, boundary.ymax),
				0.0f
				);


		transform.position = Camera.main.ViewportToWorldPoint(viewPos);*/


		
		//rigidbody.rotation = Quaternion.Euler(0.0f, rigidbody.velocity.y, 0.0f) - tilt;
	}

	/*void OnCollisionEnter(Collision other)
	{


		if (other.gameObject.tag == "Enemy") 
		{
			DestroyByContact.Destroy(other.gameObject);
		}
		if (other.gameObject.tag == "Finish")
		{
			if(other.gameObject.renderer.isVisible)
			{
				counter += 1;
				checkHit ();
			}
		}
		
	}

	void checkHit()
	{
		if (counter == 5)
		{
			Destroy(gameObject);
		}
	}*/
	
}
