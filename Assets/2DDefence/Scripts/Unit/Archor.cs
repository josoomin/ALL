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

            //ȭ��(arrow) ��ü�� ���� ����
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
