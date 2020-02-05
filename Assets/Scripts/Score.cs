using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	[SerializeField] Text _scoreText;
	private int _score;

	private void Start() 
	{
		Baloon.OnBaloonClicked += x => IncreaseScore();
	}

	private void IncreaseScore()
	{
		_score++;
		if(_scoreText != null)
		{
			_scoreText.text = _score.ToString();
		}
	}
}