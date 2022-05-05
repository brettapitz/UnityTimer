# UnityTimer
A simple timer implementation in Unity

## Usage
Place TimerManager.cs on a GameObject in your Scene and pass a callback function to __timer.timeOut.AddListener()__

## Design
A new Timer adds itself to TimerManager.Singleton, which updates all timers in a single Update call. A Stopped timer is removed from the manager.

To keep removal quick, instead of List.Remove, the index is nulled and added to a stack of free indices. The Add method checks for free slots before pushing to the List.

Not inheriting from MonoBehaviour means no OnDestroy or OnDisable method, so looping Timers have to be explicitly stopped by their callers or they'll run forever.

The API's simple: 
  - __Start__ zeros the timer, and runs it if it's not already running
  - __Stop__ zeros and stops the timer if it's running or paused
  - __Pause__ stops the timer and marks it paused, but does not zero it
  - __Unpause__ starts the timer without zeroing it, but only if it's marked paused. Note that __Start__ and __Stop__ both unmark paused.
    - Having both __Start/Stop__ and __Pause/Unpause__ lets you choose whether or not an object's timer is reset (for example, if it's disabled and later re-enabled).
  - __Progress__ returns a number between 0 and 1 representing what percentage of the timer has passed (useful for Lerps)
  - __IsRunning__ returns true if the timer is running, false otherwise
