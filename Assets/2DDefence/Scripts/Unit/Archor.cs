using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Defance
{
    public class Archor : Unit
    {
        public GameObject _arrowTemplate;
        public Transform _firePosTranslate;

        protected override void Attack()
        {
            base.Attack();

            //화살(arrow) 객체를 복제 생성
            if (_arrowTemplate != null)
            {
                GameObject arrowObj = Instantiate(_arrowTemplate);
                arrowObj.SetActive(true);
                arrowObj.transform.position = _firePosTranslate.position;

                Arrow arrow = arrowObj.GetComponent<Arrow>();
                arrow._team = _team;
            }
        }
    }
}
