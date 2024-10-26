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
    [SerializeField] private Sprite sprite;
    [SerializeField] private Vector2 tilePosition;
    [SerializeField] private Vector2 pieceSize;

    [SerializeField] private PieceType type;

    public Vector2 GetTilePosition()
    {
        return tilePosition;
    }

    public PieceType GetPieceType()
    {
        return type;
    }
}
