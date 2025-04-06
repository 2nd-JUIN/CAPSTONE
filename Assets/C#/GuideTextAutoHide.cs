using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScanCanvasGuideTextController : MonoBehaviour
{
    public GameObject guideTextObj;
    public float displayDuration = 5f;

    private Coroutine hideCoroutine;

    void OnEnable()
    {
        ShowGuideText();
    }

    void OnDisable()
    {
        if (hideCoroutine != null)
        {
            StopCoroutine(hideCoroutine);
        }

        guideTextObj.SetActive(false); // √ ±‚»≠
    }

    public void ShowGuideText()
    {
        guideTextObj.SetActive(true);

        if (hideCoroutine != null)
        {
            StopCoroutine(hideCoroutine);
        }

        hideCoroutine = StartCoroutine(HideAfterSeconds(displayDuration));
    }

    private IEnumerator HideAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        guideTextObj.SetActive(false);
    }
}
