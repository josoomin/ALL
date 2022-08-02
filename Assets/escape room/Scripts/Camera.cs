using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roomescape
{
    public class Camera : MonoBehaviour
    {
        public Camera _main;

        public float _angle = 90.0f;

        void Start()
        {

        }

        void Update()
        {

        }


        // > 오른쪽 버튼 누르면, 카메라 각도(y축) 90씩 증가
        public void OnClickRightButton()
        {
            _main.transform.Rotate(new Vector3(0, _angle, 0));
        }

        // < 왼쪽 버튼 누르면, 카메라 각도(y축) 90씩 감소
        public void OnClickLeftButton()
        {
            _main.transform.Rotate(new Vector3(0, -_angle, 0));
        }
    }
}