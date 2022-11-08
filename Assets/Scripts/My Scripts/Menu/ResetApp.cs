using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetApp : MonoBehaviour
{
	public List<GameObject> objectsToHide = new List<GameObject>();
	public List<GameObject> objectsToShow = new List<GameObject>();
	private bool reset = true;
	private bool moveNext = true;


	void OnMouseDown()
	{
		newStart();
	}

	public void newStart()
    {
		StartCoroutine(RestartApp());
	}

	public IEnumerator RestartApp()
	{
		while (reset)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			Debug.Log("Reloaded");
			yield return null;
		}
		while (moveNext)
		{
			nextCanvas();
			Debug.Log("Reset");
			yield return null;
		}
	}

	public void nextCanvas()
    {
		if (objectsToHide != null)
		{
			for (int i = 0; i < objectsToHide.Count; i++)
			{
				if (objectsToHide[i].activeSelf)
				{
					objectsToHide[i].SetActive(false);
					Debug.Log("objects hidden");

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
					Debug.Log("objects shown");

				}
			}
		}
	}

}
