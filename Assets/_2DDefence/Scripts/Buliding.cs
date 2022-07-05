using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Defance
{
    public class Buliding : MapObject
    {
        public GameObject _fireEffTemplate;

        public override void DoDamage(int damage)
        {
            base.DoDamage(damage);

            // 데미지 입을 때 건물만의 특수 처리
            if (_hp > 0)
            {

            }
            else
            {
                //체력이 0이 되었으니 폭파
                // (파이어 이펙트)
                GameObject fireEffObj = Instantiate(_fireEffTemplate);
                fireEffObj.SetActive(true);
                fireEffObj.transform.position = transform.position; // 이펙트 재생 위치 설정

                Invoke("Disappear", 1.5f);
            }
        }
    }
}
