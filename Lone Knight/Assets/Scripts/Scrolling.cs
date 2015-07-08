using UnityEngine;
using System.Collections;

public class Scrolling : MonoBehaviour 
{
	//private gameController GameController;
	//private Vector3 pos = new Vector3(150.0f, 0.0f, 0.0f); 
	//pos.x = ;

	public Scrolling current;

	float pos = 0;
	public float speed;

	void Start()
	{
		current = this;
	}

	void Update() 
	{
		pos += speed;
		if (pos > 1.0f)
			pos -= 1.0f;

		renderer.material.mainTextureOffset = new Vector2(pos, 0);
			/*if (transform.position.x < 150.0f)
			{
				float translation = Time.deltaTime * 5;
				transform.Translate (translation, 0, 0);
			} 
			else 
			{
				transform.position = pos;
			}*/
		}


}