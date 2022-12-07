using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DrawRay : MonoBehaviour
{
    [SerializeField]
    //public GameObject whenEnabled;
    public GameObject cam;
    public List<GameObject> lineRends = new List<GameObject>();

    void Start()
    {

        foreach (var lineRend in lineRends.ToArray())
        {
            var mesh = new Mesh
            {
                name = "Line Renderer Mesh"
            };

            GetComponent<MeshFilter>().mesh = mesh;
            LineRenderer line = lineRend.GetComponent<LineRenderer>();
            line.BakeMesh(mesh, cam.GetComponent<Camera>(), true);
            MeshCollider lineCollider = lineRend.GetComponent<MeshCollider>();
            lineCollider.sharedMesh = mesh;
        }
       
        
        //AssetDatabase.CreateAsset(mesh, $"Assets/Resources/Other/{mesh.name}");
        //AssetDatabase.SaveAssets();

        //setLine();
    }

    void setLine()
    {
        lineRends[0].transform.position = cam.transform.position;
        lineRends[0].transform.rotation = cam.transform.rotation;
        lineRends[0].transform.parent = cam.transform;
    }

}