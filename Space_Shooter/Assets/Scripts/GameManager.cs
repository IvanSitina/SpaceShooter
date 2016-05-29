using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public GameObject playButton;
    public GameObject playerShip;
    public GameObject enemySpawner;
    public GameObject gameOverGO;
    public GameObject scoreUITextGO;

    public enum GameManagerState
    {
        Opening,
        Gameplay,
        GameOver,
    }
    GameManagerState GMState;
	// Use this for initialization
	void Start () {
	    GMState = GameManagerState.Opening;
	}

    void UpdateGameManagerState()
    {
        switch(GMState)
        {
            case GameManagerState.Opening:
                playButton.SetActive(true);
                gameOverGO.SetActive(false);
                break;
            case GameManagerState.Gameplay:
                scoreUITextGO.GetComponent<GameScore>().Score = 0;
                playButton.SetActive(false);
                playerShip.GetComponent<PlayerContorl>().Init();
                enemySpawner.GetComponent<EnemySpawner>().ScheduleEnemySpawner();
                break;
            case GameManagerState.GameOver:
                enemySpawner.GetComponent<EnemySpawner>().UnscheduleEnemySpawner();
                gameOverGO.SetActive(true);
                Invoke("ChangeToOpeningState", 3f);
                break;
        }
    }

    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState();
    }

    public void StartGamePlay()
    {
        GMState = GameManagerState.Gameplay;
        UpdateGameManagerState();
    }

    public void ChangeToOpeningState()
    {
        SetGameManagerState(GameManagerState.Opening);
    }
}
