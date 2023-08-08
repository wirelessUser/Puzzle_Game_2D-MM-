using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class dropChakra : MonoBehaviour,IDropHandler
{
    public int slotNum;

    public DraggingBox draggingBoxRef;
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log($"OnDrop ");
        // eventData.pointerDrag.transform.position = eventData.position;

        //..............

        // Get the dragged object
        //GameObject draggedObject = eventData.pointerDrag;

        //// Get the position of the object this script is attached to
        //Vector3 snapPosition = transform.position;

        //// Snap the dragged object to the snap position
        //draggedObject.transform.position = snapPosition;

        //....Drop and instanitiate a new Obejct............

        GameObject chakra = Instantiate(eventData.pointerDrag.gameObject, transform, true);
        chakra.transform.position = transform.position;

        // Set slotnum and chakraId

        draggingBoxRef.SetchakraDotsIdAndSlotNum(slotNum, eventData.pointerDrag.gameObject.GetComponent<PeralDragScript>().CrystalId);

    }

  
}
