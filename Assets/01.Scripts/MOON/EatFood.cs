using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatFood : MonoBehaviour
{
    private bool isPlayer = false;
    GameObject Player;
    private void Awake()
    {
        Player = GameObject.Find("Player");
    }
    private void Update()
    {
        if (isPlayer&&Input.GetKeyDown(KeyCode.F))
        {
            //체력을 회복하는 코드
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player)
        {
            isPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject == Player)
        {
            isPlayer = false;
        }
    }
}
