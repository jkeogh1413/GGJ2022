using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TreeSpawner : MonoBehaviour
{
    public Tilemap tilemap;
    public GameObject[] trees;
    public int treesToSpawn = 8;
    List<Vector3> tileWorldLocations;

    static TreeSpawner instance;

    private void Awake() {
        instance = this;
        tileWorldLocations = new List<Vector3>();

        tilemap.CompressBounds();
        BoundsInt bounds = tilemap.cellBounds;
        for (int x = bounds.min.x; x < bounds.max.x; x++) {
            for (int y = bounds.min.y; y < bounds.max.y; y++) {
                Vector3Int cellPos = new Vector3Int(x, y, 0);
                var sprite = tilemap.GetSprite(cellPos);
                var tile = tilemap.GetTile(cellPos);
                if (sprite && tile) {
                    tileWorldLocations.Add(tilemap.CellToWorld(cellPos));
                }
            }
        }

    }

    public static void SpawnNewTrees() {
        if (instance != null)
            instance.StartCoroutine(instance.spawnTrees());
    }

    IEnumerator spawnTrees() {
        int treesSpawned = 0;
        while (treesSpawned < treesToSpawn) {
            // Pick random tile
            Vector3 pos = tileWorldLocations[Random.Range(0, tileWorldLocations.Count)];

            // Pick random tree
            GameObject tree = Instantiate(trees[Random.Range(0, trees.Length)]);
            tree.transform.position = pos;
            tree.transform.SetParent(transform);
            treesSpawned++;
            yield return null;
        }
    }
}
