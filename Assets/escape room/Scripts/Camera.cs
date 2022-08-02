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


        // > ������ ��ư ������, ī�޶� ����(y��) 90�� ����
        public void OnClickRightButton()
        {
            _main.transform.Rotate(new Vector3(0, _angle, 0));
        }

        // < ���� ��ư ������, ī�޶� ����(y��) 90�� ����
        public void OnClickLeftButton()
        {
            _main.transform.Rotate(new Vector3(0, -_angle, 0));
        }
    }
}