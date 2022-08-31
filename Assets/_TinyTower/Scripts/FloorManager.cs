using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyTower
{
    public class FloorManager : MonoBehaviour
    {
        public static FloorManager I;

        public List<GameObject> _floorList;

        [SerializeField] GameObject[] _templates; //매장 템플릿 배열

        void Awake()
        {
            I = this;
        }
        public void Init()
        {
            //플로어 로딩
            string floorList = UserData.I.FloorList;

            GameObject blockObj = transform.Find("block").gameObject;
            Block block = blockObj.GetComponent<Block>();

            if (string.IsNullOrEmpty(floorList) == false) //빈 문장열이 아닐 경우
            {
                // 스플릿(split) 함수를 써서, 콤마로 구분된 floor 정보를 가져오기
                string[] floorArray = floorList.Split(", ");
                foreach(string floorName in floorArray)
                {
                    foreach(GameObject t in _templates)
                    {
                        if(t.name == floorName)
                        {
                            _Create(t, blockObj.transform.position);
                            block.Raise(); // 플로어 생성 후, 블락 올려주기

                            break;
                        }
                    }
                }
            }
        }

        public void Create(Vector3 blockPos) //랜덤으로 생성
        {
            int choice = Random.Range(0, _templates.Length);

            GameObject template = _templates[choice];

            _Create(template, blockPos);

            //유저데이터로 저장
            UserData.I.SaveFloor(template.name);
        }

        void _Create(GameObject template, Vector3 blockPos) //지정해서 생성
        {
            GameObject obj = Instantiate(template);
            obj.SetActive(true);
            obj.name = template.name;

            // 받아온 블록의 위치를 새로 생성된 매장에게 넘겨주고
            obj.transform.position = blockPos;
            obj.transform.parent = transform; // 플로어 매니저의 자식개체로 이동
            _floorList.Add(obj);
        }
    }
}