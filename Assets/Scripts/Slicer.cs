using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Slicer : MonoBehaviour
{
	Rigidbody2D rb;

	public int comboCount;
	public float comboTimeLeft;
	public List<AudioClip> comboSounds;
	public TextMeshPro scoreText;
	public int score = 0;


	void Start()
	{
		Application.targetFrameRate = 60;
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        scoreText.text = score.ToString();
        worldPos.z = 0;

		rb.MovePosition(worldPos);


		comboTimeLeft -= Time.deltaTime;
		if (comboTimeLeft <= 0)
		{
			if (comboCount >= 3)
			{

				AudioSystem.Play(comboSounds[comboCount-3]);
			}
			comboCount = 0;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		var fruit = other.gameObject.GetComponent<Fruit>();
		fruit.Slice();

		comboCount++;
		comboTimeLeft = 0.2f;
        score++;
    }
}