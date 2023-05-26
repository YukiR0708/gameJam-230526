using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField, Tooltip("�n���}�[��������true")]
    bool _ishammer = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //PlayerItem���Ԃ�����GameObject�ɂ��Ă�����
        if (collision.gameObject.TryGetComponent<PlayerItem>(out PlayerItem playerItem))
        {
            AudioManager audioManager = collision.gameObject.GetComponent<AudioManager>();
            audioManager.SePlay(2);

            //�n���}�[�̎�
            if (_ishammer)
            {
                playerItem.Hammer();
            }
            //�X�^�[�̎�
            else
            {
                playerItem.Star();
            }

            Destroy(gameObject);
        }
    }
}
