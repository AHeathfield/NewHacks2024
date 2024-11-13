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

         // Set _highlight layer order
        _highlight.GetComponent<SpriteRenderer>().sortingOrder = 2;
        
    }

    void OnMouseEnter() 
    {
        _highlight.SetActive(true);
        MenuManager.Instance.ShowTileInfo(this);
    }

    void OnMouseExit() 
    {
        _highlight.SetActive(false);
        MenuManager.Instance.ShowTileInfo(null);
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


    // When user clicks on a tile
    // CODE IS REDUNDANT, should split into diff methods like attack(), selectPiece()
    void OnMouseDown(){
        if (GameManager.Instance.State != GameState.BlackTurn && GameManager.Instance.State != GameState.WhiteTurn) return;

        //For BLACK Turn
        if (GameManager.Instance.State == GameState.BlackTurn) {
            if (OccupiedUnit != null){
                // Sets the selected piece
                if (OccupiedUnit.Side == Side.Black) { //If the piece we're looking at is a black piece:
                    //Set the selected piece for the unit manager instance to the piece on the current tile that the mouse is down on
                    UnitManager.Instance.SetSelectedPiece(OccupiedUnit);
                }

                // Attack
                else {
                    if (UnitManager.Instance.SelectedPiece != null) {
                        var white = (BaseWhite) OccupiedUnit;
                        //We can change this to an attack funciton Ex: UnitManager.Instance.Attack();
                        Destroy(white.gameObject);
                        UnitManager.Instance.SetSelectedPiece(null);

                        //NEED TO MAKE GAMESTATE WHITE TURN HERE!
                        GameManager.Instance.State = GameState.WhiteTurn;
                    }
                }
            }
            // This means we already have a selected Unit and the tile we clicked is empty, therefore we move the piece there
            else {
                // This checks if something is selected
                if (UnitManager.Instance.SelectedPiece != null){
                    // Need to add logic to make sure the piece can only move within its range
                    SetUnit(UnitManager.Instance.SelectedPiece);
                    UnitManager.Instance.SetSelectedPiece(null);
                    
                    // NEED TO MAKE GAMESTATE WHITE TURN!
                    GameManager.Instance.State = GameState.WhiteTurn;
                }
            }
        }   

        // For WHITE Turn
        else {
            if (OccupiedUnit != null){
                // Sets the selected piece
                if (OccupiedUnit.Side == Side.White) { //If the piece we're looking at is a black piece:
                    //Set the selected piece for the unit manager instance to the piece on the current tile that the mouse is down on
                    UnitManager.Instance.SetSelectedPiece(OccupiedUnit);
                }

                // Attack
                else {
                    if (UnitManager.Instance.SelectedPiece != null) {
                        var black = (BaseBlack) OccupiedUnit;
                        //We can change this to an attack funciton Ex: UnitManager.Instance.Attack();
                        Destroy(black.gameObject);
                        UnitManager.Instance.SetSelectedPiece(null);

                        //NEED TO MAKE GAMESTATE BLACK TURN HERE!
                        GameManager.Instance.State = GameState.BlackTurn;
                    }
                }
            }
            // This means we already have a selected Unit and the tile we clicked is empty, therefore we move the piece there
            else {
                // This checks if something is selected
                if (UnitManager.Instance.SelectedPiece != null){
                    // Need to add logic to make sure the piece can only move within its range
                    SetUnit(UnitManager.Instance.SelectedPiece);
                    UnitManager.Instance.SetSelectedPiece(null);
                    
                    // NEED TO MAKE GAMESTATE BLACK TURN!
                    GameManager.Instance.State = GameState.BlackTurn;
                }
            }
        }

    }
}
