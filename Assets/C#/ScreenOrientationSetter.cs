using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenOrientationSetter : MonoBehaviour
{
    // Start 함수는 게임이 시작될 때 호출됩니다.
    void Start()
    {
        // 화면 방향을 가로 모드로 설정합니다.
        Screen.orientation = ScreenOrientation.LandscapeLeft;  // LandscapeRight로 바꿔도 됩니다.
    }

    // Update 함수는 매 프레임마다 호출됩니다.
    void Update()
    {
        // 화면이 가로 모드로 설정되지 않으면 강제로 가로 모드로 설정합니다.
        if (Screen.orientation != ScreenOrientation.LandscapeLeft)
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }
    }
}
