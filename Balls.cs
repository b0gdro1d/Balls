class Program

    {

 

        static ConsoleColor GetRandomColor(Random rnd, int colors)

        {

            return (ConsoleColor)(rnd.Next(1, colors + 1));

        }

        static ConsoleColor[,] GenerateField(int numberOfBallsToSet, int height, int width, int colors, Random rnd)

        {

            ConsoleColor[,] field = new ConsoleColor[height, width];

            while (numberOfBallsToSet > 0)

            {

                int x = rnd.Next(0, field.GetLength(0));

                int y = rnd.Next(0, field.GetLength(1));

                if (field[x, y] == ConsoleColor.Black)

                {

                    field[x, y] = GetRandomColor(rnd, colors);

                    numberOfBallsToSet--;

                }

            }

            return field;

        }

        static void OutputField(ConsoleColor[,] field, int score, int height, int width)

        {

            Console.Write(" ");           

            for (int j = 0; j < width; j++)

            {

                Console.Write(" " + j);

            }

            Console.WriteLine();    

            for (int i = 0; i < height; i++)

            {

                Console.ForegroundColor = ConsoleColor.White;

                Console.Write(i + " ");

                for (int j = 0; j < width; j++)

                {

                    Console.ForegroundColor = field[i, j];

                    Console.Write("O" + " ");

                }

                Console.Write("\n");

            }

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Счет: " + score);

        }

        static void LinesCheck(ConsoleColor[,] field, int height, int width, int destroy, ref int score)

        {

            for (int i = 0; i < height; i++)

            {

                score += LineCheckHorizontal(field, i, width, destroy);

            }

            for (int j = 0; j < width; j++)

            {

                score += LineCheckVertical(field, j, height, destroy);

            }

            for (int i = 0; i < height - 1; i++)

            {

                score += LInesCheckRightDown(field, i, 0, height, width, destroy);

            }

            for (int j = 0; j < width - 1; j++)

            {

                score += LInesCheckRightDown(field, 0, j, height, width, destroy);

            }

            for (int i = 1; i < height; i++)

            {

                score += LInesCheckLeftUp(field, i, 0, height, width, destroy);

            }

            for (int j = 0; j < width - 1; j++)

            {

                score += LInesCheckLeftUp(field, height - 1, j, height, width, destroy);

            }

        }

        static int LineCheckHorizontal(ConsoleColor[,] field, int i, int width, int destroy)

        {

            int ballsInRow = 1;

            int ballsDestroyed = 0;

            for (int j = 0; j < width - 1; ++j)

            {

                if (field[i, j] == field[i, j + 1] && field[i, j] != ConsoleColor.Black)

                {

                    ballsInRow ++;

                }

                else

                {

                    if (ballsInRow >= destroy)

                    {

                        ballsDestroyed += ballsInRow;

                        while (ballsInRow-- > 0)

                        {

                            field[i, j - ballsInRow] = ConsoleColor.Black;

                        }

                    }

                    ballsInRow = 1;

                }

            }

            if (ballsInRow >= destroy)

            {

                ballsDestroyed += ballsInRow;

                while (ballsInRow-- > 0)

                {

                    field[i, width - ballsInRow - 1] = ConsoleColor.Black;

                }

            }

            return ballsDestroyed;

        }

        static int LineCheckVertical(ConsoleColor[,] field, int j, int height, int destroy)

        {

            int ballsInRow = 1;

            int ballsDestroyed = 0;

            for (int i = 0; i < height - 1; ++i)

            {

                if (field[i, j] == field[i + 1, j] && field[i, j] != ConsoleColor.Black)

                {

                    ballsInRow++;

                }

                else

                {

                    if (ballsInRow >= destroy)

                    {

                        ballsDestroyed += ballsInRow;

                        while (ballsInRow-- > 0)

                        {

                            field[i - ballsInRow, j] = ConsoleColor.Black;

                        }

                    }

                    ballsInRow = 1;

                }

            }

            if (ballsInRow >= destroy)

            {

                ballsDestroyed += ballsInRow;

                while (ballsInRow-- > 0)

                {

                    field[height - ballsInRow - 1, j] = ConsoleColor.Black;

                }

            }

            return ballsDestroyed;

        }

        static int LInesCheckRightDown(ConsoleColor[,] field, int i, int j, int height, int width, int destroy)

        {

            int ballsInRow = 1;

            int ballsDestroyed = 0;

            while (i < height - 1 && j < width - 1)

            {

                if (field[i, j] == field[i + 1, j + 1] && field[i, j] != ConsoleColor.Black)

                {

                    ballsInRow++;

                }

                else

                {

                    if (ballsInRow >= destroy)

                    {

                        ballsDestroyed += ballsInRow;

                        while (ballsInRow-- > 0)

                        {

                            field[i - ballsInRow, j - ballsInRow] = ConsoleColor.Black;

                        }

                        ballsInRow = 1;

                    }

                }

                i++;

                j++;

            }

            if (ballsInRow >= destroy)

            {

                ballsDestroyed += ballsInRow;

                while (ballsInRow-- > 0)

                {

                    field[i - ballsInRow, j - ballsInRow] = ConsoleColor.Black;

                }

                ballsInRow = 1;

            }

            return ballsDestroyed;

        }

        static int LInesCheckLeftUp(ConsoleColor[,] field, int i, int j, int height, int width, int destroy)

        {

            int ballsInRow = 1;

            int ballsDestroyed = 0;

            while (i > 0 && j < width - 1)

            {

                if (field[i, j] == field[i - 1, j + 1] && field[i, j] != ConsoleColor.Black)

                {

                    ballsInRow++;

                }

                else

                {

                    if (ballsInRow >= destroy)

                    {

                        ballsDestroyed += ballsInRow;

                        while (ballsInRow-- > 0)

                        {

                            field[i + ballsInRow, j - ballsInRow] = ConsoleColor.Black;

                        }

                        ballsInRow = 1;

                    }

                }

                i--;

                j++;

            }

            if (ballsInRow >= destroy)

            {

                ballsDestroyed += ballsInRow;

                while (ballsInRow-- > 0)

                {

                    field[i + ballsInRow, j - destroy] = ConsoleColor.Black;

                }

                ballsInRow = 1;

            }

            return ballsDestroyed;

        }

        static void BallShift(ConsoleColor[,] field)

        {

            Console.WriteLine("Введите координаты (индексы) шара, которой вы хотите передвинуть\ni =");

            int i = int.Parse(Console.ReadLine());

            Console.WriteLine("j = ");

            int j = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите координаты (индексы) клетки, в которую вы хотите передвинуть шар\niShift =");

            int iShift = int.Parse(Console.ReadLine());

            Console.WriteLine("jShift = ");

            int jShift = int.Parse(Console.ReadLine());

            bool[,] cells = new bool[field.GetLength(0), field.GetLength(1)];

            CanMove(field, cells, i + 1, j);

            CanMove(field, cells, i - 1, j);

            CanMove(field, cells, i, j - 1);

            CanMove(field, cells, i, j + 1);

            //bool v = Exist(field, i, j, iShift, jShift);

            if (cells[iShift, jShift] ==true )

            {

                field[iShift, jShift] = field[i, j];

                field[i, j] = ConsoleColor.Black;

                Console.WriteLine("Шарик на месте");

            }

            else

            {

                if (cells[iShift, jShift] == false) Console.WriteLine("На пути преграда, не пройти");

                /*if (Exist(field, i, j, iShift, jShift) == false) Console.WriteLine("Линия не получится");*/

            }

        }

        static void CanMove(ConsoleColor[,] field, bool[,] cells, int i, int j)

        {

            if (IsInField(i, j, field) && !cells[i, j] && field[i, j] == ConsoleColor.Black)

            {

                cells[i, j] = true;

                CanMove(field, cells, i + 1, j);

                CanMove(field, cells, i - 1, j);

                CanMove(field, cells, i, j + 1);

                CanMove(field, cells, i, j - 1);

            }

        }

        static bool IsInField(int i, int j, ConsoleColor[,] field)

        {

           return i >= 0 && i < field.GetLength(0) && j >= 0 && j < field.GetLength(1);

        }

        static void PlusBall(ConsoleColor[,] field, Random rnd, int colors)

        {

            int i, j;

            do

            {

                i = rnd.Next(0, field.GetLength(0));

                j = rnd.Next(0, field.GetLength(1));

            }

            while (field[i, j] != ConsoleColor.Black);

            field[i, j] = GetRandomColor(rnd, colors);

            Console.WriteLine("Шарик добавлен в ячеку ({0}, {1})", i, j);

        }

        static bool Full(ConsoleColor[,] field)

        {

            foreach (ConsoleColor x in field)

            {

                if (x == ConsoleColor.Black)

                    return false;

            }

            return true;

        }

        static bool Empty(ConsoleColor[,] field)

        {

            foreach (ConsoleColor x in field)

            {

                if (x != ConsoleColor.Black)

                    return false;

            }

            return true;

        }

        /*static bool Exist(ConsoleColor[,] field, int i, int j, int iShift, int jShift)

        {

            bool v = false;

            if (IsInField(iShift, jShift+1, field))

            {

                if (field[i, j] == field[iShift, jShift + 1])

                {

                    if (IsInField(iShift, jShift + 2, field))

                    {

                        if (field[i, j] == field[iShift, jShift + 2]) v = true;

                        else if (IsInField(iShift, jShift - 1, field))

                        {

                            if (field[i, j] == field[iShift, jShift - 1]) v = true;

                            else v = false;

                        }

                    }

                }

                else if (IsInField(iShift, jShift -2, field))

                {

                    if ((field[i, j] == field[iShift, jShift - 1]) && (field[i, j] == field[iShift, jShift - 2])) v = true;

                }

            }

            else if (IsInField(iShift+1, jShift, field))

            {

                if (field[i, j] == field[iShift+1, jShift])

                {

                    if (IsInField(iShift+2, jShift, field))

                    {

                        if (field[i, j] == field[iShift+2, jShift]) v = true;

                        else if (IsInField(iShift-1, jShift, field))

                        {

                            if (field[i, j] == field[iShift-1, jShift]) v = true;

                            else v = false;

                        }

                    }

                }

                else if (IsInField(iShift-2, jShift, field))

                {

                    if ((field[i, j] == field[iShift-1, jShift]) && (field[i, j] == field[iShift-2, jShift])) v = true;

                }

            }

            else if (IsInField(iShift + 1, jShift + 1, field))

            {

                if (field[i, j] == field[iShift + 1, jShift + 1])

                {

                    if (IsInField(iShift + 2, jShift +2, field))

                    {

                        if (field[i, j] == field[iShift + 2, jShift+2]) v = true;

                        else if (IsInField(iShift - 1, jShift-1, field))

                        {

                            if (field[i, j] == field[iShift - 1, jShift-1]) v = true;

                            else v = false;

                        }

                    }

                }

                else if (IsInField(iShift - 2, jShift - 2, field))

                {

                    if ((field[i, j] == field[iShift - 1, jShift-1]) && (field[i, j] == field[iShift - 2, jShift-2])) v = true;

                }

            }

            else if (IsInField(iShift - 1, jShift + 1, field))

            {

                if (field[i, j] == field[iShift - 1, jShift + 1])

                {

                    if (IsInField(iShift - 2, jShift + 2, field))

                    {

                        if (field[i, j] == field[iShift - 2, jShift + 2]) v = true;

                        else if (IsInField(iShift + 1, jShift - 1, field))

                        {

                            if (field[i, j] == field[iShift + 1, jShift - 1]) v = true;

                            else v = false;

                        }

                    }

                }

                else if (IsInField(iShift + 2, jShift - 2, field))

                {

                    if ((field[i, j] == field[iShift + 1, jShift - 1]) && (field[i, j] == field[iShift + 2, jShift - 2])) v = true;

                }

            }

            return v;

        }*/

        static void Igra(int balls)

        {

            int colors = 7;

            int destroy = 3;

            int height = 9;

            int width = 9;

            int score = 0;

           Random rnd = new Random();

            ConsoleColor[,] field = GenerateField(balls, height, width, colors, rnd);

            OutputField(field, score, height, width);

            LinesCheck(field, height, width, destroy, ref score);

            char f;

            do

            {

                BallShift(field);

                LinesCheck(field, height, width, destroy, ref score);

                if (Empty(field))

                {

                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine("Меньшего я и не ожидал. ПОБЕДА!\nСчет: " + score);

                    return;

                }

                if (Full(field))

                {

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("Не в этот раз, шарики оказались сильнее...");

                    return;

                }

                PlusBall(field, rnd, colors);

                LinesCheck(field, height, width, destroy, ref score);

                if (Full(field))

                {

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("Не в этот раз, шарики оказались сильнее...");

                    return;

                }

                OutputField(field, score, height, width);

                Console.WriteLine("Если хотите закончить, введите F. В ином случае введите любой другой символ");

                f = char.Parse(Console.ReadLine());

            }

            while (f != 'F');

        }

        static void Main(string[] args)

        {

            Console.WriteLine("Добро пожаловать в шарики. Приятной игры!");

            Console.WriteLine("Введите начальное количество шариков");

            int balls = int.Parse(Console.ReadLine());

            while (!(balls >= 0 && balls <= 81))

            {

                Console.WriteLine("Ввод неккоректный. Введите новое количество шариков");

                balls = int.Parse(Console.ReadLine());

            }

            Igra(balls);

            Console.WriteLine("Конец. Спасибо за игру!");

        }

    }