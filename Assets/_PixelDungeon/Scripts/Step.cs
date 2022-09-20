using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelDungeon
{
public class Step : MonoBehaviour
    {

        public GameObject _portal; //출구 오브젝트
        public GameObject _player; //Player 오브젝트
        public bool _onstep = false; //계단위에 서있는지 아닌지 검출

        void Update()
        {
            //_onstep이 true인 상태에서 스페이스바를 누르면
            if (Input.GetKeyDown(KeyCode.Space) && _onstep == true)
            {
                //inportal을 동작하며 _onstep은 다시 false로 전환
                inportal();
                _onstep = false;
            }
        }

        public void inportal()
        {
            //출구의 위치값 받아오기
            Vector3 anotherPortalPos = _portal.transform.position;
            //출구의 위치값을 warpPos에 넣기 
            Vector3 warpPos = new Vector3(anotherPortalPos.x, anotherPortalPos.y, anotherPortalPos.z);
            //player와 camera의 position값을 warpPos값의 position값으로 변경 
            _player.transform.position = warpPos;
        }

        //player의 콜라이더와 계단의 rigidbody가 충돌하고 있는지 확인
        private void OnTriggerEnter2D(Collider2D collision)
        {
            //계단위에 서있다면 if문 아니라면 else
            if (collision.gameObject.name == "warrior")
            {
                _onstep = true;
            }
        }
    }
}