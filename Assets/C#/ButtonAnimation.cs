using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = originalScale * 1.1f; // 마우스를 올리면 1.1배 확대
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = originalScale; // 원래 크기로 복귀
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.localScale = originalScale * 0.9f; // 누르면 0.9배 축소
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localScale = originalScale * 1.1f; // 떼면 다시 확대
    }
}
