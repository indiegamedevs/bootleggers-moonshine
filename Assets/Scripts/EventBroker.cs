using System;

public class EventBroker 
{
    public static event Action StartElevator;

    public static event Action StopElevator;

    public static event Action EnterCutscene;

    public static event Action ExitCutscene;

    public static void CallStartElevator()
    {
        if (StartElevator != null)
        {           
            StartElevator();
        }
    }


    public static void CallStopElevator()
    {
        if (StopElevator != null)
        {
            StopElevator();
        }
    }

    public static void CallEnterCutscene()
    {
        if(EnterCutscene != null)
        {
            EnterCutscene();
        }
    }

    public static void CallExitCutscene()
    {
        if (ExitCutscene != null)
        {
            ExitCutscene();
        }
    }

}
