using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyTower
{
    public class CameraDrag : MonoBehaviour
    {
        Vector3 _dragStartPos;
        [SerializeField] float _dragSpeed = 2.0f;

        [SerializeField] float _yMin = 10.0f;
        [SerializeField] float _yMax = 60.0f;

        void Start()
        {

        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0)) // 마우스가 클릭됨 (드래그 시작)
            {
                _dragStartPos = Input.mousePosition;
            }
            else if (Input.GetMouseButton(0)) //마우스가 계속 눌려지고 있는 상태
            {
                Vector3 currentPos = Input.mousePosition; ;
                //이 때 카메라를 움직여 주기

                Vector3 dir = currentPos - _dragStartPos;

                Vector3 worldDir = Camera.main.ScreenToViewportPoint(dir);
                Vector3 move = -1 * new Vector3(0, worldDir.y * _dragSpeed, 0);

                if(move.y > 0)
                {
                    if(transform.position.y < _yMax)
                    {
                        transform.Translate(move, Space.World);
                    }
                }
                else if (move.y < 0) //카메라 위치 제한
                {
                    if (_yMin < transform.position.y)
                    {
                        transform.Translate(move, Space.World);
                    }
                }
            }
        }
    }
}