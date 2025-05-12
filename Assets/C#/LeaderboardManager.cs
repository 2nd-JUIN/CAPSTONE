using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class LeaderboardManager : MonoBehaviour
{
    [Header("리더보드 프리팹 및 콘텐츠 부모")]
    public GameObject rankItemPrefab;              // RankItem 프리팹
    public Transform contentParent;                // ScrollView 안의 Content

    [Header("유저 리스트 (더미 데이터 or DB 연동)")]
    public List<UserData> userList = new List<UserData>();

    [System.Serializable]
    public class UserData
    {
        public string userName;
        public int points;
    }

    void Start()
    {
        // ✅ 더미 데이터 (추후 DB 연동 시 교체)
        userList.Add(new UserData { userName = "skywalker88", points = 999 });
        userList.Add(new UserData { userName = "mint_cocoa", points = 850 });
        userList.Add(new UserData { userName = "lw_jun02", points = 830 });
        userList.Add(new UserData { userName = "velvetFox", points = 790 });
        userList.Add(new UserData { userName = "sunny_day12", points = 770 });
        userList.Add(new UserData { userName = "neonpulse", points = 740 });
        userList.Add(new UserData { userName = "jooniverse", points = 710 });
        userList.Add(new UserData { userName = "mapleberry", points = 660 });
        userList.Add(new UserData { userName = "zeroNineX", points = 620 });
        userList.Add(new UserData { userName = "peachytea", points = 580 });

        CreateLeaderboard();
    }

    // ✅ 등수 텍스트 생성 함수 (1st, 2nd, 3rd, 나머지는 th)
    string GetRankString(int rank)
    {
        if (rank == 1) return "1st";
        if (rank == 2) return "2nd";
        if (rank == 3) return "3rd";
        return $"{rank}th";
    }

    // ✅ 리더보드 항목 생성 함수
    public void CreateLeaderboard()
    {
        for (int i = 0; i < userList.Count; i++)
        {
            GameObject item = Instantiate(rankItemPrefab, contentParent);

            TMP_Text rankText = item.transform.Find("RankText").GetComponent<TMP_Text>();
            TMP_Text nameText = item.transform.Find("NameText").GetComponent<TMP_Text>();
            TMP_Text pointText = item.transform.Find("PointText").GetComponent<TMP_Text>();

            int rank = i + 1;
            rankText.text = GetRankString(rank);
            nameText.text = userList[i].userName;
            pointText.text = $"{userList[i].points} POINT";
        }
    }
}
