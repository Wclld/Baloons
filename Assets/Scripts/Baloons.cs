using System;
using System.Collections.Generic;
using UnityEngine;

public class Baloons : MonoBehaviour
{
	[SerializeField] uint _baloonsCount;
	[SerializeField] float	_xSpawnOffset;
	[SerializeField] float _moveSpeed;
	[SerializeField] GameObject _baloonPrefab;
	private Stack<GameObject> _baloonPool = new Stack<GameObject>();
	private List<GameObject> _baloonsOnScene = new List<GameObject>();
	private Vector2 _screenSize;

	private void Awake() 
	{
		PopulatePool();
		Baloon.OnBaloonClicked += TurnOffBaloon;
	}
	private void Start()
	{
		var canvas = GetComponentInParent<Canvas>();
		_screenSize = canvas.GetComponent<RectTransform>().rect.size;
	}

	private void Update()
	{
		if(_baloonPool != null)
		{
			MoveBaloons();
		}
	}

	private void MoveBaloons()
	{
		if(_baloonsOnScene.Count < _baloonsCount)
		{
			AddBaloons(_baloonsCount - _baloonsOnScene.Count);
		}
		for (var i = 0; i < _baloonsOnScene.Count; i++)
		{
			var currentBaloon = _baloonsOnScene[i];
			currentBaloon.transform.position += Vector3.up * _moveSpeed * Time.deltaTime;
		}
	}

	private void AddBaloons(long count)
	{
		for (var i = 0; i < count; i++)
		{
			if(_baloonPool.Count <= 0)
			{
				PopulatePool();
			}
			var newBaloon = _baloonPool.Pop();
			newBaloon.GetComponent<RectTransform>().localPosition = GetNewBaloonPosition();
			newBaloon.SetActive(true);
			_baloonsOnScene.Add(newBaloon);
		}
	}

	public void TurnOffBaloon(GameObject baloon)
	{
		baloon.SetActive(false);
		_baloonsOnScene.Remove(baloon);
		_baloonPool.Push(baloon);
	}

	private void PopulatePool()
	{
		for (var i = 0; i < _baloonsCount - _baloonPool.Count; i++)
		{
			var newBaloon = Instantiate(_baloonPrefab, transform);
			newBaloon.SetActive(false);
			_baloonPool.Push(newBaloon);
		}
	}

	private Vector3 GetNewBaloonPosition()
	{
		var result = Vector3.zero;
		result.y = -_screenSize.y / 2;
		result.x = UnityEngine.Random.Range(-_xSpawnOffset,_xSpawnOffset);
		return result;
	}
}