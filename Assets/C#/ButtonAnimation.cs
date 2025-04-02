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
        transform.localScale = originalScale * 1.1f; // ���콺�� �ø��� 1.1�� Ȯ��
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = originalScale; // ���� ũ��� ����
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.localScale = originalScale * 0.9f; // ������ 0.9�� ���
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localScale = originalScale * 1.1f; // ���� �ٽ� Ȯ��
    }
}
