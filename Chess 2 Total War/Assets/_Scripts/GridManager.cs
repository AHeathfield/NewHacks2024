using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _rows, _cols;
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private GameObject whiteKing;
    [SerializeField] private GameObject whiteQueen;
    [SerializeField] private GameObject whiteKnight;
    [SerializeField] private GameObject whiteRook1;
    [SerializeField] private GameObject whiteRook2;
    [SerializeField] private GameObject whiteRook3;
    [SerializeField] private GameObject whiteBishop1;
    [SerializeField] private GameObject whiteBishop2;
    [SerializeField] private GameObject[] _whitePawns = new GameObject[8];
    [SerializeField] private GameObject blackKing;
    [SerializeField] private GameObject blackQueen;
    [SerializeField] private GameObject blackKnight1;
    [SerializeField] private GameObject blackKnight2;
    [SerializeField] private GameObject blackKnight3;
    [SerializeField] private GameObject blackRook;
    [SerializeField] private GameObject blackBishop1;
    [SerializeField] private GameObject blackBishop2;
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

        // White pieces
        MovePiece(whiteBishop1, convertRowColToVector(1,0));
        MovePiece(whiteBishop2, convertRowColToVector(5,0));
        MovePiece(whiteKnight, convertRowColToVector(0,0));
        MovePiece(whiteRook1, convertRowColToVector(2,0));
        MovePiece(whiteRook2, convertRowColToVector(6,0));
        MovePiece(whiteRook3, convertRowColToVector(7,0));
        MovePiece(whiteQueen, convertRowColToVector(3,0));
        MovePiece(whiteKing, convertRowColToVector(4,0));

        // Black Pawns
        for (int i = 0; i < _blackPawns.Length; i++) {
            MovePiece(_blackPawns[i], convertRowColToVector(i,6));
        }

        // Black Pieces
        MovePiece(blackBishop1, convertRowColToVector(1,7));
        MovePiece(blackBishop2, convertRowColToVector(5,7));
        MovePiece(blackKnight1, convertRowColToVector(7,7));
        MovePiece(blackKnight2, convertRowColToVector(2,7));
        MovePiece(blackKnight3, convertRowColToVector(6,7));
        MovePiece(blackRook, convertRowColToVector(0,7));
        MovePiece(blackQueen, convertRowColToVector(4,7));
        MovePiece(blackKing, convertRowColToVector(3,7));
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
