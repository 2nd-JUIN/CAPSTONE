using UnityEngine;

public class ScanUIManager : MonoBehaviour
{
    public GameObject canvasMainUI;
    public GameObject canvasScanUI;

    public void OnScanStartButtonClicked()
    {
        canvasMainUI.SetActive(false); // 메인 UI 숨기기
        canvasScanUI.SetActive(true);  // 스캔 UI 보이기
    }

    //  뒤로가기 버튼 기능 추가
    public void OnBackButtonClicked()
    {
        canvasScanUI.SetActive(false); // 스캔 UI 숨기기
        canvasMainUI.SetActive(true);  // 메인 UI 다시 보이기
    }
}
