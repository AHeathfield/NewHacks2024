using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;
    [SerializeField] private int _col;
    [SerializeField] private int _row;
    

    public void Init(bool isOffset, int col, int row) 
    {
        _renderer.color = isOffset ? _offsetColor : _baseColor;
        _col = col;
        _row = row;
    }

    public int GetTileColumn() 
    {
        return _col;
    }

    public int GetTileRow() 
    {
        return _row;
    }

    void OnMouseEnter() 
    {
        _highlight.SetActive(true);
    }

    void OnMouseExit() 
    {
        _highlight.SetActive(false);
    }
}
