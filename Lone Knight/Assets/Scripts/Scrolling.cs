﻿using UnityEngine;
using System.Collections;

public class Scrolling : MonoBehaviour 
{
	private gameController GameController;
	private Vector3 pos = new Vector3(150.0f, 0.0f, 0.0f); 
	//pos.x = ;


	void Update() 
	{

			if (transform.position.x < 150.0f)
			{
				float translation = Time.deltaTime * 2;
				transform.Translate (translation, 0, 0);
			} 
			else 
			{
				transform.position = pos;
			}
		}

}