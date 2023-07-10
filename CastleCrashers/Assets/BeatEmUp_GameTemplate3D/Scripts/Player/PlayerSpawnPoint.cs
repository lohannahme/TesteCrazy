using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour {

	public GameObject defaultPlayerPrefab;

	void Awake(){

		//get selected player from character selection screen
		if(GlobalGameSettings.Player1Prefab) {
			loadPlayer(GlobalGameSettings.Player1Prefab);
			//return;
		}

        if (GlobalGameSettings.Coop)
        {
			loadPlayer2(GlobalGameSettings.Player2Prefab);
        }

		//otherwise load default character
		//if(defaultPlayerPrefab) {
		//	loadPlayer(defaultPlayerPrefab);
		//} else {
		//	Debug.Log("Please assign a default player prefab in the  playerSpawnPoint");
		//}
	}

	//load a player prefab
	void loadPlayer(GameObject playerPrefab){
		GameObject player = GameObject.Instantiate(playerPrefab) as GameObject;
		player.transform.position = transform.position ;
	}

	void loadPlayer2(GameObject playerPrefab)
    {
		GameObject player = GameObject.Instantiate(playerPrefab) as GameObject;
		player.GetComponent<PlayerMovement>().IsPlayerTwo = true;
		player.GetComponent<HealthSystem>().IsPlayerTwo = true;
		player.GetComponent<PlayerCombat>().IsPlayerTwo = true;
		player.transform.position = transform.position + new Vector3(0,0, -3);
	}
}