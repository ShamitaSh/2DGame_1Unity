using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour
{

	float totalSeconds = 0;

	// timer execution
	float elapsedSeconds = 0;
	bool running = false;

	// support for Finished property
	bool started = false;


	/// <summary>
	/// Sets the duration of the timer
	/// The duration can only be set if the timer isn't currently running
	/// </summary>
	/// <value>duration</value>
	public float Duration
	{
		set
		{
			if (!running)
			{
				totalSeconds = value;
			}
		}
	}

	/// <summary>
	/// Gets whether or not the timer has finished running
	/// This property returns false if the timer has never been started
	/// </summary>
	/// <value>true if finished; otherwise, false.</value>
	public bool Finished
	{
		get { return started && !running; }
	}

	/// <summary>
	/// Gets whether or not the timer is currently running
	/// </summary>
	/// <value>true if running; otherwise, false.</value>
	public bool Running
	{
		get { return running; }
	}

    // Update is called once per frame
    void Update()
    {
		if (running)
		{
			elapsedSeconds += Time.deltaTime;
			if (elapsedSeconds >= totalSeconds)
			{
				running = false;
			}
		}

	}


	public void Run()
	{
		// only run with valid duration
		if (totalSeconds > 0)
		{
			started = true;
			running = true;
			elapsedSeconds = 0;
		}
	}

}
