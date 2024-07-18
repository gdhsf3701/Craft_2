using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CSI_Item : MonoBehaviour
{
    private GameObject Player_item,Player;
    private bool can_get_item,can_change;
    private float speed = 1000;
    public bool itahamsu;//True면 포물선으로 던지기
    
    private Vector3 startPos, endPos;
    //땅에 닫기까지 걸리는 시간
    private float timer;
    private float timeToFloor;

    public UnityEvent OnDstroyEvent;
    private static Vector3 Parabola(Vector3 start, Vector3 end, float height, float t)
    {
        Func<float, float> f = x => -4 * height * x * x + 4 * height * x;

        var mid = Vector3.Lerp(start, end, t);

        return new Vector3(mid.x, f(t) + Mathf.Lerp(start.y, end.y, t), mid.z);
    }

    private IEnumerator BulletMove()
    {
        timer = 0;
        while (transform.position.y>=startPos.y-30)
        {
            timer += Time.deltaTime;
            Vector3 tempPos = Parabola(startPos, endPos, 5, timer);
            transform.position = tempPos;
            yield return new WaitForEndOfFrame();
        }
    }


    

    public bool can_throw { get; set; }
    public bool Ihand{ get; set; }

    private void Awake()
    {
        Player = GameObject.Find("Player_CSI");//플래이어 이름을 넣어야합니다......[SerializeField]--사용 금지--(양산 불가.)
        Player_item = GameObject.Find("Item_");//플래이어 자식으로 있는 아이템
        Ihand = false;
        can_change = false;

    }
    /// <summary>
    /// ------------------이 아래는 중요 
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)&&can_get_item)//F 를 눌렀고,아이템 주변에 플래이어가 있고,나 자신이 던지고 있는중이 아니면
        {
            if (can_change&&transform.parent)//can_change가 켜져 있으면 손에 아이템이 있고 바꿀수 있다.
            { //땅에 있는 스크
                GameObject fire_item;
                
                if (Player_item.transform.childCount != 0)
                {
                    fire_item = Player_item.transform.GetChild(0).gameObject;
                    fire_item.GetComponent<CSI_Item>().can_throw = false;
                    fire_item.GetComponent<CSI_Item>().Ihand = false;
                    fire_item.transform.parent = null;// 아이템을 빼기
                }

                can_throw = true;
                Ihand = true;
                transform.position = Player_item.transform.position;
                transform.parent = Player_item.transform;
            }
            else if (Player_item.transform.childCount == 0)
            {
                transform.position = Player_item.transform.position;
                transform.parent = Player_item.transform;
                can_throw = true;
                Ihand = true;
            }
            else if(can_throw&&Ihand)
            {
                //손에 있는 스크
                GameObject fire_item;
                fire_item = Player_item.transform.GetChild(0).gameObject;
                fire_item.transform.parent = null;
                fire_item.GetComponent<CSI_Item>().Ihand = true;
                if (!itahamsu)
                {
                    if (Player.transform.rotation.y == 0)
                    {
                        fire_item.GetComponent<Rigidbody2D>().velocity += Vector2.right * (Time.fixedDeltaTime * speed);

                    }
                    else
                    {
                        fire_item.GetComponent<Rigidbody2D>().velocity += Vector2.left * (Time.fixedDeltaTime * speed);

                    }
                }
                else
                {
                    startPos = fire_item.transform.position;
                    if (Player.transform.rotation.y == 0)
                        endPos = startPos + new Vector3(10, 0, 0);
                    else
                    {
                        endPos = startPos + new Vector3(-10, 0, 0);

                    }
                    StartCoroutine("BulletMove");
                }

            }
        }
    }
    /// <summary>
    /// ------------------이 위는 중요 
    /// </summary>

    public void Throwandthouch()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)//아이템 주위에 들어올때
    {
        if (!can_get_item && Ihand &&!other.transform.CompareTag("Player"))
        {
            if (other.transform.CompareTag("Ground"))
            {
                OnDstroyEvent?.Invoke();
            }
        }
        if (other.transform.CompareTag("Player"))
        {
            if (Player_item.transform.childCount != 0)//손에 가지고 있다
            {
                if (Player_item.transform.GetChild(0))
                {
                    Player_item.transform.GetChild(0).GetComponent<CSI_Item>().can_throw = false;
                }
                can_change = true;
            }

            
            can_get_item = true;

        }
    }

    private void OnTriggerExit2D(Collider2D other)//아이템에서 나올때
    {
        if (other.transform.CompareTag("Player"))
        {
            if (Player_item.transform.childCount != 0)//손에 가지고 있다
            {
                if (Player_item.transform.GetChild(0))
                {
                    Player_item.transform.GetChild(0).GetComponent<CSI_Item>().can_throw = true;
                }
                can_change = false;
            }
            can_get_item = false;
        }
    }
}
