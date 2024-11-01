using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;
    [SerializeField] private int _rows, _cols;
    [SerializeField] private Tile _tilePrefab;

    [SerializeField] private Transform _cam;


    private Dictionary<Vector2, Tile> _tiles;
    // private Dictionary<Tile, Piece> _pieces;

    void Awake()
    {
        Instance = this;
    }
    // void Start()
    // {
    //     GenerateGrid();
    //     SetPiecesUp();
    // }

    public void GenerateGrid() 
    {
        float tile_size = 1.35f;

        _tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < _cols; x++) {
            for (int y = 0; y < _rows; y++) {
                float x_pos = x * tile_size;
                float y_pos = y * tile_size;

                bool isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x_pos, y_pos), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";

                spawnedTile.Init(isOffset, x, y);
                
                _tiles[new Vector2(x, y)] = spawnedTile;
            }
        }
        GameManager.Instance.UpdateGameState(GameState.SpawnBlacks);
    }


    public Tile GetBlackSpawnTile() {
        // Goes through tiles dict and the looks for tiles that y value is less than half the rows, then orders them randomly and then takes first value.
        return _tiles.Where(t => t.Key.y < _rows/4 && t.Value.Walkable).OrderBy(tag => Random.value).First().Value;
    }

    public Tile GetWhiteSpawnTile() {
        // Goes through tiles dict and the looks for tiles that y value is less than half the rows, then orders them randomly and then takes first value.
        return _tiles.Where(t => t.Key.y > _rows/4 && t.Value.Walkable).OrderBy(tag => Random.value).First().Value;
    }
}
