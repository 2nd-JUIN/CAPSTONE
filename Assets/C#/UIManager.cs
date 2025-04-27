using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

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
    public GameObject signPanel; // 회원가입 및 로그인 패널
    public TMP_InputField signInputID; // 회원가입 ID 항목
    public TMP_InputField signInputPW; // 회원가입 PW 항목
    public TMP_InputField signInputPWConfirm; // 회원가입 PW 확인 항목
    public GameObject signSuccessPanel; // 회원가입 완료 패널
    public TMP_Text registerErrorText; // Sign 에러 메시지 텍스트
    public GameObject loginPanel; // 로그인 패널
    public TMP_InputField loginInputID; // 로그인 ID 항목
    public TMP_InputField loginInputPW; // 로그인 PW 항목
    public TMP_Text LoginErrorText; // Login 에러 메세지 텍스트
    public GameObject loginSuccessPanel; // 로그인 완료 패널
    public GameObject signInButton;         // SignBTN (로그인 버튼)
    public GameObject logoutButton;         // LogoutBTN (로그아웃 버튼)
    public GameObject logoutSuccessPanel;   // 로그아웃 성공 패널





    // 회원가입/로그인 버튼 클릭 시 실행
    public void OpenSignPanel()
    {
        loginPanel.SetActive(false); // 로그인 패널 닫기
        signPanel.SetActive(true); // 로그인/회원가입 패널 열기
    }

    // 로그인/회원가입 닫기 버튼 클릭 시 실행
    public void CloseSignPanel()
    {
        signPanel.SetActive(false); // 로그인/회원가입 패널 닫기

        signInputID.text = "";
        signInputPW.text = "";
        signInputPWConfirm.text = ""; // 닫기 시 도중에 입력한 데이터 초기화
        registerErrorText.gameObject.SetActive(false); // 에러 메세지 비활성화
    }
    // 회원가입 버튼 클릭 시 실행                                                                      << 이 부분에서 회원가입에 대한 정보가 DB로 넘어가는 과정을 여기서 코딩할 듯 >>
    public void OnRegisterButtonClicked()
    {
        string sgid = signInputID.text.Trim();
        string sgpw = signInputPW.text.Trim();
        string sgpwConfirm = signInputPWConfirm.text.Trim();

        // 입력값이 비어있거나 비밀번호 불일치할 경우
        if (string.IsNullOrEmpty(sgid) || string.IsNullOrEmpty(sgpw) || string.IsNullOrEmpty(sgpwConfirm) || sgpw != sgpwConfirm)
        {
            registerErrorText.gameObject.SetActive(true); // 에러 메세지 표시
            return;
        }
        // 에러가 없을 경우
        registerErrorText.gameObject.SetActive(false); // 에러 메세지 비활성화
        signPanel.SetActive(false); // 기존 회원가입/로그인 패널 닫기
        signInputID.text = "";
        signInputPW.text = "";
        signInputPWConfirm.text = ""; // 닫기 시 도중에 입력한 데이터 초기화
        signSuccessPanel.SetActive(true); // 회원가입 완료 패널 열기

        // 2초 후 자동 닫힘
        StartCoroutine(CloseSignSuccessAfterDelay());
    }
    private IEnumerator CloseSignSuccessAfterDelay()
    {
        yield return new WaitForSeconds(2f); // 2초 딜레이
        signSuccessPanel.SetActive(false);   // 패널 닫기
    }




    // 로그인 버튼 클릭 시 실행
    public void OnLoginButtonClicked()
    {
        signInputID.text = "";
        signInputPW.text = "";
        signInputPWConfirm.text = ""; // 회원가입 정보 도중에 입력한 데이터 초기화
        signPanel.SetActive(false);  // 기존 회원가입 패널 닫기
        loginPanel.SetActive(true);  // 로그인 패널 열기
    }

    // 로그인 패널 닫기 버튼 클릭 시 실행
    public void CloseLoginPanel()
    {
        loginInputID.text = ""; // ID 입력 초기화
        loginInputPW.text = ""; // PW 입력 초기화
        registerErrorText.gameObject.SetActive(false); // 회원가입 에러 메세지 비활성화
        LoginErrorText.gameObject.SetActive(false); // 로그인 에러 메세지 비활성화
        loginPanel.SetActive(false); // 로그인 패널 닫기
    }

    // 확인 버튼 클릭 시 실행                                                << 로그인 데이터 전송 ->  DB 회원가입된 데이터 비교해서 맞으면 로그인 완료, 맞지않으면 에러되는 과정으로 >>
    public void OnLoginConfirmButtonClicked()
    {
        string lgnid = loginInputID.text.Trim();
        string lgnpw = loginInputPW.text.Trim();
        
        // ID나 PW가 비어있으면 에러                                                        << 차 후 DB에서 회원가입 데이터와 맞지 않을때 에러 추가 >>
        if (string.IsNullOrEmpty(lgnid) || string.IsNullOrEmpty(lgnpw))
        {
            LoginErrorText.gameObject.SetActive(true); // 에러 메세지 표시
            return;
        }
        // 에러가 없을 경우
        LoginErrorText.gameObject.SetActive(false); // 에러 메세지 비활성화
        loginInputID.text = ""; // ID 입력 초기화
        loginInputPW.text = ""; // PW 입력 초기화
        loginPanel.SetActive(false); // 로그인 패널 닫기
        loginSuccessPanel.SetActive(true); // 로그인 성공 패널 열기

        // 로그인 성공하면 로그아웃 버튼으로 바뀌게 함
        signInButton.SetActive(false);  // 로그인 버튼 숨기기
        logoutButton.SetActive(true);   // 로그아웃 버튼 보이기

        // 2초 후 자동 닫힘
        StartCoroutine(CloseLoginSuccessAfterDelay());
    }
    private IEnumerator CloseLoginSuccessAfterDelay()
    {
        yield return new WaitForSeconds(2f); // 2초 딜레이
        loginSuccessPanel.SetActive(false);   // 패널 닫기
    }




    // 로그아웃 버튼 클릭 시 실행
    public void OnLogoutButtonClicked()
    {
        logoutButton.SetActive(false);    // 로그아웃 버튼 숨기기
        signInButton.SetActive(true);      // 로그인 버튼 다시 보이기

        logoutSuccessPanel.SetActive(true); // 로그아웃 성공 패널 띄우기

        StartCoroutine(CloseLogoutSuccessAfterDelay());
    }
    private IEnumerator CloseLogoutSuccessAfterDelay()
    {
        yield return new WaitForSeconds(2f); // 2초 대기
        logoutSuccessPanel.SetActive(false); // 패널 닫기
    }






    // 리더보드 버튼 클릭 시 실행                                                                          << 우진 여기는 내가 패널 디자인 다시 해야해서 아직 하지말아줘>>
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

    // 설문 종료 후 '적용하기' 버튼 클릭 시 처리                                                       << 깔끔도 측정 데이터 DB로 전송하기 위한 코딩은 여기쯤 >>
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
