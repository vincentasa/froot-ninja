using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject explodeParticles;
    Rigidbody2D rb;
    public Color juiceColor;
    public AudioClip spawnSound;
    public AudioClip sliceSound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.angularVelocity = Random.Range(-360,360);
        AudioSystem.Play(spawnSound);
    }

    void Update()
    {
        if (transform.position.y < -6)
        {
            Miss();
        }
    }

    void Miss()
    {
        print(":(");
        Destroy(gameObject);
    }

    public void Slice()
    {
        var particles = Instantiate(explodeParticles);
        particles.transform.position = transform.position;

        if(!CompareTag("Boom"))Split(particles);
        AudioSystem.Play(sliceSound);

        Destroy(gameObject);
    }

    void Split(GameObject particles)
    {
        var children = GetComponentsInChildren<MeshRenderer>();
        foreach (var child in children)
        {
            var childRb = child.gameObject.AddComponent<Rigidbody2D>();
            childRb.velocity = rb.velocity + Random.insideUnitCircle;
        }
        transform.DetachChildren();

        particles.GetComponent<ParticleSystem>().startColor = juiceColor;
        particles.transform.GetChild(0).GetComponent<ParticleSystem>().startColor = juiceColor;
    }
}