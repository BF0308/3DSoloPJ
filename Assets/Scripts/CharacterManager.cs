using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    private static CharacterManager _instance;
    public static CharacterManager Instance//�̱���
    {
        get
        {
            if(_instance == null)
            {
                _instance = new GameObject("CharacerManager").AddComponent<CharacterManager>();
            }
            return _instance;
        }
    }

    public Player Player//������Ƽ(��,�Ա�) ����
    {
        get { return _player; }
        set { _player = value; }
    }
    private Player _player;//���������� Player�� ��� �����Ͱ� ����Ǵ°� �����

    private void Awake()
    {
        if(_instance == null)//_instance ���� ������ �����ϰ�,�Ⱥμ���
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else//�ߺ����� ������ 
        {
            if(_instance != this)//�� ������Ʈ�� �ƴϸ� �μ���
            {
                Destroy(gameObject);
            }
        }
    }
}
