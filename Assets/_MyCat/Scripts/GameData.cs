using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class GameData : MonoBehaviour
{
    public TextAsset _mission_daily_csv;
    public List<GameData_MissionDaily> _mission_daily_data;

    // 상점 아이템 데이터
    public TextAsset _shop_item_csv;
    public List<GameData_ShopItem> _shop_item_data;

    public SpriteRenderer _testSprite;

    void Start()
    {
        //Sprite sp =  Resources.Load<Sprite>("coin-794");
        Sprite[] spList = Resources.LoadAll<Sprite>("spritesheet_48x48");
        for (int i = 0; i < spList.Length; i++) // 배열의 갯수(Length)만큼 반목
        {
            Sprite sp = spList[i];
            if (sp.name == "gem_yellow")
            {
                _testSprite.sprite = sp;
                break;
            }
        }

        Init_MissionDailyData();
        Init_ShopItemData();
    }

    void Init_MissionDailyData()
    {
        //Debug.Log(_mission_daily_csv.text);
        _mission_daily_data = new List<GameData_MissionDaily>();

        string text = _mission_daily_csv.text;
        using (StringReader reader = new StringReader(text))
        {
            string line = reader.ReadLine(); //첫번째줄은 읽고 쓰지 않는다(컬럼 이름들이므로)
            if (line != null)
            {
                while ((line = reader.ReadLine()) != null)
                {
                    // csv 이므로, ',' seperator로 데이터들을 분리해서 저장

                    string[] record = line.Split(',');

                    Debug.Assert(record.Length == 6);

                    GameData_MissionDaily temp = new GameData_MissionDaily();
                    temp.id = Convert.ToInt32(record[0]);
                    temp.name = record[1];
                    temp.clearCount = Convert.ToInt32(record[2]);
                    temp.gem_reward = Convert.ToInt32(record[3]);
                    temp.reward_icon = record[4];
                    temp.desc = record[5];

                    Sprite[] spList = Resources.LoadAll<Sprite>("spritesheet_48x48");
                    for (int i = 0; i < spList.Length; i++) // 배열의 갯수(Length)만큼 반복
                    {
                        Sprite sp = spList[i];
                        if (sp.name == temp.reward_icon)
                        {
                            temp.reward_icon_sp = sp;
                            break;
                        }
                    }

                    //List에 하나를 집어넣을 때는 Add함수 쓴다.
                    _mission_daily_data.Add(temp);
                }
            }
        }
    }

    void Init_ShopItemData()
    {
        _shop_item_csv = Resources.Load<TextAsset>("GameData/shop_item");

        _shop_item_data = new List<GameData_ShopItem>();

        string text = _shop_item_csv.text;
        using (StringReader reader = new StringReader(text))
        {
            string line = reader.ReadLine(); // 첫번째줄은 읽고 쓰지 않는다(컬럼 이름들이므로)
            if (line != null)
            {
                while ((line = reader.ReadLine()) != null)
                {
                    // csv 값이므로, ',' seperator로 데이터들을 분리해서 저장
                    string[] record = line.Split(',');

                    Debug.Assert(record.Length == 4);

                    GameData_ShopItem temp = new GameData_ShopItem();
                    temp.id = Convert.ToInt32(record[0]);
                    temp.name = record[1];
                    temp.price = Convert.ToInt32(record[2]);
                    temp.sprite = record[3];

                    // List에 하나를 집어넣을 때는 Add 함수 쓴다
                    _shop_item_data.Add(temp);

                }
            }
        }
    }

    void Update()
    {
        
    }
}
