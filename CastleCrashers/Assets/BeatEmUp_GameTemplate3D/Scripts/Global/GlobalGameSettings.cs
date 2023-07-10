using UnityEngine;
using System.Collections.Generic;

public static class GlobalGameSettings  {
	public static bool Coop;
	public static GameObject Player1Prefab;
	public static GameObject Player2Prefab;
	public static List<LevelData> LevelData = new List<global::LevelData>();
	public static int currentLevelId = 0;
}