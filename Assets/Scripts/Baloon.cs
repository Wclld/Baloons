using System;
using UnityEngine;

public class Baloon : MonoBehaviour 
{
	public static event Action<GameObject> OnBaloonClicked;
	
	public void ClickBaloon()
	{
		OnBaloonClicked(gameObject);
	}
}