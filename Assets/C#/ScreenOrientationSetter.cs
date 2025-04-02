using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenOrientationSetter : MonoBehaviour
{
    // Start �Լ��� ������ ���۵� �� ȣ��˴ϴ�.
    void Start()
    {
        // ȭ�� ������ ���� ���� �����մϴ�.
        Screen.orientation = ScreenOrientation.LandscapeLeft;  // LandscapeRight�� �ٲ㵵 �˴ϴ�.
    }

    // Update �Լ��� �� �����Ӹ��� ȣ��˴ϴ�.
    void Update()
    {
        // ȭ���� ���� ���� �������� ������ ������ ���� ���� �����մϴ�.
        if (Screen.orientation != ScreenOrientation.LandscapeLeft)
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }
    }
}
