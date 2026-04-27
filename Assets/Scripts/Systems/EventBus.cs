using System;

    //Observer pattern
public static class EventBus
{
    public static Action<char> OnCorrectLetter;
    public static Action<char> OnWrongLetter;

    public static Action OnGameWon;
    public static Action OnGameLost;
}
