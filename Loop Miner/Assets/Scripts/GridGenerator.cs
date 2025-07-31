using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    private  int width = 7;
    private  int height = 10;
    private float tilesizeX = 1.014454f;
    private float tilesizeY = 1f;
    [SerializeField] private GameObject[] blockPrefabs;
    private GameObject[,] gridBlocks;

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
