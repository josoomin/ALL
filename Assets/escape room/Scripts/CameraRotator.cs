using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roomescape
{
    public class CameraRotator : MonoBehaviour
    {
        public CameraRotator _main;

        public float _angle = 90.0f;
        public float _rec = 45.0f;
        public float _move = 100.0f;

        public GameObject _ItemMenu;

        public GameObject _upB;
        public GameObject _downB;
        public GameObject _leftB;
        public GameObject _rightB;
        public GameObject _ItemB;

        void Start()
        {
            _upB.SetActive(false);
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

        // 위 버튼 누르면 카메라 각도 (x축) 45 증가
        public void OnClickUpButton()
        {
            _main.transform.Rotate(new Vector3(-_rec, 0, 0));
            _upB.SetActive(false);
            _downB.SetActive(true);
            _leftB.SetActive(true);
            _rightB.SetActive(true);
        }

        // 아래 버튼 누르면 카메라 각도 (x축) 45 감소
        public void OnClickDownButton()
        {
            _main.transform.Rotate(new Vector3(_rec, 0, 0));
            _upB.SetActive(true);
            _downB.SetActive(false);
            _leftB.SetActive(false);
            _rightB.SetActive(false);
        }

        public void OnClickUpItemMenu()
        {
            if (_downB.activeSelf == true)
            {
                _downB.SetActive(false);
                _ItemMenu.transform.position = new Vector3(0, _move, 0);
            }

            else if (_downB.activeSelf == false)
            {
                _downB.SetActive(true);
                _ItemMenu.transform.position = new Vector3(0, -_move, 0);
            }

            
        }
    }
}