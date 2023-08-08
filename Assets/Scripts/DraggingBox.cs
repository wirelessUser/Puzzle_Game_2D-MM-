using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
public class DraggingBox : MonoBehaviour
{
    public GameObject  stopperBox;
    public bool isActive;
    public Button SolutionCheckButton;

    public int[] chakraDotsIds = new int[4];
    // SolutionCheckButton.interactable = (!chakraDotsIds.Contains(0) ? true : false);
    public puzzleCreationScript puzzleCraetionScriptRef;

    public GameObject hintBox,blackHintDot,whiteHintDot;

    private void Awake()
    {
        SolutionCheckButton.interactable = false;
    }

   
    //.. Method to get the ids from the ChakraDot..

    public void SetchakraDotsIdAndSlotNum(int slotNum,int chakraDotId)
    {
        chakraDotsIds[slotNum] = chakraDotId;
        SolutionCheckButton.interactable = (!chakraDotsIds.Contains(0) ? true : false);

    }


    public void ButtonClickSolvedOrNot()
    {
        puzzleCraetionScriptRef.CheckBlackWhitePegs(chakraDotsIds,this);
        SolutionCheckButton.interactable = false;
     
    }


    public void ActivateHintDots(int hintFlag)
    {
        if (hintFlag==1)
        {
            GameObject blackHint = Instantiate(blackHintDot, hintBox.transform, false);
        }
        if (hintFlag == 2)
        {
            GameObject whiteHint = Instantiate(whiteHintDot, hintBox.transform, false);
        }

    }



    public void StopperBOxActivation(bool Activation)
    {
        bool isActive = (Activation == true ? true : false);
        stopperBox.SetActive(isActive);
    }
}
