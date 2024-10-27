using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _rows, _cols;
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private Transform _cam;


    private Dictionary<Vector2, Tile> _tiles;

    void Start() {
        GenerateGrid();
    }

    void GenerateGrid() {
        float tile_size = 1.35f;

        _tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < _cols; x++) {
            for (int y = 0; y < _rows; y++) {
                float x_pos = x * tile_size;
                float y_pos = y * tile_size;

                bool isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x_pos, y_pos), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";

                spawnedTile.Init(isOffset);
                
                _tiles[new Vector2(x, y)] = spawnedTile;
            }
        }
    }

    public Tile GetTileAtPosition(Vector2 pos) {
        if (_tiles.TryGetValue(pos, out var tile)) {
            return tile;
        }
        return null;
    }
}
