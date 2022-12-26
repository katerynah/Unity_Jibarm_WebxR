using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Runtime.InteropServices;

[RequireComponent(typeof(TMP_Text))]
public class EmbedHTMLLink : MonoBehaviour, IPointerClickHandler
{
    private TMP_Text m_textMeshPro;

   [DllImport("__Internal")]
    private static extern void OpenPage(string url);

    void Start() {
        m_textMeshPro = GetComponent<TMP_Text>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        int linkIndex = TMP_TextUtilities.FindIntersectingLink(m_textMeshPro, Input.mousePosition, null);
        TMP_LinkInfo linkInfo = m_textMeshPro.textInfo.linkInfo[linkIndex];
        Debug.Log($"The link ID {linkInfo.GetLinkID()}, Text {linkInfo.GetLinkText()}, Text Component {linkInfo.textComponent.text}, Info {linkInfo}");

        //if (linkIndex != -1)
        //{
        //   linkInfo = m_textMeshPro.textInfo.linkInfo[linkIndex];
        //    //Debug.Log($"The link ID {linkInfo.GetLinkID()}, Text {linkInfo.GetLinkText()}, Text Component {linkInfo.textComponent.text}, Info {linkInfo}");
        //    //OpenPage(linkInfo.GetLinkText());
        //}

    }

}

