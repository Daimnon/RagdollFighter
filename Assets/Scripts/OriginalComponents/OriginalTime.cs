using System;

public static class OriginalTime
{
    #region Fields
    static float _deltaTime = DeltaTimeAsFloat();
    static bool _freezeGame = false;
    #endregion

    #region Properties
    static public float DeltaTime => _deltaTime;
    static public bool FreezeGame { get => _freezeGame; set => _freezeGame = value; }
    #endregion

    #region Methods
    public static void DeltaTimeAsDateTime()
    {
        DateTime time1 = DateTime.Now;
        DateTime time2 = DateTime.Now;

        while (true)
        {
            time2 = DateTime.Now;
            float deltaTime = (time2.Ticks - time1.Ticks) / 10000000f;
            Console.WriteLine(deltaTime);
            Console.WriteLine(time2.Ticks - time1.Ticks);
            time1 = time2;
        }
    }

    public static float DeltaTimeAsFloat()
    {
        DateTime time1 = DateTime.Now;
        DateTime time2 = DateTime.Now;

        while (true)
        {
            time2 = DateTime.Now;
            float deltaTime = (time2.Ticks - time1.Ticks) / 10000000f;
            return deltaTime;
        }
    }
    #endregion

    #region Timers
    public static void RestartTimer(float timer)
    {
        timer = 0;
        timer = timer + (1 * DeltaTime);
    }

    public static void ContinueTimer(float timer)
    {
        timer = timer + (1 * DeltaTime);
    }

    public static void StopTimer(float timer)
    {
        if (timer > 0)
        {
            float tempTimer = timer;
            timer = tempTimer;
        }
    }

    public static void ResetTimer(float timer)
    {
        if (timer > 0)
        {
            timer = 0;
        }
    }
    #endregion
}
