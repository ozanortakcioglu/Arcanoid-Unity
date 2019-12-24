using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickMeneger : MonoBehaviour
{
    public int rows;
    public int columns;
    public float space;
    public GameObject brickPrefab;

    public List<GameObject> bricks = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        ResetLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetLevel()
    {
        foreach (GameObject brick in bricks)
            Destroy(brick);
        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                Vector2 spawnPos = (Vector2)transform.position + new Vector2(
                    x *(brickPrefab.transform.localScale.x + space),
                    -y * (brickPrefab.transform.localScale.y + space)
                    );
                GameObject brick = Instantiate(brickPrefab, spawnPos, Quaternion.identity);
                bricks.Add(brick);
            }
        }
    }
    public void RemoveBrick(Bricks brick)
    {
        bricks.Remove(brick.gameObject);
        if (bricks.Count == 0)
            ResetLevel();
    }
}
