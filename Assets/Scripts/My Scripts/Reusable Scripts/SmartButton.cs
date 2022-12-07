using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SmartButton : MonoBehaviour
{

	public enum Usage
	{
		Default,
		URL,
		SceneLoader,
		PanelSwitcher,
		CoroutineTrigger
	}

	public Usage UseAs;

	public string Value;
	public MonoBehaviour ComponentToUse;
	public List<GameObject> objectsToHide = new List<GameObject>();
	public List<GameObject> objectsToShow = new List<GameObject>();
	private RestartScript restartScr;


	public System.Action<SmartButton> OnSmartButtonClickEvent;

	void Start()
	{
		if (gameObject.GetComponent<Collider>() == null && gameObject.GetComponent<Collider2D>() == null)
		{
			Debug.LogWarning("Warning! Smart button might not work without a collider or collider2D attached to the GameObject");
		}
        restartScr = GameObject.Find("StartMethods").GetComponent<RestartScript>();
    }


	void OnMouseDown()
	{
		onClick();
	}

	public void onClick()
	{

		switch (UseAs)
		{
			case Usage.Default:
				if (OnSmartButtonClickEvent != null)
					OnSmartButtonClickEvent(this);
				break;

			case Usage.URL:
				Application.OpenURL(Value);
				break;

			case Usage.PanelSwitcher:
				if (objectsToHide != null)
				{
					for (int i = 0; i < objectsToHide.Count; i++)
					{
						if (objectsToHide[i].activeSelf)
						{
							objectsToHide[i].SetActive(false);
						}
					}
				}
				if (objectsToShow != null)
				{
					for (int i = 0; i < objectsToShow.Count; i++)
					{
						if (!objectsToShow[i].activeSelf)
						{
							objectsToShow[i].SetActive(true);
						}
					}
				}
				break;

			case Usage.CoroutineTrigger:
				ComponentToUse.StartCoroutine(Value);
				break;
		}

		restartScr.adaptScripts(clickedBtn: gameObject);
	}
}