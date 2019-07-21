using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    private Transform parentPivot;
    [SerializeField] Text visibility;
    [SerializeField] Text choosePlaneText;

    public void Setparent(Transform parent)
    {
        parentPivot = parent;
        SetChooseplaneText(0);
    }
    public void OnClickZoomIn()
    {
        ZoomIn();
    }
    public void OnClickZoomOut()
    {
        ZoomOut();
    }
    internal void SetVisibility(float scale)
    {
        visibility.text = Mathf.Ceil(scale * 100).ToString() + "% VISIBLE";
    }

    void ZoomOut()
    {
        if (parentPivot.transform.localScale.x < 1)
        {
            parentPivot.transform.localScale = new Vector3(parentPivot.transform.localScale.x + 0.1f, parentPivot.transform.localScale.y + 0.1f, parentPivot.transform.localScale.z);
            SetVisibility(parentPivot.transform.localScale.x);
        }
    }
    void ZoomIn()
    {
        if (parentPivot.transform.localScale.x > 0.25f)
        {
            parentPivot.transform.localScale = new Vector3(parentPivot.transform.localScale.x - 0.1f, parentPivot.transform.localScale.y - 0.1f, parentPivot.transform.localScale.z);
            SetVisibility(parentPivot.transform.localScale.x);
        }
    }

    public void SetChooseplaneText(int number)
    {
        if (number == 0)
        {
            choosePlaneText.text = GameConstants.choose1stPlane;
        }
        else
        {
            choosePlaneText.text = GameConstants.choose2ndPlane;
        }
    }
}
