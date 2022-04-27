using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
	public static TimerManager Singleton {get; private set;}
	public List<Timer> timers = new List<Timer>();

	void Awake() {
		if (Singleton && Singleton != this) {
			Destroy(this);
		} else {
			Singleton = this;
		}
	}

	void FixedUpdate()
	{
		float delta = Time.deltaTime;
		int len = timers.Count;

		for (int i = 0; i < len; i++) {
			Timer timer = timers[i];
			if (!timer.isRunning) continue;

			timer.currentTime += delta;
			if (timer.currentTime < timer.length) continue;

			timer.timeOut.Invoke();

			if (timer.loop) {
				timer.currentTime -= timer.length;
				continue;
			} 

			timer.Stop();
		}
	}

	public void Add(Timer timer) {
		timers.Add(timer);
	}
}