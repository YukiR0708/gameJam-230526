using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    //�A�C�e���p�֐�
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
