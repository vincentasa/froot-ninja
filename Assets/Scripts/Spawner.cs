using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public GameObject bombPrefab;
	public List<GameObject> fruitPrefabs;
	public List<Wave> waves;

	async void Start()
	{
		foreach (var wave in waves)
		{
			foreach (var fruit in wave.items)
			{
				await new WaitForSeconds(fruit.delay);

				var randomFruit = fruitPrefabs[Random.Range(0, fruitPrefabs.Count)];
				var prefab = fruit.isBomb ? bombPrefab : randomFruit;
				var go = Instantiate(prefab);
				go.transform.position = new Vector3(fruit.x, -5f, 0);

				var rb = go.GetComponent<Rigidbody2D>();
				rb.velocity = fruit.velocity;
			}

			await new WaitForSeconds(3f);
		}
	}
}