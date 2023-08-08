using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleCreationScript : MonoBehaviour
{
    public List<GameObject> chakraPrefabList = new List<GameObject>();
    public List<GameObject> riddleList = new List<GameObject>();
    public List<GameObject> SolutionSlotList = new List<GameObject>();
    public int chakraAmount = 4;
  
  //  public Transform parent;
    void Start()
    {
        CreatePuzzle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void CreatePuzzle()
    {
        for (int i = 0; i < 6; i++)
        {
            int randomChakraNum = Random.Range(0, chakraPrefabList.Count);

           riddleList.Add(chakraPrefabList[randomChakraNum]); //Line-1

            GameObject chakraInst = Instantiate(chakraPrefabList[randomChakraNum], SolutionSlotList[i].transform, false);
            //riddleList.Add(chakraInst); //Line 2
            //chakraInst.transform.position = chakraInst.transform.parent.position;
            chakraInst.transform.position = SolutionSlotList[i].transform.position;
            //chakraInst.transform.localScale = new Vector3(75,75,0);
           
            chakraInst.GetComponent<PeralDragScript>().enabled = false;
            //...chakraPrefabList[randomChakraNum].transform.position = SolutionSlotList[i].transform.position;
            //.... chakraPrefabList[randomChakraNum].GetComponent<PeralDragScript>().enabled = false;

        }
    }



    public void CheckBlackWhitePegs(int[] ids,DraggingBox DraggingBoxref)
    {
        int[] postionPropertyCheckArray = new int[4] { -1, -1, -1, -1 };
        int[] colorPropertyCheckArray = new int[4] { -1, -1, -1, -1 };

        int BothPropertyMatching = 0, singlePropertyMatching = 0;

        for (int i = 0; i < 4; i++)
        {
            if (ids[i]== riddleList[i].GetComponent<PeralDragScript>().CrystalId)
            {
                BothPropertyMatching += 1;
                postionPropertyCheckArray[i] = 1;
                colorPropertyCheckArray[i] = 1;
                Debug.Log($"Mathced=={ids[i]} && {riddleList[i].GetComponent<PeralDragScript>().CrystalId}");
                DraggingBoxref.ActivateHintDots(1);
            }
            else
            {
                singlePropertyMatching += 1;
                postionPropertyCheckArray[i] = 1;
                colorPropertyCheckArray[i] = 1;
                Debug.Log($"Mathced=={ids[i]} && {riddleList[i].GetComponent<PeralDragScript>().CrystalId}");
                DraggingBoxref.ActivateHintDots(2);
            }
        }

        if (BothPropertyMatching==4)
        {
            //winning Full
            Debug.Log("You won ");
            return;
        }


        // white check....

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (i!=j && postionPropertyCheckArray[i]!=1 && colorPropertyCheckArray[i] != 1)
                {
                    if (ids[i] == riddleList[i].GetComponent<PeralDragScript>().CrystalId)
                    {
                        singlePropertyMatching += 1;
                        postionPropertyCheckArray[i] = 1;
                        colorPropertyCheckArray[i] = 1;
                        Debug.Log($"Mathced=={ids[i]} && {riddleList[i].GetComponent<PeralDragScript>().CrystalId}");
                        DraggingBoxref.ActivateHintDots(2);
                    }
                }
            }
        }// for loop....

        GameManager.instance.SetTry();
    }
}
