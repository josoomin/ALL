using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG3D
{
    public class Slime : Unit
    {
        public float _attackRange = 1.5f;
        public GameObject _enemyObj;

        private void Update()
        {
            CheckDistance();
        }

        void CheckDistance() 
        {
            if (_enemyObj == null)
                return;

            Vector3 pos1 = transform.position;   //나(슬라임)의 위치
            Vector3 pos2 = _enemyObj.transform.position;  //적(캐릭터)의 위치

            //float distance = Mathf.Abs(pos1 - pos2); // 두 캐릭터 간의 거리(두 x좌표 사이의 거리)
            float distance = Vector3.Distance(pos1, pos2);

            if (distance < _attackRange /* && _hp > 0 */) 
            {
                if(m_Animater != null)
                m_Animater.SetTrigger("attack");

                //적을 바라보게 하기
                transform.LookAt(_enemyObj.transform);

                //Unit enemyUnit = _enemyObj.GetComponent<Unit>();
                //enemyUnit.DoDamage(10);
            }
        }
    }
}