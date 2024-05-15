using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string tipText;
    private float WaitTime = 0.5f;
    public void OnPointerEnter(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(StartT());

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();
        HoverManager.OnMouseLoseFocus();
    }

    private void Show()
    {
        HoverManager.OnMouseHover(tipText, Input.mousePosition);
    }

    private IEnumerator StartT()
    {
        yield return new WaitForSeconds(WaitTime);
        Show();
    }
}
