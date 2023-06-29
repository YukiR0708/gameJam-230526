using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Jump : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] bool _canJamp = false;
    [SerializeField] float _jumpPower = 0;
    [SerializeField] public float _jumpTime = 0;
    Rigidbody2D rb = default;
    Animator _anim;
    [SerializeField] List<BoxCollider2D> _colls = new();
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //Rigidbody2Dのインスタンスを取得
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_canJamp)　//ジャンプ
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _anim.SetBool("Jump", true);
                rb.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
                _jumpTime++;
                _canJamp = false;
                foreach (var coll in _colls)
                {
                    coll.usedByEffector = false;
                }
            }

        }
        else
        {
            _anim.SetBool("Jump", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //着地
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Slope")
        {
            _canJamp = true;
            _jumpTime = 0;
            foreach (var coll in _colls)
            {
                coll.usedByEffector = true;
            }
        }
        if (_jumpTime > 0)
        {
            _canJamp = false;
        }
    }
}
