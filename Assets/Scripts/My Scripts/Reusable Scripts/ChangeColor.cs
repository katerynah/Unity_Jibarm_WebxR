using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> objectMats = new List<GameObject>();
    public List<GameObject> missMats = new List<GameObject>();
    private List<GameObject> allMats = new List<GameObject>();
    private List<GameObject> allResetMats = new List<GameObject>();
    private Material selectionMaterial;
    private List<Material> defaultMaterial = new List<Material>();
    Material newMat;
    public enum Materials
    {
        Purple, Green, Blue, DWhite, Red, Black, White
    }
    public Materials UseAs;


    public void setColor(bool setMat)
    {
        // Set color
        if (setMat == true)
        {

            for (var i = 0; i < objectMats.Count; i++)
            {
                if (objectMats[i].GetComponent<MeshRenderer>() != null)
                {
                    // add Current Objects
                    allMats.Add(objectMats[i]);
                }

                ChangeChildLayer(objectMats[i].transform, true);
            }

            for (var i = 0; i < missMats.Count; i++)
            {
                ChangeChildLayer(missMats[i].transform, false);
                allMats.Remove(missMats[i]);
            }

            allResetMats = allMats;

            chooseMaterial();

            for (var i = 0; i < allMats.Count; i++)
            {
                var selectionRenderer = allMats[i].GetComponent<MeshRenderer>();
                defaultMaterial.Add(selectionRenderer.material);
                selectionMaterial = newMat;
                selectionRenderer.material = selectionMaterial;
            }
            setMat = false;
        } // Remove color
        else if (setMat == false)
        {
            for (var i = 0; i < allResetMats.Count; i++)
            {
                var selectionRenderer = allResetMats[i].GetComponent<MeshRenderer>();
                selectionMaterial = defaultMaterial[i];
                selectionRenderer.material = selectionMaterial;
            }
        }

    }

    void chooseMaterial()
    {
        switch (UseAs)
        {
            case Materials.Purple:
                newMat = Resources.Load<Material>("Materials/Select_violet_mat");
                break;
            case Materials.Green:
                newMat = Resources.Load<Material>("Materials/Select_green_mat");
                break;
             case Materials.Blue:
                newMat = Resources.Load<Material>("Materials/Select_blue_mat");
                break;
            case Materials.DWhite:
                newMat = Resources.Load<Material>("Materials/Select_dwhite_mat");
                break;
            case Materials.Red:
                newMat = Resources.Load<Material>("Materials/Select_red_mat");
                break;
            case Materials.Black:
                newMat = Resources.Load<Material>("Materials/Select_black_mat");
                break;
            case Materials.White:
                newMat = Resources.Load<Material>("Materials/Select_white_mat");
                break;
        }
    }

    void ChangeChildLayer(Transform Obj, bool add)
    {
        // does it have a child?
        if (Obj.transform.childCount > 0)
        {
            foreach (Transform child in Obj.transform)
            {

                if (add == true)
                {
                    if (child.gameObject.GetComponent<MeshRenderer>() != null)
                    {
                        allMats.Add(child.gameObject);
                    }

                    if (child.transform.childCount > 0)
                    {
                        ChangeChildLayer(child, true);
                    }

                } else if (add == false)
                {
                    allMats.Remove(child.gameObject);

                    if (child.transform.childCount > 0)
                    {
                        ChangeChildLayer(child, false);
                    }
                }
            }


        }

    }

}
