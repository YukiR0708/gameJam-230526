using UnityEngine;
using UnityEngine.UI;

public class LoadResult : MonoBehaviour
{
    float _bonusScore = 0f;
    [SerializeField, Tooltip("�{�[�i�X�ɏ�Z����l")] float _bonusAdd = 0f;
    [SerializeField, Tooltip("�{�[�i�X�e�L�X�g")] Text _bonusText = default;
    [SerializeField] GameManager _gm = default;

    void Start()
    {
        _bonusScore = _gm.LeftTime * _bonusAdd + _gm.Score;
        _bonusText.text = "�{�[�i�X" + _bonusScore.ToString("00000");
    }

}
