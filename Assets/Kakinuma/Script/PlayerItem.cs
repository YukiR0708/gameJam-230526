using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    //アイテム用関数
    // Start is called before the first frame update
    bool _isHammer = false;
    bool _isStar = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Hammer()
    {
        _isHammer = true;
    }
    public void Star()
    {
        _isStar = true;
    }
}
