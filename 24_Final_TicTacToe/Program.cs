namespace _24_Final_TicTacToe;

public class Program
{
    static void Main(string[] args)
    {
        //create player 1
        Player p1 = new Player("X");

        //create player 2
        Player p2 = new Player("O");

        Player currentPlayer = p1;
        Board board = new Board();

        board.DrawBoard(currentPlayer);

        while (true)
        {
            bool place;
            do
            {
                Console.Write("Place your letter: ");
                int.TryParse(Console.ReadLine(), out int spot);
                place = board.PlaceLetter(currentPlayer, spot);
                if (!place)
                {
                    Console.WriteLine("Wrong placement. Try again.");
                }
            } while (!place);

            Console.Clear();
            board.DrawBoard(currentPlayer);

            if (board.CheckWinner(currentPlayer))
            {
                Console.Clear();
                board.DrawBoard(currentPlayer);
                break;
            }

            if (currentPlayer == p1) currentPlayer = p2;
            else currentPlayer = p1;
        }

        Console.ReadLine();
    }
}

public class Board
{
    public List<string> GridSpot { get; set; } = new List<string>(9);

    public Board()
    {
        for (int i = 0; i < 9; i++)
        {
            GridSpot.Add(" ");
        }
    }

    public void DrawBoard(Player p)
    {
        if (!p.Winner)
        {
            Console.WriteLine($"It is {p.Letter}'s turn.");
        }
        else
        {
            Console.WriteLine($"{p.Letter} IS THE WINNER!!!");
        }
        Console.WriteLine($"| {GridSpot[6]} | {GridSpot[7]} | {GridSpot[8]} |");
        Console.WriteLine("--------------");
        Console.WriteLine($"| {GridSpot[3]} | {GridSpot[4]} | {GridSpot[5]} |");
        Console.WriteLine("--------------");
        Console.WriteLine($"| {GridSpot[0]} | {GridSpot[1]} | {GridSpot[2]} |");
    }

    public bool PlaceLetter(Player p, int spot)
    {
        bool isValid = false;

        if (spot > 0 && spot < 10)
        {
            if (GridSpot[spot - 1] == " ")
            {
                GridSpot[spot - 1] = p.Letter;
                isValid = true;
            }
        }

        return isValid;
    }

    public bool CheckWinner(Player p)
    {
        if (Horizontal() || Vertical() || Diagonal())
        {
            p.Winner = true;
            return true;
        }

        return false;
    }

    private bool Horizontal()
    {
        if (GridSpot[0] != " " && GridSpot[0] == GridSpot[1] && GridSpot[0] == GridSpot[2]) return true;
        if (GridSpot[3] != " " && GridSpot[3] == GridSpot[4] && GridSpot[3] == GridSpot[4]) return true;
        if (GridSpot[6] != " " && GridSpot[6] == GridSpot[7] && GridSpot[6] == GridSpot[8]) return true;

        return false;
    }

    private bool Vertical()
    {
        if (GridSpot[0] != " " && GridSpot[0] == GridSpot[3] && GridSpot[0] == GridSpot[6]) return true;
        if (GridSpot[1] != " " && GridSpot[1] == GridSpot[4] && GridSpot[1] == GridSpot[7]) return true;
        if (GridSpot[2] != " " && GridSpot[2] == GridSpot[5] && GridSpot[2] == GridSpot[8]) return true;

        return false;
    }

    private bool Diagonal()
    {
        if (GridSpot[0] != " " && GridSpot[0] == GridSpot[4] && GridSpot[0] == GridSpot[8]) return true;
        if (GridSpot[2] != " " && GridSpot[2] == GridSpot[4] && GridSpot[2] == GridSpot[6]) return true;

        return false;
    }
}

public class Player
{
    public string Letter { get; private set; }
    public bool Winner { get; set; } = false;

    public Player(string letter)
    {
        Letter = letter;
    }
}