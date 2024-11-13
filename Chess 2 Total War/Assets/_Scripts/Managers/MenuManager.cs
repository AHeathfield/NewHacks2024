using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    [SerializeField] private GameObject _selectedPieceObject, _tileUnitObject; //_selectedBlackObject

    void Awake(){
        Instance = this;
    }

    public void ShowTileInfo(Tile tile){
        if (tile == null){
            _tileUnitObject.SetActive(false);
            return;
        }
        
        if (tile.OccupiedUnit) {
            _tileUnitObject.GetComponentInChildren<TMP_Text>().text = "Unit:\n" + tile.OccupiedUnit.UnitName;
            _tileUnitObject.SetActive(true);
        }
    }

    // public void ShowSelectedBlack(BaseBlack black){

    //    if (black == null){
    //         _selectedBlackObject.SetActive(false);
    //         return;
    //    }
       
    //     _selectedBlackObject.GetComponentInChildren<TMP_Text>().text = "Selected:\n" + black.UnitName;
    //     _selectedBlackObject.SetActive(true);
    // }


    public void ShowSelectedPiece(BaseUnit piece){

       if (piece == null){
            _selectedPieceObject.SetActive(false);
            return;
       }
       
        _selectedPieceObject.GetComponentInChildren<TMP_Text>().text = "Selected:\n" + piece.UnitName;
        _selectedPieceObject.SetActive(true);
    }
}
