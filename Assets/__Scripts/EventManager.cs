using UnityEngine;
using UnityEngine.Events;
using System;

public static class EventManager
{
    //This class serves as a centralized hub for managing events in the game. It allows different parts of the game to subscribe to and trigger events without needing direct references to each other, promoting loose coupling and modularity.
    //The following code is related to a timer system, where different components can listen for when the timer starts, stops, or updates. Additionally, it includes an event for when an enemy is killed. 

    //A1 This section defines a static event called TimerStart, which will allow the game to notify and show when the timer starts
    public static event UnityAction TimerStart;
    public static event UnityAction TimerStop;
    public static event UnityAction<float> TimerUpdate;

    public static void OnTimerStart() => TimerStart?.Invoke();
    public static void OnTimerStop() => TimerStop?.Invoke();

    public static void OnTimerUpdate(float value) => TimerUpdate?.Invoke(value);

    //B1 This section defines a static event called EnemyKilled, which will allow the game to notify when an enemy is killed. This can be used to trigger score updates, play sound effects, or spawn new enemies.
    public static event Action EnemyKilled;
    public static void OnEnemyKilled() => EnemyKilled?.Invoke();

    //C1 This sections defines a static eventy called ShieldCount. This event can be used to notify when the player's shield count changes, allowing UI elements to update accordingly. It takes an integer parameter representing the new shield count.
    public static event Action<int,int> ShieldCount; // Current shield count and maximum shield count

    public static void OnShieldCount(int current,int max)
        => ShieldCount?.Invoke(current,max);




}