using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed; //移動速度(インスペクターから変更可)
    private Rigidbody2D rb = null;
    [SerializeField] GameObject _footPoint = default;
    [SerializeField, Tooltip("rayの長さ")] float _rayLength = 0f;
    [SerializeField] GameManager _gm = default;

    public float _ladderSpeed; //移動速度(インスペクターから変更可)
    private bool _isLadder = false;
    SpriteRenderer _spriteRenderer;
    [SerializeField] Animator _anim;

    public float _LadderTime;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //Rigidbody2Dのインスタンスを取得
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalKey = Input.GetAxis("Horizontal");
        float verticalKey = Input.GetAxisRaw("Vertical");
        float xSpeed = 0;
        float ySpeed = 0;
        //アニメーションを絶対値で設定する
        _anim.SetFloat("Walk", MathF.Abs(horizontalKey));
        _anim.SetBool("Up", verticalKey > 0 && _isLadder);
        Debug.Log(verticalKey);
        if (horizontalKey > 0) //右移動速度
        {
            //transform.localScale = new Vector3(1, 1, 1);
            xSpeed = speed;
            _spriteRenderer.flipX = false;
        }
        if (horizontalKey < 0) //左移動速度
        {
            xSpeed = -speed;
            _spriteRenderer.flipX = true;
        }

        if (verticalKey > 0 && _isLadder)
        {
            //ySpeed = verticalKey * 0.15f;
            //transform.Translate(Vector2.up * speed, Space.World);
            //xSpeed = 0;
            rb.gravityScale = 0;
            Transform _transform = this.transform;
            Vector2 _pos = _transform.position;
            _pos.y += 0.01f;
            transform.position = new Vector2(this.transform.position.x, _pos.y);
            _anim.SetBool("Up", true);

            _LadderTime++;
            //transform.Translate(Vector2.up * Time.deltaTime, Space.World);

            //Vector2    

        }
        if (verticalKey <= 0 && !_isLadder)
        {
            rb.gravityScale = 1;
            _LadderTime = 0;
        }

        if (_LadderTime > 0)
        {
            xSpeed = 0;
            _anim.SetBool("Up", true);
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
        rb.velocity = new Vector2(xSpeed, rb.velocity.y); //速度最終結果(yはGravity Scale)
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "LadderControll")
        {
            _isLadder = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "LadderControll")
        {
            _isLadder = false;
            rb.gravityScale = 1;
        }
        if (collision.tag == "Toge")
        {
            _gm.AddScore(10);
        }

    }
}
