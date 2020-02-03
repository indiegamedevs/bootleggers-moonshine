using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float gameSpeed = 3f;

    [SerializeField] PlayableAsset[] playables;

    [SerializeField] GameObject[] elevators;
    

    PlayableDirector director;
    PlayerGrab playerGrab;

    int currentTimeLine = 0;
  
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        playerGrab = FindObjectOfType<PlayerGrab>();
        director = GetComponent<PlayableDirector>();
        gameSpeed = 3f;
    }

    public void ElevatorStart()
    {
        EventBroker.CallStartElevator();
    }

    public void ElevatorStop()
    {
        EventBroker.CallStopElevator();
    }

    public void EnterCutscene()
    {
        EventBroker.CallEnterCutscene();
    }

    public void ExitCutscene()
    {
        EventBroker.CallExitCutscene();
    }

    public void SwitchState()
    {
        switch (currentTimeLine)
        {
            case 0: director.playableAsset = playables[currentTimeLine];
                director.Play();
                currentTimeLine++;
                return;
            default: Debug.Log("State Machine done f@cked up");
                return;
        }
        
    }
    public void PlacedPiece()
    {
        playerGrab.Grab();
        Debug.Log("PlacedPiece");
        SwitchState();
    }
}
