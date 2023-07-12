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
    Jump _jump = default;

    public float _ladderSpeed; //移動速度(インスペクターから変更可)
    private bool _isLadder = false;
    SpriteRenderer _spriteRenderer;
    [SerializeField] Animator _anim;

    public float _LadderTime;
    public float verticalKey;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //Rigidbody2Dのインスタンスを取得
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
        _jump = GetComponentInChildren<Jump>();
    }

    void Update()
    {

        float horizontalKey = Input.GetAxis("Horizontal");
        verticalKey = Input.GetAxisRaw("Vertical");
        float xSpeed = 0;
        //アニメーションを絶対値で設定する
        _anim.SetFloat("Walk", MathF.Abs(horizontalKey));
        _anim.SetBool("Up", _LadderTime > 0);
        //_anim.SetBool("Up", verticalKey != 0 && _isLadder);
        if (horizontalKey > 0) //右移動速度
        {
            xSpeed = speed;
            _spriteRenderer.flipX = false;
        }
        if (horizontalKey < 0) //左移動速度
        {
            xSpeed = -speed;
            _spriteRenderer.flipX = true;
        }

        //はしごに触れてる
        if (_isLadder)
        {
            //上下入力があるとき
            if (verticalKey > 0)
            {
                rb.gravityScale = 0;
                rb.velocity = Vector2.up * verticalKey;
                _LadderTime++;
            }
            else if (verticalKey < 0)
            {
                rb.gravityScale = 0;
                rb.velocity = Vector2.up * verticalKey;
                //_LadderTime = 0;
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
            //登ってる最中
            if (0 < _LadderTime)
            {
                xSpeed = 0;
                if (_jump.CanJamp)
                {
                    _jump.CanJamp = false;
                }
            }
            if (verticalKey <= 0 && _jump.CanJamp)
            {
                rb.gravityScale = 1;
            }
        }

        ////はしごに触れてない　かつ　入力が↓かない
        //if (verticalKey <= 0 && !_isLadder)
        //{
        //    rb.gravityScale = 1;
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (verticalKey < 0 && collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Slope")
        {
            if (_LadderTime > 0)
            {
                _LadderTime = 0;
            }
        }
    }
}
