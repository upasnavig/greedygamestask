using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class MovementController : MonoBehaviour
{
    public Action<GameObject> PlaneSelected;
    void OnMouseDown()
    {
        PlaneSelected(gameObject);
    }
}
