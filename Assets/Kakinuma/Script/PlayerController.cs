using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed; //移動速度(インスペクターから変更可)
    private Rigidbody2D rb = null;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //Rigidbody2Dのインスタンスを取得
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalKey = Input.GetAxis("Horizontal");
        //float verticalKey = Input.GetAxis("Vertical");
        float xSpeed = 0;
        if (horizontalKey > 0) //右移動速度
        {
            //transform.localScale = new Vector3(1, 1, 1);
            xSpeed = speed;
        }
        if (horizontalKey < 0) //左移動速度
        {
            xSpeed = -speed;
        }
        rb.velocity = new Vector2(xSpeed, rb.velocity.y); //速度最終結果(yはGravity Scale)

    }
}
