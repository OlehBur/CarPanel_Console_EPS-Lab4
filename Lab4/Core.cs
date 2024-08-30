namespace Core
{
    public class Point
    {
        public int x { get; set; }
        public int y { get; set; }
    }

    public class Arrow
    {
        //float prev_direction = 0;
        //Point prev_center;
        //Point center;
        //int length;
        Point defaultPos = new Point();
        int prevProgress;
        int maxProgress;


        public Arrow(Point defaultPos, int maxProgress)
        {
            this.defaultPos = defaultPos;
            this.maxProgress = maxProgress;
            prevProgress = 0;
            //center = new Point
            //{
            //    x = Console.WindowWidth / 2,
            //    y = Console.WindowHeight / 2
            //};
        }

        public Arrow()
        {
            defaultPos.x = 0;
            defaultPos.y = 0;
            maxProgress = 1;
            prevProgress = 0;
        }

        //Point GetDirectionByDegress(float degress)
        //{
        //    return new Point
        //    {
        //        x = center.x + (int)(Math.Cos(degress * Math.PI / 180) * length),
        //        y = center.y + (int)(Math.Sin(degress * Math.PI / 180) * length)
        //    };
        //}

        //public void Update(float degress)
        //{
        //    Point prevEnd = GetDirectionByDegress(prev_direction);
        //    Point end = GetDirectionByDegress(degress);

        //    Draw(center, prevEnd, ' ');//clear
        //    Draw(center, end);

        //    prev_direction = degress;
        //}

        //void Draw(Point beg, Point end, char sym = '*')
        //{
        //    Point symPos;
        //    Point direct = new Point
        //    {
        //        x = end.x - beg.x,
        //        y = end.y - beg.y
        //    };

        //    for (int i = 0; i <= length; i++)
        //        for (int thick = -1; thick < 2; thick++)
        //        {
        //            symPos = new Point
        //            {
        //                x = beg.x + thick + (int)((float)i / length * direct.x),
        //                y = beg.y + thick + (int)((float)i / length * direct.y)
        //            };

        //            Console.SetCursorPosition(symPos.x, symPos.y);
        //            Console.Write(sym);
        //        }
        //}
        public void Draw(int progressPos, bool isClear = false)
        {
            const char ARROW_TOP = '¦';
            const char ARRIW_BOTTOM = '‖';

            Console.SetCursorPosition(progressPos + defaultPos.x, defaultPos.y);
            if (isClear)
            {
                Console.WriteLine(' ');
                Console.SetCursorPosition(progressPos + defaultPos.x, Console.CursorTop);
                Console.WriteLine(' ');
            }
            else
            {
                Console.WriteLine(ARROW_TOP);
                Console.SetCursorPosition(progressPos + defaultPos.x, Console.CursorTop);
                Console.WriteLine(ARRIW_BOTTOM);
            }
        }

        public void Update(int progressPosition)
        {
            //int deltaProgress = (int)(Math.Abs(progressPosition - prevProgress) 
            //    * ((progressPosition > prevProgress) ? 1 : -1));
            //progressPosition += deltaProgress;
            progressPosition = Math.Clamp(progressPosition, 0, maxProgress);

            Draw(prevProgress, true);//clear
            Draw(progressPosition);

            prevProgress = progressPosition;
        }

        public int GetProgress()
        {
            return prevProgress;
        }

        public int GetMaxProgress()
        {
            return maxProgress;
        }
    }

    public class TurnSignals
    {
        public enum Turn_State { NONE, LEFT, RIGHT };
        public static readonly int ARROW_LENGTH = 60,
            ARROW_HEIGHT = 11;

        const string leftTurnDisable = "                  ████                                    \r\n              ████▒▒██                                    \r\n          ████▒▒▒▒▒▒██                                    \r\n      ████▒▒▒▒▒▒▒▒▒▒██████████████████████████████████████\r\n  ████▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██\r\n██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██\r\n  ████▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██\r\n      ████▒▒▒▒▒▒▒▒▒▒██████████████████████████████████████\r\n          ████▒▒▒▒▒▒██                                    \r\n              ████▒▒██                                    \r\n                  ████                                    \r\n",
            leftTurn = "🏻🏻🏻🏻🏻🏻🏻🏻🏻🏿🏿🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻\r\n🏻🏻🏻🏻🏻🏻🏻🏿🏿🏽🏿🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻\r\n🏻🏻🏻🏻🏻🏿🏿🏽🏽🏽🏿🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻\r\n🏻🏻🏻🏿🏿🏽🏽🏽🏽🏽🏿🏿🏿🏿🏿🏿🏿🏿🏿🏿🏿🏿🏿🏿🏿🏿🏿🏿🏿\r\n🏻🏿🏿🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏿\r\n🏿🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏿\r\n🏻🏿🏿🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏿\r\n🏻🏻🏻🏿🏿🏽🏽🏽🏽🏽🏿🏿🏿🏿🏿🏿🏿🏿🏿🏿🏿🏿🏿🏿🏿🏿🏿🏿🏿\r\n🏻🏻🏻🏻🏻🏿🏿🏽🏽🏽🏿🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻\r\n🏻🏻🏻🏻🏻🏻🏻🏿🏿🏽🏿🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻\r\n🏻🏻🏻🏻🏻🏻🏻🏻🏻🏿🏿🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻\r\n",
            rightTurnDisable = "\r\n                                    ████                  \r\n                                    ██▒▒████              \r\n                                    ██▒▒▒▒▒▒████          \r\n██████████████████████████████████████▒▒▒▒▒▒▒▒▒▒████      \r\n██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒████  \r\n██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██\r\n██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒████  \r\n██████████████████████████████████████▒▒▒▒▒▒▒▒▒▒████      \r\n                                    ██▒▒▒▒▒▒████          \r\n                                    ██▒▒████              \r\n                                    ████                  ",
            rightTurn = "\r\n🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏿🏿🏻🏻🏻🏻🏻🏻🏻🏻🏻\r\n🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏿🏽🏿🏿🏻🏻🏻🏻🏻🏻🏻\r\n🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏿🏽🏽🏽🏿🏿🏻🏻🏻🏻🏻\r\n🏿🏿🏿🏿🏿🏿🏿🏿🏿🏿🏿🏿🏿🏿🏿🏿🏿🏿🏿🏽🏽🏽🏽🏽🏿🏿🏻🏻🏻\r\n🏿🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏿🏿🏻\r\n🏿🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏿\r\n🏿🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏽🏿🏿🏻\r\n🏿🏿🏿🏿🏿🏿🏿🏿🏿🏿🏿🏿🏿🏿🏿🏿🏿🏿🏿🏽🏽🏽🏽🏽🏿🏿🏻🏻🏻\r\n🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏿🏽🏽🏽🏿🏿🏻🏻🏻🏻🏻\r\n🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏿🏽🏿🏿🏻🏻🏻🏻🏻🏻🏻\r\n🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏻🏿🏿🏻🏻🏻🏻🏻🏻🏻🏻🏻";
        Point posLeft = new Point(),
            posRight = new Point();

        Turn_State currentTurn;
        int timer = 0;


        public TurnSignals()
        {
            posLeft = new Point();
            posRight = new Point();

            posLeft.x = 0;
            posLeft.y = Console.WindowHeight * (3 / 4);

            posRight.x = Console.WindowWidth - ARROW_LENGTH;
            posRight.y = posLeft.y;

            currentTurn = Turn_State.NONE;
        }

        public void Update()
        {
            if (timer == 0 || timer == 500)
                switch (currentTurn)
                {
                    case Turn_State.LEFT:
                        Draw((timer == 0) ? leftTurn : leftTurnDisable, posLeft);
                        Draw(rightTurnDisable, posRight);
                        break;

                    case Turn_State.RIGHT:
                        Draw(leftTurnDisable, posLeft);
                        Draw((timer == 0) ? rightTurn : rightTurnDisable, posRight);
                        break;

                    case Turn_State.NONE:
                        Draw(leftTurnDisable, posLeft);
                        Draw(rightTurnDisable, posRight);
                        break;
                }

            timer = (timer <= 900) ? timer + 100 : 0;
        }

        public void SetTurn(Turn_State state)
        {
            currentTurn = state;
            timer = 0;

            Update();
        }

        private void Draw(string signalStr, Point pos)
        {
            string[] lines = signalStr.Split('\n');

            Console.SetCursorPosition(pos.x, pos.y);
            foreach (string line in lines)
            {
                Console.SetCursorPosition(pos.x, Console.CursorTop);
                Console.WriteLine(line);
            }
        }
    }

    public abstract class Indicators
    {
        protected const char DIVISION_SYM = '|';

        public const int DEFAULT_PANEL_WIDTH = 85;
        protected const int BORDER_WIDTH = 2;
        protected const int BORDER_OFFSET_Y = 3;
        protected const int DIAL_OFFSET_Y = -2;
        protected const int DIAL_RULER_OFFSET_Y = -3;
        protected const int PANEL_INFO_OFFSET_Y = 3;

        protected Arrow arrow = new Arrow();
        protected Point position = new Point();

        public Indicators()
        {
            position.x = Console.WindowWidth / 2;
            position.y = Console.WindowHeight / 2;

            UpdateInitArrowPos();
        }

        protected void UpdateInitArrowPos()
        {
            arrow = new Arrow(
                new Point
                {
                    x = position.x - DEFAULT_PANEL_WIDTH / 2,
                    y = position.y
                },
                DEFAULT_PANEL_WIDTH);
        }

        public abstract void Update(float deg);

        protected void DrawBorder()
        {
            char drawSym = '-';
            int buffW = DEFAULT_PANEL_WIDTH / 2 + BORDER_WIDTH;
            int buffH = BORDER_WIDTH + BORDER_OFFSET_Y;

            for (int x = -buffW; x <= buffW; x++)
                for (int y = -buffH; y <= buffH; y++)
                    if (Math.Abs(x) == buffW || Math.Abs(y) == buffH)
                    {
                        drawSym = (Math.Abs(x) == buffW) ? '|' : '—';

                        Console.SetCursorPosition(position.x + x, position.y + y);
                        Console.Write(drawSym);
                    }
        }

        public virtual void DrawPanel(int division = 2, int max = 20)
        {
            string dial = "";
            float cntDivisions = max / division;
            float divisionInterval = (float)(DEFAULT_PANEL_WIDTH / cntDivisions);

            for (float ind = 0, posX = -DEFAULT_PANEL_WIDTH / 2; ind <= cntDivisions; ind++, posX += divisionInterval)
            {
                dial = (ind % 2 == 0) ? (ind * division).ToString() : DIVISION_SYM.ToString();

                Console.SetCursorPosition(position.x + (int)posX, position.y + DIAL_RULER_OFFSET_Y);
                Console.Write('|');
            }
        }

        public static void WriteTextCentered(string text, int yPos, int xCenterPos = -1)
        {
            xCenterPos = (xCenterPos == -1) ?
                Console.WindowWidth / 2 : xCenterPos;

            Console.SetCursorPosition(
                xCenterPos - (text.Length - 1) / 2,
                yPos);
            Console.Write(text);
        }
    }

    public class Speedometer : Indicators
    {
        float speedAcceleration;


        public Speedometer(int positionX, int positionY)
        {
            position.x = positionX;
            position.y = positionY + TurnSignals.ARROW_HEIGHT;

            UpdateInitArrowPos();
        }

        public override void Update(float gasValue)
        {
            int arrowProgress = (int)(gasValue * speedAcceleration);

            //if (arrowProgress < DEFAULT_PANEL_WIDTH * (2f / 4f))//veloucity over lifetime
            //    speedAcceleration = 25f;
            //else if (arrowProgress < DEFAULT_PANEL_WIDTH * (3f / 4f))
            //    speedAcceleration = 18.5f;
            //else
                speedAcceleration = 12f;

            arrow.Update(arrowProgress);
            //Console.SetCursorPosition(0, 0); //Debug
            //Console.WriteLine(speedAcceleration);
        }

        public override void DrawPanel(int division, int max)
        {
            //frame
            DrawBorder();

            //dials
            string dial = "";
            float cntDivisions = max / division;
            float divisionInterval = (float)(DEFAULT_PANEL_WIDTH / cntDivisions);

            for (float ind = 0, posX = -DEFAULT_PANEL_WIDTH / 2; ind <= cntDivisions; ind++, posX += divisionInterval)
            {
                dial = (ind % 2 == 0) ? (ind * division).ToString() : DIVISION_SYM.ToString();

                Console.SetCursorPosition(position.x + (int)posX, position.y + DIAL_RULER_OFFSET_Y);
                Console.Write('|');
                Console.SetCursorPosition(position.x + (int)posX, position.y + DIAL_OFFSET_Y);
                Console.Write(dial);
                Console.SetCursorPosition(position.x + (int)posX, position.y + PANEL_INFO_OFFSET_Y - 1);
                Console.Write('‗');
                Console.SetCursorPosition(position.x + (int)posX, position.y + PANEL_INFO_OFFSET_Y + 1);
                Console.Write('‗');
            }

            WriteTextCentered("km/h", position.y + PANEL_INFO_OFFSET_Y, position.x);
        }
    }

    public class Tachometer : Indicators
    {
        float rotatesAcceleration;


        public Tachometer(int positionX, int positionY)
        {
            position.x = positionX;
            position.y = positionY + TurnSignals.ARROW_HEIGHT;

            UpdateInitArrowPos();
        }

        public override void Update(float gasValue)
        {
            int arrowProgress = (int)(gasValue * rotatesAcceleration);

            rotatesAcceleration = 15f;// = (arrow.GetProgress() <= DEFAULT_PANEL_WIDTH * (2f / 4f)) ?
                //35f : 10f;

            arrow.Update(arrowProgress);

            //Console.SetCursorPosition(0, 0); //Debug
            //Console.WriteLine(rotatesAcceleration);
        }

        public override void DrawPanel(int division, int max)
        {
            //frame
            DrawBorder();

            //dials
            string dial = "";
            float cntDivisions = max / division + BORDER_WIDTH;
            float divisionInterval = (float)(DEFAULT_PANEL_WIDTH / cntDivisions);

            for (float ind = 0, posX = -DEFAULT_PANEL_WIDTH / 2; ind <= cntDivisions; ind++, posX += divisionInterval)
            {
                dial = (ind % 2 == 0) ? (ind * division * .1f).ToString() : DIVISION_SYM.ToString();

                Console.SetCursorPosition(position.x + (int)posX, position.y + DIAL_RULER_OFFSET_Y);
                Console.Write('|');
                Console.SetCursorPosition(position.x + (int)posX, position.y + DIAL_OFFSET_Y);
                Console.Write(dial);
                Console.SetCursorPosition(position.x + (int)posX, position.y + PANEL_INFO_OFFSET_Y - 1);
                Console.Write('‗');
                Console.SetCursorPosition(position.x + (int)posX, position.y + PANEL_INFO_OFFSET_Y + 1);
                Console.Write('‗');
            }

            WriteTextCentered("x1000r/min", position.y + PANEL_INFO_OFFSET_Y, position.x);
        }

    }
}

