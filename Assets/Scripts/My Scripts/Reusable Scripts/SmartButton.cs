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
		Exit,
		CoroutineTrigger
	}

	public Usage UseAs;

	public string Value;
	public MonoBehaviour ComponentToUse;
	//public GameObject GoToPanel;
	//public GameObject OurParentPanel;
	public List<GameObject> objectsToHide = new List<GameObject>();
	public List<GameObject> objectsToShow = new List<GameObject>();

	public static System.Action<SmartButton> OnSmartButtonClickEvent;

	void Start()
	{
		//if (gameObject.GetComponent<Collider2D>() == null)
		//{
		//	Debug.LogWarning("Warning! Smart button might not work without a collider or collider2D attached to the GameObject");
		//}
	}

	void Update()
	{
		//For those NGUI Users ;)
		useFunction();
	}

	public virtual void useFunction()
	{
		if (Input.GetMouseButtonDown(0))
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

				case Usage.SceneLoader:
					Application.LoadLevel(Value);
					break;

				case Usage.PanelSwitcher:
					if (objectsToHide != null)
					{
						for (int i = 0; i < objectsToHide.Count; i++)
						{
							objectsToHide[i].SetActive(false);
						}
					}
					if (objectsToShow != null)
					{
						for (int i = 0; i < objectsToShow.Count; i++)
						{
							objectsToShow[i].SetActive(true);
						}
					}
					break;

				case Usage.Exit:
					Application.Quit();
					break;

				case Usage.CoroutineTrigger:
					ComponentToUse.StartCoroutine(Value);
					break;
			}
		}

	}
}