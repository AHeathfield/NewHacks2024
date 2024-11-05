using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
	public static UnitManager Instance;

	private List<ScriptableUnit> _units;

	public BaseBlack SelectedBlack;

	public BaseWhite SelectedWhite;

	void Awake()
	{
		Instance = this;

		_units = Resources.LoadAll<ScriptableUnit>("Units").ToList();
	}

	public void SpawnBlacks()
	{
		var blackCount = 1;

		for (int i = 0; i < blackCount; i++) {
			// A random black piece
			var randomPrefab = GetRandomUnit<BaseBlack>(Side.Black);
			var spawnedBlack = Instantiate(randomPrefab);
			var randomSpawnedTile = GridManager.Instance.GetBlackSpawnTile();

			randomSpawnedTile.SetUnit(spawnedBlack); // Sets the position of the black piece
		}

		GameManager.Instance.UpdateGameState(GameState.SpawnWhites);
	}

	public void SpawnWhites()
	{
		var whiteCount = 1;

		for (int i = 0; i < whiteCount; i++) { //For every white piece we want to spawn:
			// A random white piece
			var randomPrefab = GetRandomUnit<BaseWhite>(Side.White);
			var spawnedWhite = Instantiate(randomPrefab);
			var randomSpawnedTile = GridManager.Instance.GetWhiteSpawnTile();

			randomSpawnedTile.SetUnit(spawnedWhite); // Sets the position of the black piece
		}

		GameManager.Instance.UpdateGameState(GameState.BlackTurn);
	}

	// If we want to pick a random piece from selection
	private T GetRandomUnit<T>(Side side) where T : BaseUnit {
		// Going through all the units where the units are either black or white and we are ordering the units randomly and then returning the first units prefab
		return (T)_units.Where(u => u.Side == side).OrderBy(o => Random.value).First().UnitPrefab;
	}

	public void SetSelectedBlack(BaseBlack blackPiece){
		SelectedBlack = blackPiece;

		MenuManager.Instance.ShowSelectedBlack(blackPiece);
		
	}

}
