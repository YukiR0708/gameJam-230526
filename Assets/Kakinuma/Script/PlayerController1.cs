using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    [SerializeField] float m_movePower = 5f;
    float m_h;
    float m_scaleX;
    Rigidbody2D m_rb = default;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        m_h = Input.GetAxisRaw("Horizontal");
        if (m_h > 0)
        {
            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
    }
    private void FixedUpdate()
    {
        m_rb.AddForce(Vector2.right * m_h * m_movePower, ForceMode2D.Force);
    }
}
