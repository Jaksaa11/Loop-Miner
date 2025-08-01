using UnityEditor;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public static GridGenerator instance;
    [SerializeField] private int width;
    [SerializeField] private int height;
    private float tilesizeX = 1.014454f;
    private float tilesizeY = 1f;
    [SerializeField] private GameObject[] blockPrefabs;
    private GameObject[,] gridBlocks;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        ResetGrid();
    }
    private void GenerateGrid()
    {
        gridBlocks = new GameObject[height,width];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Vector3 spawnPos = new Vector3(transform.position.x + (x * tilesizeX), transform.position.y - (y * tilesizeY), 0);
                GameObject usePrefab = GetRandomBlock();
                GameObject block = Instantiate(usePrefab,spawnPos,Quaternion.identity,transform);
                gridBlocks[y,x] = block;
               
            }
        }
    }

    private GameObject GetRandomBlock()
    {
        int r = Random.Range(0,blockPrefabs.Length);
        return blockPrefabs[r];
    }

    public void ClearGrid()
    {
        if (gridBlocks == null) return;
        foreach (GameObject go in gridBlocks)
        {
            if(go != null)
                Destroy(go);
        }
    }
    public void ResetGrid()
    {
        ClearGrid();
        GenerateGrid();
    }
}
