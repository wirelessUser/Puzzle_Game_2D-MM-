using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<DraggingBox> draggBoxesList = new List<DraggingBox>();
    public GameObject dragBoxParent;
   public  int childCount;
   public  int listItemIndex,maxIndex;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }
    void Start()
    {
        childCount = dragBoxParent.transform.childCount;
        DragBoxListFilling();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void DragBoxListFilling()
    {

        DraggingBox[] getAllChildrens = dragBoxParent.GetComponentsInChildren<DraggingBox>();
        draggBoxesList.AddRange(getAllChildrens);
        draggBoxesList.Reverse();
        draggBoxesList[listItemIndex].GetComponent<DraggingBox>().StopperBOxActivation(false);
        maxIndex = draggBoxesList.Count;
    }


    public void SetTry()
    {
        Debug.Log($"Called set trty");
        listItemIndex++;
        if (listItemIndex<maxIndex)
        {
            draggBoxesList[listItemIndex].GetComponent<DraggingBox>().StopperBOxActivation(false);
            draggBoxesList[listItemIndex - 1].GetComponent<DraggingBox>().StopperBOxActivation(true);
        }
        else
        {
            Debug.Log($"You've Lost the game...");
        }


        
    }

    #region Another way............

   

    #endregion









}
