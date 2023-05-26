using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary> �Q�[���}�l�[�W���[�������Ԃ�X�R�A���Ǘ�����  </summary>
public class GameManager : MonoBehaviour
{
    [SerializeField, Tooltip("���݂̃X�R�A")] int _score = 0;
    [SerializeField, Tooltip("��������(�����ݒ�)")] float _initialLimit = 0f;
    [SerializeField, Tooltip("���݂̎c�莞��")] float _nowTime = 0f;
    [SerializeField] Text _timerText = default;
    [SerializeField, Tooltip("�X�R�A�̃J���X�g�l")] float _maxScore = 100000;
    [Tooltip("�O�t���[���̃X�e�[�g")] GameState _oldState = GameState.InGame;
    [Tooltip("�N���A���̎c�莞��")] static float _leftTime = 0f;
    public float LeftTime { get { return _leftTime; } }
    /// <summary> �Q�[���̏�Ԃ��Ǘ�����񋓌^ </summary>
    public enum GameState
    {
        InGame, //�Q�[����
        Clear,  //�N���A
        GameOver,   //�Q�[���I�[�o�[
    }

    private GameState _nowState = GameState.InGame;
    /// <summary> GameState�̃v���p�e�B </summary>
    public GameState NowState { get => _nowState; set => _nowState = value; }

    void Start()
    {
        _nowTime = _initialLimit;
    }

    void Update()
    {
        if(_nowState == GameState.InGame)
        {
            Timer();
        }
        else if(_nowState == GameState.Clear && _oldState == GameState.InGame)
        {
            
        }
        else if(_nowState == GameState.GameOver && _oldState == GameState.InGame)
        {
            GameOver();
        }

        _oldState = _nowState;
    }

    /// <summary> �X�R�A�����Z���郁�\�b�h </summary>
    /// <param name="score"> ���Z�������X�R�A </param>
    public void AddScore(int score)
    {
        if(_score < _maxScore)
        {
            _score += score;
        }
    }

    /// <summary> �c�莞�Ԃ����炵�ĕ\�����郁�\�b�h  </summary>
    private void Timer()
    {
        _nowTime -= Time.deltaTime;
        _timerText.text = _nowTime.ToString("D5");
        if(_nowTime <= 0f)
        {
            _nowState = GameState.GameOver;
        }
    }

    /// <summary> �Q�[���I�[�o�[�ɂ��郁�\�b�h  </summary>
    public void GameOver()
    {
        _nowState = GameState.GameOver;
    }

    /// <summary> �Q�[���N���A�ɂ��郁�\�b�h  </summary>
    public void Clear()
    {
        _nowState = GameState.Clear;
    }

}
