using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
	public static UnitManager Instance;

	private List<ScriptableUnit> _units;

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
	}

	// If we want to pick a random piece from selection
	private T GetRandomUnit<T>(Side side) where T : BaseUnit {
		// Going through all the units where the units are either black or white and we are ordering the units randomly and then returning the first units prefab
		return (T)_units.Where(u => u.Side == side).OrderBy(o => Random.value).First().UnitPrefab;
	}
}
