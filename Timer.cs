using UnityEngine.Events;

public class Timer {
	public float length = 1;
	public bool loop = false;
	public UnityEvent timeOut = new UnityEvent();
	public float currentTime = 0;

	bool paused = false;
	bool isRunning = false;
	int managerIndex;

	public Timer(float l) {
		length = l;
	}

	public void Start() {
		currentTime = 0;
		paused = false;
		AddToManager();
	}

	public void Stop() {
		currentTime = 0;
		paused = false;
		RemoveFromManager();
	}

	public void Pause() {
		if (isRunning) {
			paused = true;
			RemoveFromManager();
		}
	}

	public void Unpause(){
		if (paused) {
			paused = false;
			AddToManager();
		}
	}

	public bool IsRunning() {
		return isRunning;
	}

	public float Progress() {
		return currentTime / length;
	}

	void AddToManager() {
		managerIndex = TimerManager.Singleton.Add(this);
		isRunning = true;
	}

	void RemoveFromManager() {
		TimerManager.Singleton.Remove(managerIndex);
		isRunning = false;
	}
}