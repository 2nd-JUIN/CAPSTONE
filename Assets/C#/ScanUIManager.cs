using UnityEngine;

public class ScanUIManager : MonoBehaviour
{
    public GameObject canvasMainUI;
    public GameObject canvasScanUI;

    public void OnScanStartButtonClicked()
    {
        canvasMainUI.SetActive(false); // ���� UI �����
        canvasScanUI.SetActive(true);  // ��ĵ UI ���̱�
    }

    //  �ڷΰ��� ��ư ��� �߰�
    public void OnBackButtonClicked()
    {
        canvasScanUI.SetActive(false); // ��ĵ UI �����
        canvasMainUI.SetActive(true);  // ���� UI �ٽ� ���̱�
    }
}
