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

            // ������ ���� �� �ǹ����� Ư�� ó��
            if (_hp > 0)
            {

            }
            else
            {
                //ü���� 0�� �Ǿ����� ����
                // (���̾� ����Ʈ)
                GameObject fireEffObj = Instantiate(_fireEffTemplate);
                fireEffObj.SetActive(true);
                fireEffObj.transform.position = transform.position; // ����Ʈ ��� ��ġ ����

                Invoke("Disappear", 1.5f);
            }
        }
    }
}
