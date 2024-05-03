using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryUISlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if(transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
                    DragIUIIem Draggableitem = dropped.GetComponent<DragIUIIem>();
                     Draggableitem.parentAfterDrag = transform;
        }
        
    }
}
