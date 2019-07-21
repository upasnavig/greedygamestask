using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePlanes : MonoBehaviour
{
    [SerializeField] private UIController uIController;
    [SerializeField] private AnimationHandler animationHandler;
    [SerializeField] private InterChangingPlanes InterChangingPlanes;
    private GameObject parentPivot;
    private GameObject containerParent;
    private GameObject plane;
    private Transform container;
    private Material[] materials;
    private List<GameObject> listOfplanes;
   
    int numberOfChildPlanes = 3;

    void Start()
    {
        listOfplanes = new List<GameObject>();
        materials = Resources.LoadAll<Material>("Materials");
        InstantiateObjects();
    }

    #region creating 4 player
    public void InstantiateObjects()
    {
        Debug.Log(Screen.width + " " + Screen.height);
        parentPivot = new GameObject();
        parentPivot.transform.position = GameConstants.pivotPos;
        uIController.Setparent(parentPivot.transform);
        InstantiateParentPlane();

        for (int i = 0; i < numberOfChildPlanes; i++)
        {
            plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
            plane.name = i.ToString();
            plane.transform.parent = container;
            plane.AddComponent<BoxCollider>();
            plane.AddComponent<MovementController>();
            plane.GetComponent<MovementController>().PlaneSelected += InterChangingPlanes.onplaneSelected;
            InterChangingPlanes.planesSelected += uIController.SetChooseplaneText;
            listOfplanes.Add(plane);
        }

        SettingFirstHalfPlane(listOfplanes[1]);
        SttingBottomLeftPlane(listOfplanes[2]);
        SettingBottomRightPlane(listOfplanes[3]);
        AssignTextures();
    }

    private void InstantiateParentPlane()
    {
        containerParent = GameObject.CreatePrimitive(PrimitiveType.Plane);
        container = containerParent.transform;
        container.parent = parentPivot.transform;
        container.eulerAngles = new Vector3(0, 270, 90);
        listOfplanes.Add(containerParent);
    }

    #region positioningplanes
    private void SettingFirstHalfPlane(GameObject obj)
    {
        obj.transform.eulerAngles = container.eulerAngles;
        obj.transform.localScale = new Vector3(container.localScale.x / 2f - 0.1f, 1, container.localScale.z - 0.1f);
        obj.transform.localPosition = new Vector3(container.localScale.x * GameConstants.xOffsetForPlane, container.localPosition.y + GameConstants.yOffsetForPlane, container.localPosition.z);
        StartCoroutine(animationHandler.Rotating(obj));

    }

    private void SttingBottomLeftPlane(GameObject obj)
    {
        obj.transform.eulerAngles = container.eulerAngles;
        obj.transform.localScale = new Vector3(container.localScale.x / 2f - 0.1f, 1, container.localScale.z / 2 - 0.1f);
        obj.transform.localPosition = new Vector3(-container.localScale.x * GameConstants.xOffsetForPlane, container.localPosition.y + GameConstants.yOffsetForPlane, container.localScale.z * GameConstants.zOffsetForPlane);
        StartCoroutine(animationHandler.Scaling(obj));
    }
    private void SettingBottomRightPlane(GameObject obj)
    {

        obj.transform.eulerAngles = container.eulerAngles;
        obj.transform.localScale = new Vector3(container.localScale.x / 2f - 0.1f, 1, container.localScale.z / 2 - 0.1f);
        obj.transform.localPosition = new Vector3(-container.localScale.x * GameConstants.xOffsetForPlane, container.localPosition.y + GameConstants.yOffsetForPlane, -container.localScale.z * GameConstants.zOffsetForPlane);
        StartCoroutine(animationHandler.Fading(obj));

    }
    #endregion
    #endregion

    #region Assining random Textures
    private void AssignTextures()
    {
        for (int i = 0; i < listOfplanes.Count; i++)
        {
            listOfplanes[i].GetComponent<Renderer>().material = materials[GameUtility.GetRandomNumber(0,materials.Length)];
        }
    }
    #endregion
}