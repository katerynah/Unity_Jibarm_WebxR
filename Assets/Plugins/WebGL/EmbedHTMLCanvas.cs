using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class EmbedHTMLCanvas : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ToggleOverlay();
    public void testBtn()
    {
        Debug.Log($"Test Button clicked");
        ToggleOverlay();
    }

}

