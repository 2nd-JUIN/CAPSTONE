using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    // UI �гε�
    public GameObject leaderBoardPanel;  // �������� �г�
    public GameObject settingsPanel;     // ���� �г�
    public GameObject appInfoPanel;      // �� ���� �г�
    public GameObject helpPanel;         // ���� �г�
    public GameObject resetToDefaultPanel; // �⺻�� ���� �г�
    public GameObject confirmationPanel; // �⺻�� ���� ���� �޽��� �г�
    public GameObject cleanlinessSurveyConfirmPanel; // ����� ���� Ȯ�� �г�
    public GameObject surveyOnePagePanel; // ���� 1������ �г�
    public GameObject surveyTwoPagePanel; // ���� 2������ �г�
    public GameObject signPanel; // ȸ������ �� �α��� �г�
    public TMP_InputField signInputID; // ȸ������ ID �׸�
    public TMP_InputField signInputPW; // ȸ������ PW �׸�
    public TMP_InputField signInputPWConfirm; // ȸ������ PW Ȯ�� �׸�
    public GameObject signSuccessPanel; // ȸ������ �Ϸ� �г�
    public TMP_Text registerErrorText; // Sign ���� �޽��� �ؽ�Ʈ
    public GameObject loginPanel; // �α��� �г�
    public TMP_InputField loginInputID; // �α��� ID �׸�
    public TMP_InputField loginInputPW; // �α��� PW �׸�
    public TMP_Text LoginErrorText; // Login ���� �޼��� �ؽ�Ʈ
    public GameObject loginSuccessPanel; // �α��� �Ϸ� �г�
    public GameObject signInButton;         // SignBTN (�α��� ��ư)
    public GameObject logoutButton;         // LogoutBTN (�α׾ƿ� ��ư)
    public GameObject logoutSuccessPanel;   // �α׾ƿ� ���� �г�





    // ȸ������/�α��� ��ư Ŭ�� �� ����
    public void OpenSignPanel()
    {
        loginPanel.SetActive(false); // �α��� �г� �ݱ�
        signPanel.SetActive(true); // �α���/ȸ������ �г� ����
    }

    // �α���/ȸ������ �ݱ� ��ư Ŭ�� �� ����
    public void CloseSignPanel()
    {
        signPanel.SetActive(false); // �α���/ȸ������ �г� �ݱ�

        signInputID.text = "";
        signInputPW.text = "";
        signInputPWConfirm.text = ""; // �ݱ� �� ���߿� �Է��� ������ �ʱ�ȭ
        registerErrorText.gameObject.SetActive(false); // ���� �޼��� ��Ȱ��ȭ
    }
    // ȸ������ ��ư Ŭ�� �� ����                                                                      << �� �κп��� ȸ�����Կ� ���� ������ DB�� �Ѿ�� ������ ���⼭ �ڵ��� �� >>
    public void OnRegisterButtonClicked()
    {
        string sgid = signInputID.text.Trim();
        string sgpw = signInputPW.text.Trim();
        string sgpwConfirm = signInputPWConfirm.text.Trim();

        // �Է°��� ����ְų� ��й�ȣ ����ġ�� ���
        if (string.IsNullOrEmpty(sgid) || string.IsNullOrEmpty(sgpw) || string.IsNullOrEmpty(sgpwConfirm) || sgpw != sgpwConfirm)
        {
            registerErrorText.gameObject.SetActive(true); // ���� �޼��� ǥ��
            return;
        }
        // ������ ���� ���
        registerErrorText.gameObject.SetActive(false); // ���� �޼��� ��Ȱ��ȭ
        signPanel.SetActive(false); // ���� ȸ������/�α��� �г� �ݱ�
        signInputID.text = "";
        signInputPW.text = "";
        signInputPWConfirm.text = ""; // �ݱ� �� ���߿� �Է��� ������ �ʱ�ȭ
        signSuccessPanel.SetActive(true); // ȸ������ �Ϸ� �г� ����

        // 2�� �� �ڵ� ����
        StartCoroutine(CloseSignSuccessAfterDelay());
    }
    private IEnumerator CloseSignSuccessAfterDelay()
    {
        yield return new WaitForSeconds(2f); // 2�� ������
        signSuccessPanel.SetActive(false);   // �г� �ݱ�
    }




    // �α��� ��ư Ŭ�� �� ����
    public void OnLoginButtonClicked()
    {
        signInputID.text = "";
        signInputPW.text = "";
        signInputPWConfirm.text = ""; // ȸ������ ���� ���߿� �Է��� ������ �ʱ�ȭ
        signPanel.SetActive(false);  // ���� ȸ������ �г� �ݱ�
        loginPanel.SetActive(true);  // �α��� �г� ����
    }

    // �α��� �г� �ݱ� ��ư Ŭ�� �� ����
    public void CloseLoginPanel()
    {
        loginInputID.text = ""; // ID �Է� �ʱ�ȭ
        loginInputPW.text = ""; // PW �Է� �ʱ�ȭ
        registerErrorText.gameObject.SetActive(false); // ȸ������ ���� �޼��� ��Ȱ��ȭ
        LoginErrorText.gameObject.SetActive(false); // �α��� ���� �޼��� ��Ȱ��ȭ
        loginPanel.SetActive(false); // �α��� �г� �ݱ�
    }

    // Ȯ�� ��ư Ŭ�� �� ����                                                << �α��� ������ ���� ->  DB ȸ�����Ե� ������ ���ؼ� ������ �α��� �Ϸ�, ���������� �����Ǵ� �������� >>
    public void OnLoginConfirmButtonClicked()
    {
        string lgnid = loginInputID.text.Trim();
        string lgnpw = loginInputPW.text.Trim();
        
        // ID�� PW�� ��������� ����                                                        << �� �� DB���� ȸ������ �����Ϳ� ���� ������ ���� �߰� >>
        if (string.IsNullOrEmpty(lgnid) || string.IsNullOrEmpty(lgnpw))
        {
            LoginErrorText.gameObject.SetActive(true); // ���� �޼��� ǥ��
            return;
        }
        // ������ ���� ���
        LoginErrorText.gameObject.SetActive(false); // ���� �޼��� ��Ȱ��ȭ
        loginInputID.text = ""; // ID �Է� �ʱ�ȭ
        loginInputPW.text = ""; // PW �Է� �ʱ�ȭ
        loginPanel.SetActive(false); // �α��� �г� �ݱ�
        loginSuccessPanel.SetActive(true); // �α��� ���� �г� ����

        // �α��� �����ϸ� �α׾ƿ� ��ư���� �ٲ�� ��
        signInButton.SetActive(false);  // �α��� ��ư �����
        logoutButton.SetActive(true);   // �α׾ƿ� ��ư ���̱�

        // 2�� �� �ڵ� ����
        StartCoroutine(CloseLoginSuccessAfterDelay());
    }
    private IEnumerator CloseLoginSuccessAfterDelay()
    {
        yield return new WaitForSeconds(2f); // 2�� ������
        loginSuccessPanel.SetActive(false);   // �г� �ݱ�
    }




    // �α׾ƿ� ��ư Ŭ�� �� ����
    public void OnLogoutButtonClicked()
    {
        logoutButton.SetActive(false);    // �α׾ƿ� ��ư �����
        signInButton.SetActive(true);      // �α��� ��ư �ٽ� ���̱�

        logoutSuccessPanel.SetActive(true); // �α׾ƿ� ���� �г� ����

        StartCoroutine(CloseLogoutSuccessAfterDelay());
    }
    private IEnumerator CloseLogoutSuccessAfterDelay()
    {
        yield return new WaitForSeconds(2f); // 2�� ���
        logoutSuccessPanel.SetActive(false); // �г� �ݱ�
    }






    // �������� ��ư Ŭ�� �� ����                                                                          << ���� ����� ���� �г� ������ �ٽ� �ؾ��ؼ� ���� ����������>>
    public void OpenLeaderBoard()
    {
        leaderBoardPanel.SetActive(true); // �������� �г� ����
    }
    // �������� �ݱ� ��ư Ŭ�� �� ����
    public void CloseLeaderBoard()
    {
        leaderBoardPanel.SetActive(false); // �������� �г� �ݱ�
    }






    // ���� ��ư Ŭ�� �� ����
    public void OpenSettings()
    {
        settingsPanel.SetActive(true); // ���� �г� ����
        // �߰��� ���� ��, ���ʿ��� �ٸ� �гε��� ����
        helpPanel.SetActive(false);
        resetToDefaultPanel.SetActive(false);
        appInfoPanel.SetActive(false);
    }
    // ���� �ݱ� ��ư Ŭ�� �� ����
    public void CloseSettings()
    {
        settingsPanel.SetActive(false); // ���� �г� �ݱ�
    }






    // �� ���� ��ư Ŭ�� �� ����
    public void OpenAppInfo()
    {
        appInfoPanel.SetActive(true); // �� ���� �г� ����
        settingsPanel.SetActive(true); // ���� �г� ����
    }
    // �� ���� �ݱ� ��ư Ŭ�� �� ����
    public void CloseAppInfo()
    {
        appInfoPanel.SetActive(false); // �� ���� �г� �ݱ�
    }






    // ���� ��ư Ŭ�� �� ����
    public void OpenHelp()
    {
        helpPanel.SetActive(true); // ���� �г� ����
        settingsPanel.SetActive(true); // ���� �г� ����
    }
    // ���� �ݱ� ��ư Ŭ�� �� ����
    public void CloseHelp()
    {
        helpPanel.SetActive(false); // ���� �г� �ݱ�
    }






    // �⺻�� ��ư Ŭ�� �� ����
    public void OpenResetToDefault()
    {
        resetToDefaultPanel.SetActive(true); // �⺻�� ���� �г� ����
        settingsPanel.SetActive(true); // ���� �г� ����
    }
    // �⺻�� "�ƴϿ�" ��ư Ŭ�� �� ����
    public void CloseResetToDefault()
    {
        resetToDefaultPanel.SetActive(false); // �⺻�� ���� �г� �ݱ�
    }
    // �⺻�� "��" ��ư Ŭ�� �� ���� (Ȯ�� �޽��� ǥ�� �� 2�� �� ����)
    public void ConfirmResetToDefault()
    {
        resetToDefaultPanel.SetActive(false); // �⺻�� ���� �г� �ݱ�
        confirmationPanel.SetActive(true); // Ȯ�� �޽��� �г� ����
        StartCoroutine(CloseConfirmationAfterDelay()); // 2�� �� �ڵ����� �ݱ�
        ResetCleanlinessSurveyData(); // ����� ���� ���� ������ �ʱ�ȭ
    }


    // ����� ���� ������ �ʱ�ȭ �Լ�
    private void ResetCleanlinessSurveyData()
    {
        // ���� �迭 �ʱ�ȭ (��� ���׿� ���� '�ƴϿ�' ������ �⺻������ ����)
        for (int i = 0; i < answers.Length; i++)
        {
            answers[i] = false;  // �⺻��(false)�� �ʱ�ȭ
        }

        // ��ư ���� �ʱ�ȭ
        for (int i = 0; i < yesButtons.Length; i++)
        {
            yesButtons[i].image.color = defaultColor; // �� ��ư ���� �⺻������ ����
            noButtons[i].image.color = defaultColor;  // �ƴϿ� ��ư ���� �⺻������ ����
        }

        // ���� ������ �ݱ�
        CloseSurveyPage();

        Debug.Log("����� ���� ������ �ʱ�ȭ.");
    }

    // 2�� �� Ȯ�� �޽��� �г� �ݱ�
    private IEnumerator CloseConfirmationAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        confirmationPanel.SetActive(false);
    }






    // ����� ���� ��ư Ŭ�� �� ���� (Ȯ�� �г� ����)
    public void OpenCleanlinessSurveyConfirm()
    {
        cleanlinessSurveyConfirmPanel.SetActive(true); // ����� ���� Ȯ�� �г� ����
        settingsPanel.SetActive(true); // ���� �г� ����
    }

    // ����� ���� Ȯ�� �г� �ݱ�
    public void CloseCleanlinessSurveyConfirm()
    {
        cleanlinessSurveyConfirmPanel.SetActive(false); // ����� ���� Ȯ�� �г� �ݱ�
    }

    // "��" ��ư Ŭ�� �� ���� ����
    public void StartCleanlinessSurvey()
    {
        cleanlinessSurveyConfirmPanel.SetActive(false); // Ȯ�� �г� �ݱ�
        surveyOnePagePanel.SetActive(true); // ù ��° ���� ������ ����
    }

    // ���� ������ �ݱ�
    public void CloseSurveyPage()
    {
        surveyOnePagePanel.SetActive(false); // ���� 1������ �ݱ�
        surveyTwoPagePanel.SetActive(false); // ���� 2������ �ݱ�
    }

    // ���� ���� �� �г� �ݱ� �Լ�
    public void OnCloseButtonClicked()
    {
        // ���� �迭 �ʱ�ȭ (��� ���׿� ���� '�ƴϿ�' ������ �⺻������ ����)
        for (int i = 0; i < answers.Length; i++)
        {
            answers[i] = false; // �⺻��(false)�� �ʱ�ȭ
        }

        // ��ư ���� �ʱ�ȭ
        for (int i = 0; i < yesButtons.Length; i++)
        {
            yesButtons[i].image.color = defaultColor;
            noButtons[i].image.color = defaultColor;
        }

        // UI ���� ����
        Canvas.ForceUpdateCanvases();

        // �г� �ݱ�
        CloseSurveyPage();

        Debug.Log("�ݱ� ��ư�� ���� ���� ���� �� �г� ����");
    }

    // '����' ��ư Ŭ�� �� ���� 2�������� �̵�
    public void GoToSurveyTwoPage()
    {
        surveyOnePagePanel.SetActive(false); // ���� 1������ �ݱ�
        surveyTwoPagePanel.SetActive(true); // ���� 2������ ����
    }

    // '�ڷ�' ��ư Ŭ�� �� ���� 1�������� ���ư���
    public void GoBackToSurveyOnePage()
    {
        surveyTwoPagePanel.SetActive(false); // ���� 2������ �ݱ�
        surveyOnePagePanel.SetActive(true); // ���� 1������ ����
    }

    // ���� ���� �� '�����ϱ�' ��ư Ŭ�� �� ó��                                                       << ����� ���� ������ DB�� �����ϱ� ���� �ڵ��� ������ >>
    public void ApplySurveyResults()
    {
        surveyOnePagePanel.SetActive(false); // ���� 1������ �ݱ�
        surveyTwoPagePanel.SetActive(false); // ���� 2������ �ݱ�
        confirmationPanel.SetActive(true); // Ȯ�� �޽��� �г� ����
        StartCoroutine(CloseConfirmationAfterDelay()); // 2�� �� �ݱ�
    }

    // ���� ������ ������ �迭
    private bool[] answers = new bool[9]; // 9���� ���׿� ���� ����

    // �� ���׿� ���� ��ư���� ���� (����Ƽ �����Ϳ��� �����ؾ� ��)
    public Button[] yesButtons;  // �� ��ư��
    public Button[] noButtons;   // �ƴϿ� ��ư��

    public Color selectedColor = Color.green;  // ���õ� ��ư ����
    public Color defaultColor = Color.white;   // �⺻ ��ư ����

    // �� ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    public void OnYesButtonClicked(int index)
    {
        answers[index] = true;  // �ش� ���׿� '��' ���� ���

        // �ð��� ȿ�� (�� ��ư ���� ����)
        yesButtons[index].image.color = selectedColor;

        // �ƴϿ� ��ư ���� ����
        noButtons[index].image.color = defaultColor;

        Debug.Log("Yes ��ư�� Ŭ���Ǿ����ϴ�. ���� ��ȣ: " + (index + 1));
    }

    // �ƴϿ� ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    public void OnNoButtonClicked(int index)
    {
        answers[index] = false; // �ش� ���׿� '�ƴϿ�' ���� ���

        // �ð��� ȿ�� (�ƴϿ� ��ư ���� ����)
        noButtons[index].image.color = selectedColor;

        // �� ��ư ���� ����
        yesButtons[index].image.color = defaultColor;

        Debug.Log("No ��ư�� Ŭ���Ǿ����ϴ�. ���� ��ȣ: " + (index + 1));
    }

    // Start���� ��ư Ŭ�� �̺�Ʈ ���� (����Ƽ �����Ϳ��� �����ϴ� ������� ��ü ����)
    private void Start()
    {
        // �ݺ��Ǵ� ��ư ������ �� �� �����ϰ� ���� �� �ֽ��ϴ�.
        // �� ��ư��, �ƴϿ� ��ư�鿡 ���� �ڵ����� �̺�Ʈ�� ����ϴ� ����� ����� �� �ֽ��ϴ�.

        for (int i = 0; i < yesButtons.Length; i++)
        {
            int index = i; // Ŭ���� ���� ����
            yesButtons[i].onClick.AddListener(() => OnYesButtonClicked(index));
            noButtons[i].onClick.AddListener(() => OnNoButtonClicked(index));
        }
    }
}
