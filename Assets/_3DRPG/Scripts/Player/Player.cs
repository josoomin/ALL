using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace RPG3D
{
    public class Player : Unit
    {

        void Update()
        {
            if (CrossPlatformInputManager.GetButtonDown("Fire1")) // Fire1 : 조이패드 파이어 버튼, 키보드 왼쪽콘트롤버튼, 마우스 왼쪽버튼
            {
                // 공격!!
                //m_Character.Attack();
                Attack();
            }
        }
    }
}
