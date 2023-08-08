using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


[RequireComponent(typeof(CanvasGroup))]
public class PeralDragScript : MonoBehaviour,IDragHandler,IBeginDragHandler,IEndDragHandler
{
    public int CrystalId;
    public Vector3 oldPos;


    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log($"Begine drag");
        oldPos = transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
       // Debug.Log($"OnDrag ");
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Debug.Log($"OnEndDrag ");
        transform.position = oldPos;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
