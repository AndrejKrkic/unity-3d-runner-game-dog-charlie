using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField]
    private Vector3 nextSpawnPoint;
    [SerializeField]
    private GameObject ground;

    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            SpawnGround();
        }
    }

    public void SpawnGround()
    {
        GameObject temp = Instantiate(ground, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(0).transform.position;
    }
}
