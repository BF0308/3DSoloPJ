using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public Vector3 CurrentSpawnPoint { get; private set; } = Vector3.zero;

    private void Awake()
    {
        CharacterManager.Instance.Player.spawnPoint = this;
    }

    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        CurrentSpawnPoint = newSpawnPoint;
    }
}