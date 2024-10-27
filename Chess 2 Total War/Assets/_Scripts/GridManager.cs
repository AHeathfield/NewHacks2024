using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _rows, _cols;
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private Piece _piecePrefab;
    [SerializeField] private Transform _cam;


    private Dictionary<Tile, Vector2> _tiles; //Tile can get us [r,c], Vector2 is where it actually is on screen
    private Dictionary<Tile, Piece> _pieces;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid() 
    {
        float tile_size = 1.35f;

        _tiles = new Dictionary<Tile, Vector2>();
        for (int x = 0; x < _cols; x++) {
            for (int y = 0; y < _rows; y++) {
                float x_pos = x * tile_size;
                float y_pos = y * tile_size;

                bool isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x_pos, y_pos), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";

                spawnedTile.Init(isOffset, x, y);
                
                _tiles[spawnedTile] = new Vector2(x, y);
            }
        }
    }

    void SetPiecesUp() {
        _pieces = new Dictionary<Tile, Piece>();
        // var pawn1 = Instantiate(_piecePrefab, )
    }

    
}
