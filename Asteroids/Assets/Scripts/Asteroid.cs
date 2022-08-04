using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Rigidbody2D body;

    private float speed;
    public string size;

    public Asteroid asteroid_medium_prefab;
    public Asteroid asteroid_small_prefab;


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        GameManager.instance.nrOfAsteroidsInScene++;

    }

    private void Start()
    {

        transform.eulerAngles = new Vector3(0, 0, Random.value * 360f);
        transform.localScale = Vector3.one * 1f;


        speed = Random.Range(0.5f, 1.5f);
        GetComponent<Rigidbody2D>().velocity = GetRandomDir() * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            if (size == "Big")
            {
                for (int i = 0; i < 2; i++)
                {
                    Instantiate(asteroid_medium_prefab, transform.position, Quaternion.identity);
                }
                GameManager.instance.AddScore(20);
            }
            else if (size == "Medium")
            {
                for (int i = 0; i < 2; i++)
                {
                    Instantiate(asteroid_small_prefab, transform.position, Quaternion.identity);
                }
                GameManager.instance.AddScore(50);

            }
            else if (size == "Small")
            {
                GameManager.instance.AddScore(100);
            }
            GameManager.instance.nrOfAsteroidsInScene--;
            Destroy(gameObject);
        }
    }

    private Vector2 GetRandomDir()
    {
        
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}
