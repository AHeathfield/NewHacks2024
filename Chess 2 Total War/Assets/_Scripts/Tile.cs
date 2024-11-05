using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;
    [SerializeField] private bool _isWalkable;
    public BaseUnit OccupiedUnit;
    public bool Walkable => _isWalkable && OccupiedUnit == null;

    [SerializeField] private int _col;
    [SerializeField] private int _row;
    

    public void Init(bool isOffset, int col, int row) 
    {
        _renderer.color = isOffset ? _offsetColor : _baseColor;
        _renderer.sortingOrder = 1;
        _col = col;
        _row = row;
    }

    void OnMouseEnter() 
    {
        _highlight.SetActive(true);
    }

    void OnMouseExit() 
    {
        _highlight.SetActive(false);
    }

    // This basically sets the position of a unit
    public void SetUnit(BaseUnit unit) {
        // When a piece moves the tile it was on, is now going to be null
        if (unit.OccupiedTile != null) {
            unit.OccupiedTile.OccupiedUnit = null;
        }
        // Moves a piece to a new position
        unit.transform.position = transform.position;
        OccupiedUnit = unit; //Basically lets know there now is a unit there
        unit.OccupiedTile = this;
    }

    void OnMouseDown(){
        if (GameManager.Instance.State != GameState.BlackTurn) return;

        if (OccupiedUnit != null){
            if (OccupiedUnit.Side == Side.Black) { //If the piece we're looking at is a black piece:
                //Set the selected piece for the unit manager instance to the piece on the current tile that the mouse is down on
                UnitManager.Instance.SetSelectedBlack((BaseBlack)OccupiedUnit);
            }
            else {
                if (UnitManager.Instance.SelectedBlack != null) {

                }
            }

        }
    }
}
