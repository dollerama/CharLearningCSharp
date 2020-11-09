using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shapes;

public class perlinGen : MonoBehaviour
{
    public List<GameObject> tiles;
    public GameObject tile;

    public float threshhold;
    public Vector3 offset;
    public Vector2 perlinOffset;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Gen");
    }

    IEnumerator Gen()
    {
        Vector3 pos = offset;
        perlinOffset.x = Random.Range(0, 50);
        perlinOffset.y = Random.Range(0, 50);

        for (int i = 0; i < 60; i++)
        {
            for (int j = 0; j < 100; j++)
            {
                float p = Mathf.PerlinNoise((i + perlinOffset.y) / 20.0f, (j + perlinOffset.x) / 20.0f);

                Debug.Log(p);

                GameObject t = Instantiate(tile, pos, Quaternion.identity);
                t.GetComponent<animTile>().animate = false;
                t.GetComponent<Rectangle>().Color = new Color(1 - p + (Mathf.Sin(pos.y * .25f)), p, 1 - p, p);

                tiles.Add(t);
                pos.x += .5f;


            }
            pos.x = offset.x;
            pos.y -= .5f;

            yield return new WaitForEndOfFrame();
        }

        foreach (GameObject g in tiles)
        {
            g.GetComponent<animTile>().animate = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
