using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyCat
{
    public class Cat : MonoBehaviour
    {
        //public static ConstantForce ITEM_NAME_HEART = "Heart";

        public GameManager _gameMgr;
        public Transform _cat;

        public float _speed = 1000.0f;
        Rigidbody2D _rigid;
        SpriteRenderer _renderer;
        Animator _anim;

        //이모티콘
        GameObject _emoteSweat;
        GameObject _emoteHappy;

        void Start()
        {
            //이모티콘들 찾아서 변수에 저장해놓기
            _emoteSweat = transform.Find("emoticon_sweat").gameObject;
            _emoteHappy = transform.Find("emoticon_happy").gameObject;
            _emoteSweat.SetActive(false);
            _emoteHappy.SetActive(false);

            //기타 주요 컴포넌트를 찾아서 변수에 저장해놓기
            _rigid = GetComponent<Rigidbody2D>();
            _renderer = GetComponent<SpriteRenderer>();
            _anim = GetComponent<Animator>();

            // idle1, idle2 애니메이션 랜덤 재생 시작
            float delay = Random.Range(3.0f, 10.0f);
            Invoke("PlayIdel", delay);
        }

        void Update()
        {

        }

        void CheckDitance()
        {
            Transform jarTrans = _gameMgr._worldObj.transform.Find("Cup");

            //테스트로 티비와 고양이 사이의 거리를 체크
            //거리가 충분히 가까우면(예: 거리 0.5) 로그 출력
            Vector2 catPos = transform.position;
            Vector2 objPos = jarTrans.position;

            float distance = Vector2.Distance(catPos, objPos);

            //Vector2 distVector = catPos - objPos;
            //float distance = distVector.magnitude;

            //float xDist = Mathf.Abs(catPos.x - objPos.x);
            //float yDist = Mathf.Abs(catPos.y - objPos.y);
            
            //float distance = Mathf.Sqrt(xDist * xDist + yDist * yDist);
            if(distance < 0.5f)
            {
                Debug.Log("항아리 근접");
            }
        }

        void PlayIdel()
        {
            int random = Random.Range(2, 4); // 주사위가 2 아니면 3이 나옴

            //if (random == 2)
            //    _anim.SetTrigger("Idle1");
            //else if (random == 3)
            //    _anim.SetTrigger("Idle2");

            // 단항연산자 unary operator - i++
            // 이항연산자 binary operator - 2 / 3
            // 삼항연산자 ternary operator - ( ) ? ( ) : ( )
 
            string temp = (random == 2) ? "Idle1" : "Idel2"; // ? - 삼항연산자
            _anim.SetTrigger(temp);

            float delay = Random.Range(3.0f, 10.0f);
            Invoke("PlayIdel", delay);  //재귀 호출 (recursive call)
        }

        void FixedUpdate()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            if (h == 0 && v == 0)
            {
                _anim.SetBool("moving", false);
            }
            else
            {
                _anim.SetBool("moving", true);
            }

            if (_anim.GetBool("eating") == false) //먹는 동작(애니메이션)하고 있는 중이 아니라면....
            {
                Move(h, v);
                Flip(h);
            }
        }

        void Move(float h, float v)
        {
            //Debug.Log("h: " + h);
            //Debug.Log("v: " + v);
            //Debug.Log(string.Format("v: {0}", v));

            float runSpeed = 1.0f;
            if(Input.GetKey(KeyCode.LeftShift))
            {
                runSpeed = 2.0f;
            }

            float fixedDeltaTime = Time.fixedDeltaTime;

            _rigid.velocity = new Vector2(h, v) * fixedDeltaTime * _speed * runSpeed;

            float vel = _rigid.velocity.magnitude;

            //Debug.Log("vel: " + vel);

            _anim.SetFloat("velocity", vel);
        }

        void Flip(float h)
        {
            if(h < 0)
            {
                //좌
                _renderer.flipX = false;
            }
            else if(h > 0)
            {
                //우
                _renderer.flipX = true;
            }
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.name == "CatDish")
            {
                //밥먹기 이벤트 발생
                Eat();
                
            }
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.name == "Heart")
            {
                //하트 획득
                _gameMgr.AddHeart(1);
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.name.Contains("Coin"))
            {
                //코인 획득
                if (collision.gameObject.name == "Coin_1000")
                    _gameMgr.AddCoin(1000);
                else
                    _gameMgr.AddCoin(1);

                Destroy(collision.gameObject);
            }
        }

        void Eat()
        {
            Debug.Log("Eat");
            _rigid.velocity = new Vector2(0, 0); //먹을 때 움직이지 않도록 속도 0

            _emoteSweat.SetActive(true);
            //PlayEmoticon("Sweat", 5.0f);

            _anim.SetBool("eating", true);

            Invoke("StopEat", 5.0f);
        }

        void PlayEmoticon(string iconName, float duration)
        {
            
        }

        void StopEat()
        {
            Debug.Log("StopEat");

            _anim.SetBool("eating", false);

            _gameMgr.OnFinish_Eat();  //밥먹기가 끝났음을 게임제니저에 알리기

            //PlayEmoticon("Happy", 3.0f);
            _emoteSweat.SetActive(false);
            _emoteHappy.SetActive(true);
            Invoke("StopHappy", 3.0f);

            _gameMgr.Dropheart(_cat);
        }

        void StopHappy()
        {
            _emoteHappy.SetActive(false);

            Debug.Log("StopEat and happy");
        }

    }
}
