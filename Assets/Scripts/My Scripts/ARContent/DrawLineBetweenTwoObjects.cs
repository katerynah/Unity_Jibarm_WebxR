using System.Collections.Generic;
using UnityEngine;

public class DrawLineBetweenTwoObjects : MonoBehaviour
{
    GameObject lineRendOffset;
    GameObject lineRend;
    GameObject linePrefab;
    LineRenderer line;
    bool ready = true;
    public bool removeLines = false;
    [HideInInspector]
    public int currIndex;
    Vector3 vec;
    Quaternion quat;

    [System.Serializable]
    public class RendererLines
    {
        public GameObject NoteObj;
        public GameObject RefObj;

        public RendererLines(GameObject note, GameObject refer)
        {
            NoteObj = note;
            RefObj = refer;
        }
    }

    public List<RendererLines> rendererList = new List<RendererLines>();

    void Start()
    {
        vec = Vector3.zero;
        quat = Quaternion.identity;
    }

    public void setLines(string amount)
    {
        if (ready == true)
        {
            if (amount == "all")
            {
                for (int i = 0; i < rendererList.Count; i++)
                {
                    // Note Object and its first child -> Line Renderer for transform position
                    lineRendOffset = rendererList[i].NoteObj.transform.GetChild(0).gameObject;

                    linePrefab = Resources.Load<GameObject>("Templates/LineRend_temp");

                    lineRend = Instantiate(linePrefab, vec, quat);

                    line = lineRend.GetComponent<LineRenderer>();

                    // Set the position count of the linerenderer to two
                    line.positionCount = 2;
                    //line.material = new Material(Shader.Find("Sprites/Default"));

                    // (100f * 0.075f /2f)

                    Transform first = lineRendOffset.transform;
                    Transform second = rendererList[i].RefObj.transform;
                    DrawLineBetweenObjects(first, second);
                }
            } else if (amount == "one")
            {
                // Note Object and its first child -> Line Renderer for transform position
                lineRendOffset = rendererList[currIndex].NoteObj.transform.GetChild(0).gameObject;

                linePrefab = Resources.Load<GameObject>("Templates/LineRend_temp");

                lineRend = Instantiate(linePrefab, vec, quat);

                line = lineRend.GetComponent<LineRenderer>();

                // Set the position count of the linerenderer to two
                line.positionCount = 2;
                line.material = new Material(Shader.Find("Sprites/Default"));

                // (100f * 0.075f /2f)

                Transform first = lineRendOffset.transform;
                Transform second = rendererList[currIndex].RefObj.transform;
                DrawLineBetweenObjects(first, second);
            }
            
            ready = false;
        }
        
    }

    void DrawLineBetweenObjects(Transform firstT, Transform secondT)
    {
        // Set the positions of the LineRenderer
        line.SetPosition(0, firstT.position);
        line.SetPosition(1, secondT.position);
        line.sortingLayerName = "Background";
    }

    public void removeNotes()
    {
        var objects = GameObject.FindGameObjectsWithTag("rend-lines");
        foreach (var obj in objects)
        {
            Destroy(obj);
        }
        ready = true;
        removeLines = false;
    }
}