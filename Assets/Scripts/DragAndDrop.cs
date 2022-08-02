using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public int cost = 100;
    private float dampingSpeed = 0f;
    Vector3 velocity = Vector3.zero;
    private RectTransform draggingObjectRectTransform;
    public Vector3 initialRectPosition;
    public GameObject tower;
    public LayerMask noClickMask;

    private void Awake()
    {
        draggingObjectRectTransform = transform as RectTransform;
        initialRectPosition = draggingObjectRectTransform.position;
    }

    public void OnDrag(PointerEventData eventData)            //allows us to drag the UI
    {
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(draggingObjectRectTransform, eventData.position, eventData.pressEventCamera, out var globalMousePosition))
        {
            draggingObjectRectTransform.position = Vector3.SmoothDamp(draggingObjectRectTransform.position, globalMousePosition, ref velocity, dampingSpeed);
        }
    }

    public void OnEndDrag(PointerEventData eventData)        //creates the desired tower where the mouse is 
    {
        GameManager gm = FindObjectOfType<GameManager>();
        bool canBuy = gm.gold >= cost;
        Vector3 pos = Camera.main.ScreenToWorldPoint(eventData.position);
        Collider2D clickCollider = Physics2D.OverlapPoint(pos, noClickMask);
        if (canBuy == true && clickCollider == null)        //if we have enough money AND we failed to find a collider in our no click zone            
        {
            pos.z = 0;
            Instantiate(tower, pos, tower.transform.rotation);
            gm.gold = gm.gold - cost; 
            draggingObjectRectTransform.position = initialRectPosition;
        }
        else
        {
            draggingObjectRectTransform.position = initialRectPosition;
            Debug.Log("Invalid end drag position!");
        }
    }
}