using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector3 startPosition;
    private bool isDroppedOnSlot;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        startPosition = rectTransform.anchoredPosition; // Ba�lang�� pozisyonunu kaydet
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("dfg");
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
        isDroppedOnSlot = false; // Drag ba�lad���nda, slotta b�rak�lmad���n� varsay
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("dfg");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("dfg");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        if (!isDroppedOnSlot)
        {
            rectTransform.anchoredPosition = startPosition; // Eski pozisyona d�n
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("dfg");
    }

    // Slotta b�rak�ld���nda bu metod �a�r�lacak
    public void SetDroppedOnSlot(bool dropped)
    {
        isDroppedOnSlot = dropped;
    }
}

