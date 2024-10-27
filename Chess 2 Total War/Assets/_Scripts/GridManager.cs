using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _rows, _cols;
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private GameObject whiteBishop1;
    [SerializeField] private GameObject[] _whitePawns = new GameObject[8];
    [SerializeField] private GameObject[] _blackPawns = new GameObject[8];
    [SerializeField] private Transform _cam;


    // private Dictionary<Tile, Vector3> _tiles; //Tile can get us [r,c], Vector2 is where it actually is on screen
    // private Dictionary<Tile, Piece> _pieces;

    void Start()
    {
        GenerateGrid();
        SetPiecesUp();
    }

    void GenerateGrid() 
    {
        float tile_size = 1.35f;

        // _tiles = new Dictionary<Tile, Vector3>();
        for (int x = 0; x < _cols; x++) {
            for (int y = 0; y < _rows; y++) {
                float x_pos = x * tile_size;
                float y_pos = y * tile_size;

                bool isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x_pos, y_pos), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";

                spawnedTile.Init(isOffset, x, y);
                
                // _tiles[spawnedTile] = new Vector3(x, y);
            }
        }
    }

    private Vector3 convertRowColToVector(int col, int row)
    {
        return new Vector3(col*1.35f, row*1.35f);
    }

    void SetPiecesUp() {
        // White Pawns
        for (int i = 0; i < _whitePawns.Length; i++) {
            MovePiece(_whitePawns[i], convertRowColToVector(i,1));
        }

        // Black Pawns
        for (int i = 0; i < _blackPawns.Length; i++) {
            MovePiece(_blackPawns[i], convertRowColToVector(i,6));
        }
    }

     private void MovePiece(GameObject piece, Vector3 newPosition)
    {
        if (piece != null)
        {
            piece.transform.position = newPosition;
            Debug.Log($"Pawn moved to position: {newPosition}");
        }
        else
        {
            Debug.LogError("Pawn GameObject reference is missing!");
        }
    }

    
}
