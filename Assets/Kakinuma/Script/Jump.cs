using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] bool _canJamp = false;
    [SerializeField] float _jumpPower = 0;
    [SerializeField] public float jumpTime = 0;
    Rigidbody2D rb = default;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //Rigidbody2Dのインスタンスを取得
    }

    // Update is called once per frame
    void Update()
    {
        if (_canJamp)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
                //rb.AddForce(new Vector2.0,_jumpPower, ForceMode2D.Impulse);
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _canJamp = true;
        }
        else
        {
            _canJamp = false;
        }
    }
}
