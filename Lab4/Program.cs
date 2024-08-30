using System.Runtime.InteropServices;
using System.Text;
using Core;

[DllImport("kernel32.dll", ExactSpelling = true)]
static extern IntPtr GetConsoleWindow();
[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);


const int MAXIMMAZE_WND = 3;
const int UPDATE_INTERVAL_MS = 50;
const float DELTA_TIME = 1f / (1000f / UPDATE_INTERVAL_MS);
float gasValue = 0f;
ConsoleKey currentKey;
TurnSignals turns;
Tachometer tachometer;
Speedometer speedometer;



//app framework
Init();
do
{
    Update();
    Thread.Sleep(UPDATE_INTERVAL_MS);
} while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape));

ExitApp();




void Init()
{
    Console.OutputEncoding = Encoding.UTF8;

    //maximaze console wnd
    IntPtr thisConsl = GetConsoleWindow();
    ShowWindow(thisConsl, MAXIMMAZE_WND);

    turns = new TurnSignals();

    tachometer = new Tachometer((int)(Console.WindowWidth * .25f), Console.WindowHeight / 2);
    speedometer = new Speedometer((int)(Console.WindowWidth * .75f), Console.WindowHeight / 2);
    tachometer.DrawPanel(5, 120);
    speedometer.DrawPanel(10, 180);
}

void Update()
{
    KeyInput();

    GasBehavior();
    TurnsBehavior();

    turns.Update();
    tachometer.Update(gasValue);
    speedometer.Update(gasValue);
}

void KeyInput()
{
    currentKey = (Console.KeyAvailable) ?
        Console.ReadKey(true).Key : ConsoleKey.Multiply;
}

void GasBehavior()
{
    if (currentKey == ConsoleKey.Spacebar
        && gasValue <= Indicators.DEFAULT_PANEL_WIDTH - DELTA_TIME)
        gasValue += DELTA_TIME;
    else if (gasValue >= DELTA_TIME)
        gasValue -= DELTA_TIME;
}

void TurnsBehavior()
{
    switch (currentKey)
    {
        case ConsoleKey.LeftArrow:
            turns.SetTurn(TurnSignals.Turn_State.LEFT);
            break;
        case ConsoleKey.RightArrow:
            turns.SetTurn(TurnSignals.Turn_State.RIGHT);
            break;
        case ConsoleKey.DownArrow:
            turns.SetTurn(TurnSignals.Turn_State.NONE);
            break;
    }
}

void ExitApp()
{
    Console.WriteLine("Exit...");
}