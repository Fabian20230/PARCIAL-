int vidas = 4;
int[,] tablero = new int[6, 6];

void paso1()
{
    for (int f = 0; f < tablero.GetLength(0); f++)
    {
        for (int c = 0; c < tablero.GetLength(1); c++)
            tablero[f, c] = 0;

    }
}

void paso2()
{
    tablero[4, 3] = 1;
    tablero[1, 1] = 1;
    tablero[2, 1] = 1;
    tablero[3, 4] = 1;
    tablero[5, 5] = 1;
    tablero[1, 4] = 1;
}

void paso3()
{
    string caracter_imprimir;
    for (int f = 0; f < tablero.GetLength(0); f++)
    {
        for (int c = 0; c < tablero.GetLength(1); c++)
        {
            switch (tablero[f, c])
            {
                case 0:
                    caracter_imprimir = "-";
                    break;
                case -1:
                    caracter_imprimir = "*";
                    break;
                case -2:
                    caracter_imprimir = "x";
                    break;
                default:
                    caracter_imprimir = "-";
                    break;


            }


            Console.Write(caracter_imprimir + "");
        }
        Console.WriteLine();
    }
}
bool rango(string salida)
{
    int num;
    bool n = int.TryParse(salida, out num);
    if (!n)
    {
        Console.WriteLine("Por favor ingrese un digito");
        return false;
    }
    if (num < 0 || num >= tablero.GetLength(0))
    {
        Console.WriteLine($"El numero debe de ser entre el 0 y {tablero.GetLength(0) - 1}.");
        return false;
    }
    return true;
}
void paso4()
{
    Console.Clear();
    do
    {
        Console.WriteLine($"Tienes {vidas} vidas, aprovechalas");
        Console.Write("ingrese fila");
        string fl = Console.ReadLine();
        if (!rango(fl))
        {
            continue;
        }
        Console.Write("ingrese columna");
        string cl = Console.ReadLine();
        if (!rango(cl))
        {
            continue;
        }

        int fila = Convert.ToInt32(fl);
        int columna = Convert.ToInt32(cl);
        if (tablero[fila, columna] == 1)
        {
            Console.Beep();
            tablero[fila, columna] = -1;

        }
        else
        {
            vidas = vidas - 1;
            Console.WriteLine($"Tienes {vidas} vidas ");
            tablero[fila, columna] = -2;
            if (vidas == 0)
            {
                Console.Write("Perdiste");
                break;
            }
        }
        Console.Clear();
        paso3();

        bool barcos = true;
        for (int f = 0; f < tablero.GetLength(0); f++)
        {
            for (int c = 0; c < tablero.GetLength(1); c++)
            {
                if (tablero[f, c] == 1)
                {
                    barcos = false;
                    break;
                }
            }
            if (!barcos) break;
        }
        if (barcos)
        {
            Console.Write("¡Wow eres genial, Ganaste!");
            break;
        }

    } while (true);
}

paso1();
paso2();
paso3();
paso4();
