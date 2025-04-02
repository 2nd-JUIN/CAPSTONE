using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // UI 패널들
    public GameObject leaderBoardPanel;  // 리더보드 패널
    public GameObject settingsPanel;     // 설정 패널
    public GameObject appInfoPanel;      // 앱 정보 패널
    public GameObject helpPanel;         // 도움말 패널
    public GameObject resetToDefaultPanel; // 기본값 설정 패널
    public GameObject confirmationPanel; // 기본값 설정 적용 메시지 패널
    public GameObject cleanlinessSurveyConfirmPanel; // 깔끔도 측정 확인 패널
    public GameObject surveyOnePagePanel; // 설문 1페이지 패널
    public GameObject surveyTwoPagePanel; // 설문 2페이지 패널






    // 리더보드 버튼 클릭 시 실행
    public void OpenLeaderBoard()
    {
        leaderBoardPanel.SetActive(true); // 리더보드 패널 열기
    }
    // 리더보드 닫기 버튼 클릭 시 실행
    public void CloseLeaderBoard()
    {
        leaderBoardPanel.SetActive(false); // 리더보드 패널 닫기
    }






    // 설정 버튼 클릭 시 실행
    public void OpenSettings()
    {
        settingsPanel.SetActive(true); // 설정 패널 열기
        // 추가된 설정 후, 불필요한 다른 패널들은 닫음
        helpPanel.SetActive(false);
        resetToDefaultPanel.SetActive(false);
        appInfoPanel.SetActive(false);
    }
    // 설정 닫기 버튼 클릭 시 실행
    public void CloseSettings()
    {
        settingsPanel.SetActive(false); // 설정 패널 닫기
    }






    // 앱 정보 버튼 클릭 시 실행
    public void OpenAppInfo()
    {
        appInfoPanel.SetActive(true); // 앱 정보 패널 열기
        settingsPanel.SetActive(true); // 설정 패널 유지
    }
    // 앱 정보 닫기 버튼 클릭 시 실행
    public void CloseAppInfo()
    {
        appInfoPanel.SetActive(false); // 앱 정보 패널 닫기
    }






    // 도움말 버튼 클릭 시 실행
    public void OpenHelp()
    {
        helpPanel.SetActive(true); // 도움말 패널 열기
        settingsPanel.SetActive(true); // 설정 패널 유지
    }
    // 도움말 닫기 버튼 클릭 시 실행
    public void CloseHelp()
    {
        helpPanel.SetActive(false); // 도움말 패널 닫기
    }






    // 기본값 버튼 클릭 시 실행
    public void OpenResetToDefault()
    {
        resetToDefaultPanel.SetActive(true); // 기본값 설정 패널 열기
        settingsPanel.SetActive(true); // 설정 패널 유지
    }
    // 기본값 "아니오" 버튼 클릭 시 실행
    public void CloseResetToDefault()
    {
        resetToDefaultPanel.SetActive(false); // 기본값 설정 패널 닫기
    }
    // 기본값 "예" 버튼 클릭 시 실행 (확인 메시지 표시 후 2초 뒤 닫힘)
    public void ConfirmResetToDefault()
    {
        resetToDefaultPanel.SetActive(false); // 기본값 설정 패널 닫기
        confirmationPanel.SetActive(true); // 확인 메시지 패널 열기
        StartCoroutine(CloseConfirmationAfterDelay()); // 2초 후 자동으로 닫기
        ResetCleanlinessSurveyData(); // 깔끔도 설문 응답 데이터 초기화
    }


    // 깔끔도 설문 데이터 초기화 함수
    private void ResetCleanlinessSurveyData()
    {
        // 응답 배열 초기화 (모든 문항에 대해 '아니오' 응답을 기본값으로 설정)
        for (int i = 0; i < answers.Length; i++)
        {
            answers[i] = false;  // 기본값(false)로 초기화
        }

        // 버튼 색상 초기화
        for (int i = 0; i < yesButtons.Length; i++)
        {
            yesButtons[i].image.color = defaultColor; // 예 버튼 색상 기본값으로 설정
            noButtons[i].image.color = defaultColor;  // 아니오 버튼 색상 기본값으로 설정
        }

        // 설문 페이지 닫기
        CloseSurveyPage();

        Debug.Log("깔끔도 측정 데이터 초기화.");
    }

    // 2초 뒤 확인 메시지 패널 닫기
    private IEnumerator CloseConfirmationAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        confirmationPanel.SetActive(false);
    }






    // 깔끔도 측정 버튼 클릭 시 실행 (확인 패널 열기)
    public void OpenCleanlinessSurveyConfirm()
    {
        cleanlinessSurveyConfirmPanel.SetActive(true); // 깔끔도 측정 확인 패널 열기
        settingsPanel.SetActive(true); // 설정 패널 유지
    }

    // 깔끔도 측정 확인 패널 닫기
    public void CloseCleanlinessSurveyConfirm()
    {
        cleanlinessSurveyConfirmPanel.SetActive(false); // 깔끔도 측정 확인 패널 닫기
    }

    // "예" 버튼 클릭 시 설문 시작
    public void StartCleanlinessSurvey()
    {
        cleanlinessSurveyConfirmPanel.SetActive(false); // 확인 패널 닫기
        surveyOnePagePanel.SetActive(true); // 첫 번째 설문 페이지 열기
    }

    // 설문 페이지 닫기
    public void CloseSurveyPage()
    {
        surveyOnePagePanel.SetActive(false); // 설문 1페이지 닫기
        surveyTwoPagePanel.SetActive(false); // 설문 2페이지 닫기
    }

    // 설문 리셋 및 패널 닫기 함수
    public void OnCloseButtonClicked()
    {
        // 응답 배열 초기화 (모든 문항에 대해 '아니오' 응답을 기본값으로 설정)
        for (int i = 0; i < answers.Length; i++)
        {
            answers[i] = false; // 기본값(false)로 초기화
        }

        // 버튼 색상 초기화
        for (int i = 0; i < yesButtons.Length; i++)
        {
            yesButtons[i].image.color = defaultColor;
            noButtons[i].image.color = defaultColor;
        }

        // UI 강제 갱신
        Canvas.ForceUpdateCanvases();

        // 패널 닫기
        CloseSurveyPage();

        Debug.Log("닫기 버튼을 통한 설문 리셋 및 패널 닫힘");
    }

    // '다음' 버튼 클릭 시 설문 2페이지로 이동
    public void GoToSurveyTwoPage()
    {
        surveyOnePagePanel.SetActive(false); // 설문 1페이지 닫기
        surveyTwoPagePanel.SetActive(true); // 설문 2페이지 열기
    }

    // '뒤로' 버튼 클릭 시 설문 1페이지로 돌아가기
    public void GoBackToSurveyOnePage()
    {
        surveyTwoPagePanel.SetActive(false); // 설문 2페이지 닫기
        surveyOnePagePanel.SetActive(true); // 설문 1페이지 열기
    }

    // 설문 종료 후 '적용하기' 버튼 클릭 시 처리
    public void ApplySurveyResults()
    {
        surveyOnePagePanel.SetActive(false); // 설문 1페이지 닫기
        surveyTwoPagePanel.SetActive(false); // 설문 2페이지 닫기
        confirmationPanel.SetActive(true); // 확인 메시지 패널 열기
        StartCoroutine(CloseConfirmationAfterDelay()); // 2초 뒤 닫기
    }

    // 문항 응답을 저장할 배열
    private bool[] answers = new bool[9]; // 9개의 문항에 대한 응답

    // 각 문항에 대한 버튼들을 연결 (유니티 에디터에서 연결해야 함)
    public Button[] yesButtons;  // 예 버튼들
    public Button[] noButtons;   // 아니오 버튼들

    public Color selectedColor = Color.green;  // 선택된 버튼 색상
    public Color defaultColor = Color.white;   // 기본 버튼 색상

    // 예 버튼 클릭 시 호출되는 함수
    public void OnYesButtonClicked(int index)
    {
        answers[index] = true;  // 해당 문항에 '예' 응답 기록

        // 시각적 효과 (예 버튼 색상 변경)
        yesButtons[index].image.color = selectedColor;

        // 아니오 버튼 색상 리셋
        noButtons[index].image.color = defaultColor;

        Debug.Log("Yes 버튼이 클릭되었습니다. 문항 번호: " + (index + 1));
    }

    // 아니오 버튼 클릭 시 호출되는 함수
    public void OnNoButtonClicked(int index)
    {
        answers[index] = false; // 해당 문항에 '아니오' 응답 기록

        // 시각적 효과 (아니오 버튼 색상 변경)
        noButtons[index].image.color = selectedColor;

        // 예 버튼 색상 리셋
        yesButtons[index].image.color = defaultColor;

        Debug.Log("No 버튼이 클릭되었습니다. 문항 번호: " + (index + 1));
    }

    // Start에서 버튼 클릭 이벤트 연결 (유니티 에디터에서 연결하는 방식으로 대체 가능)
    private void Start()
    {
        // 반복되는 버튼 연결을 좀 더 간결하게 만들 수 있습니다.
        // 예 버튼들, 아니오 버튼들에 대해 자동으로 이벤트를 등록하는 방법을 사용할 수 있습니다.

        for (int i = 0; i < yesButtons.Length; i++)
        {
            int index = i; // 클로저 문제 방지
            yesButtons[i].onClick.AddListener(() => OnYesButtonClicked(index));
            noButtons[i].onClick.AddListener(() => OnNoButtonClicked(index));
        }
    }
}
