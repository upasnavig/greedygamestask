using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InterChangingPlanes : MonoBehaviour
{
    public List<GameObject> changeplanePositions = new List<GameObject>();
    public Action<int> planesSelected;
    internal void onplaneSelected(GameObject selectedPlane)
    {
        changeplanePositions.Add(selectedPlane);
        if (changeplanePositions.Count % 2 == 0)
        {
            onInterchangingPosition();
            changeplanePositions.Clear();
        }
        planesSelected(changeplanePositions.Count);
    }

    void onInterchangingPosition()
    {
        Texture temptexture = changeplanePositions[0].GetComponent<Renderer>().material.mainTexture;
        changeplanePositions[0].GetComponent<Renderer>().material.mainTexture = changeplanePositions[1].GetComponent<Renderer>().material.mainTexture;
        changeplanePositions[1].GetComponent<Renderer>().material.mainTexture = temptexture;
    }
}
