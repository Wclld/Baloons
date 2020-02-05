using UnityEngine;

public class Menu : MonoBehaviour
{
	[SerializeField] CanvasGroup _menuCanvas;
	[SerializeField] CanvasGroup _settingsCanvas;

	public void ChangeMenuState(bool isOn)
	{
		ChangeCanvasState(_menuCanvas,isOn);
	}
	public void ChangeSettingsState(bool isOn)
	{
		ChangeCanvasState(_settingsCanvas,isOn);
	}

	private void ChangeCanvasState(CanvasGroup canvas, bool isOn)
	{
		canvas.interactable = isOn;
		canvas.blocksRaycasts = isOn;
		canvas.alpha = isOn? 1 : 0;
	}

}