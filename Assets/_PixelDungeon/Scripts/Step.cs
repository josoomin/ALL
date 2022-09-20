using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelDungeon
{
public class Step : MonoBehaviour
    {

        public GameObject _portal; //�ⱸ ������Ʈ
        public GameObject _player; //Player ������Ʈ
        public bool _onstep = false; //������� ���ִ��� �ƴ��� ����

        void Update()
        {
            //_onstep�� true�� ���¿��� �����̽��ٸ� ������
            if (Input.GetKeyDown(KeyCode.Space) && _onstep == true)
            {
                //inportal�� �����ϸ� _onstep�� �ٽ� false�� ��ȯ
                inportal();
                _onstep = false;
            }
        }

        public void inportal()
        {
            //�ⱸ�� ��ġ�� �޾ƿ���
            Vector3 anotherPortalPos = _portal.transform.position;
            //�ⱸ�� ��ġ���� warpPos�� �ֱ� 
            Vector3 warpPos = new Vector3(anotherPortalPos.x, anotherPortalPos.y, anotherPortalPos.z);
            //player�� camera�� position���� warpPos���� position������ ���� 
            _player.transform.position = warpPos;
        }

        //player�� �ݶ��̴��� ����� rigidbody�� �浹�ϰ� �ִ��� Ȯ��
        private void OnTriggerEnter2D(Collider2D collision)
        {
            //������� ���ִٸ� if�� �ƴ϶�� else
            if (collision.gameObject.name == "warrior")
            {
                _onstep = true;
            }
        }
    }
}