using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DrawRay : MonoBehaviour
{
    [SerializeField]
    //public GameObject whenEnabled;
    public GameObject cam;
    public GameObject lineRend;


    void Start()
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
        
        //AssetDatabase.CreateAsset(mesh, $"Assets/Resources/Other/{mesh.name}");
        //AssetDatabase.SaveAssets();

        //setLine();
    }

    void setLine()
    {
        lineRend.transform.position = cam.transform.position;
        lineRend.transform.rotation = cam.transform.rotation;
        lineRend.transform.parent = cam.transform;
    }

}