using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject[] prefabs;
    public Vector3 spawnValues;
    public float delay = 2.0f;
    public bool active = true;
    public Vector2 delayRange = new Vector2(1, 2);

	// Use this for initialization
	void Start () {
        ResetDelay();
        StartCoroutine(EnemyGen());

	}

	IEnumerator EnemyGen()
    {
        yield return new WaitForSeconds(delay);

        if (active)
        {
			Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x),Random.Range(-spawnValues.y, spawnValues.y),spawnValues.z);

			Instantiate(prefabs[Random.Range(0, prefabs.Length)], spawnPosition,transform.rotation);
            ResetDelay();
        }
        StartCoroutine(EnemyGen());
    }

    void ResetDelay()
    {
        delay = Random.Range(delayRange.x, delayRange.y);
    }

}
