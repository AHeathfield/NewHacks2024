using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    [SerializeField] private GameObject _selectedBlackObject, _tileUnitObject;

    void Awake(){
        Instance = this;
    }

    public void ShowTileInfo(Tile tile){
        if (tile == null){
            _tileUnitObject.SetActive(false);
            return;
        }
        
        if (tile.OccupiedUnit) {
            _tileUnitObject.GetComponentInChildren<Text>().text = tile.OccupiedUnit.UnitName;
            _tileUnitObject.SetActive(true);
        }
    }

    public void ShowSelectedBlack(BaseBlack black){

       if (black == null){
            _selectedBlackObject.SetActive(false);
            return;
       }
       
        _selectedBlackObject.GetComponentInChildren<Text>().text = black.UnitName;
        _selectedBlackObject.SetActive(true);
    }
}
