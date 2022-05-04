using UnityEngine.Events;

public class Timer
{
	public float length = 1;
	public bool loop = false;
	public UnityEvent timeOut = new UnityEvent();
	public float currentTime = 0;
	public bool isRunning;

	bool isManaged = false;
	int managerIndex;

	public Timer(float l) {
		length = l;
	}

	public void Start() {
		if (!isManaged) {
			managerIndex = TimerManager.Singleton.Add(this);
			isManaged = true;
		}
		isRunning = true;
		currentTime = 0;
	}

	public void Stop() {
		TimerManager.Singleton.Remove(managerIndex);
		currentTime = 0;
		isRunning = false;
		isManaged = false;
	}

	public float Progress() {
		return currentTime / length;
	}
}