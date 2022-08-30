using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyTower
{
    public class FloorManager : MonoBehaviour
    {
        public static FloorManager I;

        public List<GameObject> _floorList;

        void Awake()
        {
            I = this;
        }
        public void Init()
        {

        }

        public void Create(GameObject template, Vector3 blockPos)
        {
            GameObject obj = Instantiate(template);
            obj.SetActive(true);
            obj.name = template.name;

            // 1. 현재 층 알아오기
            //int floor = (int)(transform.position.y / HEIGHT) + 1;

            //생성된 매장 오브젝트가 이 현재 층이 되도록 위치 설정
            // y위치 = (n층 - 1) * 층 높이(5m)
            //float yPos = (floor - 1) * HEIGHT;

            //Vector3 pos = obj.transform.position;
            //obj.transform.position = new Vector3(pos.x, yPos, pos.z);
            // 받아온 블록의 위치를 새로 생성된 매장에게 넘겨주고
            obj.transform.position = blockPos;
            obj.transform.parent = transform; // 플로어 매니저의 자식개체로 이동
            _floorList.Add(obj);

            //유저데이터로 저장
            UserData.I.SaveFloor(obj.name);
        }
    }
}