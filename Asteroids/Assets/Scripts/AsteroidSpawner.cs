using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public Asteroid asteroidsPrefab;
    public float spawnRate = 2f;
    public int spawnAmount = 1;
    public BoxCollider2D worldBounds;
    public BoxCollider2D safeArea;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void Spawn()
    {
        Vector2 pos;
        for (int i = 0; i < spawnAmount; i++)
        {
            do
            {
                pos = new Vector2(
                    Random.Range(worldBounds.bounds.min.x, worldBounds.bounds.max.x),
                    Random.Range(worldBounds.bounds.min.y, worldBounds.bounds.max.y));
            } while (safeArea.bounds.Contains(new Vector3(pos.x, pos.y, 0f)));
            Asteroid asteroid = Instantiate(asteroidsPrefab, pos, Quaternion.identity);
            
        }
    }
}
