using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] bool _canJamp = false;
    [SerializeField] float _jumpPower = 0;
    [SerializeField] public float _jumpTime = 0;
    Rigidbody2D rb = default;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //Rigidbody2Dのインスタンスを取得
    }

    // Update is called once per frame
    void Update()
    {
        if (_canJamp)　//ジャンプ
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
                _jumpTime++;
                _canJamp = false;
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //ジャンプ
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Slope")
        {
            _canJamp = true;
            _jumpTime = 0;
        }
        if (_jumpTime > 0)
        {
            _canJamp = false;
        }
    }
}
