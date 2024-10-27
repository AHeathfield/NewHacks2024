using UnityEngine;

public enum PieceType
{
    Pawn,
    Knight,
    Bishop,
    Samurai
}

public class Piece : MonoBehaviour
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private PieceType _type;
    [SerializeField] private int _pieceCol;
    [SerializeField] private int _pieceRow;


    public void Init(Sprite sprite, PieceType type, int pieceCol, int pieceRow)
    {
        _sprite = sprite;
        _type = type;
        _pieceCol = pieceCol;
        _pieceRow = pieceRow;
    }

    // Getters
    public int GetPieceColumn()
    {
        return _pieceCol;
    }
    public int GetPieceRow() 
    {
        return _pieceRow;
    }
    public PieceType GetPieceType()
    {
        return _type;
    }
}
