using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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






    // �������� ��ư Ŭ�� �� ����
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

    // ���� ���� �� '�����ϱ�' ��ư Ŭ�� �� ó��
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
