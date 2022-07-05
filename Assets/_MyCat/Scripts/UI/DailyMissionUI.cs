using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyCat
{
    public class DailyMissionUI : MonoBehaviour
    {
        public GameData _gameData;

        public List<DailyMissionItem> _itemList;

        void Start()
        {
            DailyMissionItem[] array = GetComponentsInChildren<DailyMissionItem>();
            //List에 여러개(배열)를 집어넣을 때는 AddRange 함수 쓴다.
            _itemList.AddRange(array);


            List<GameData_MissionDaily> missionDataList = _gameData._mission_daily_data;

            for(int i = 0; i < _itemList.Count; i++)
            {
                GameData_MissionDaily data = missionDataList[i];
                DailyMissionItem item = _itemList[i];
                item.SetData(data);  // 일일미션데이터를 각 항목(item)에 넣어준다.
            }
        }

        void Update()
        {

        }
    }
}
