using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG3D
{
    public class Unit : MonoBehaviour
    {
        BoxCollider _attackCol;

        // Start is called before the first frame update
        void Start()
        {
            if (this is Knight)
            {
                _attackCol = transform.Find("arm_R_weapon/Knight_handsword").GetComponent<BoxCollider>();

                if (_attackCol != null)
                {
                    // 시작할때 공격충돌체 꺼주기
                    _attackCol.enabled = false;
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SetAttackCol(int on) // 1 - on, 0 - off
        {
            if (_attackCol == null) // 공격 충돌체가 없다면 실행하지 않기
                return;

            if (on == 1)
            {
                _attackCol.enabled = true; // 공격 충돌체를 켠다
            }

            if (on == 0)
            {
                _attackCol.enabled = false; // 공격 충돌체를 꺼둔다
            }
        }
    }
}