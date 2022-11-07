using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResetName : MonoBehaviour
{
    [SerializeField]
    public int index = 0;
    private TextMeshProUGUI currTextObj;
    public GameObject resetTextObj;
    private string[] names = new string[] { "WebAR" };

    private void OnEnable()
    {
        currTextObj = resetTextObj.GetComponent<TextMeshProUGUI>();
        // making clickable
        GameObject parentObj = resetTextObj.transform.parent.gameObject;
        parentObj.GetComponent<Collider>().enabled = true;
        currTextObj.SetText(names[index]);

    }
}
