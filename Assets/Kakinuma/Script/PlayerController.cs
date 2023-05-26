using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed; //移動速度(インスペクターから変更可)
    private Rigidbody2D rb = null;
    [SerializeField] GameObject _footPoint = default;
    [SerializeField, Tooltip("rayの長さ")] float _rayLength = 0f;

    public float _ladderSpeed; //移動速度(インスペクターから変更可)
    private bool isLadder = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //Rigidbody2Dのインスタンスを取得
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalKey = Input.GetAxis("Horizontal");
        float verticalKey = Input.GetAxisRaw("Vertical");
        float xSpeed = 0;
        float ySpeed = 0;
        if (horizontalKey > 0) //右移動速度
        {
            //transform.localScale = new Vector3(1, 1, 1);
            xSpeed = speed;
        }
        if (horizontalKey < 0) //左移動速度
        {
            xSpeed = -speed;
        }

        if (isLadder)
        {
            if (verticalKey > 0)
            {
                ySpeed = verticalKey * 0.15f;
            }
        }
        //RaycastHit2D raycastHit2D = Physics2D.Raycast(_footPoint.transform.position, Vector2.right, _rayLength);
        //Vector2 _playerUp = raycastHit2D.normal;
        //if(raycastHit2D.collider.gameObject.CompareTag("Slope"))
        //{
        //    var temp = Vector3.ProjectOnPlane(Vector2.right, -_playerUp);
        //    var _direction = new Vector2(temp.x, temp.y);
        //    rb.velocity = _direction * xSpeed + Vector2.up * rb.velocity.y;
        //}
        //else
        //{
        //    rb.velocity = new Vector2(xSpeed, rb.velocity.y); //速度最終結果(yはGravity Scale)
        //}
        rb.velocity = new Vector2(xSpeed, rb.velocity.y+ySpeed); //速度最終結果(yはGravity Scale)
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "LadderControll")
        {
            isLadder = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "LadderControll")
        {
            isLadder = false;
        }
    }
}
