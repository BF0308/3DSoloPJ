using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    private static CharacterManager _instance;
    public static CharacterManager Instance//싱글톤
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

    public Player Player//프로퍼티(출,입구) 사용용
    {
        get { return _player; }
        set { _player = value; }
    }
    private Player _player;//실질적으로 Player의 모든 데이터가 저장되는곳 저장용

    private void Awake()
    {
        if(_instance == null)//_instance 값이 없으면 정의하고,안부수고
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else//중복으로 있으면 
        {
            if(_instance != this)//이 오브젝트가 아니면 부수기
            {
                Destroy(gameObject);
            }
        }
    }
}
