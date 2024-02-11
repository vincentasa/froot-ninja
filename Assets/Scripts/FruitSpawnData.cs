using UnityEngine;

[System.Serializable]
public class FruitSpawnData
{
	public bool isBomb;
	public float delay;
	public float x;
	public Vector2 velocity = new Vector2(0,10);
}