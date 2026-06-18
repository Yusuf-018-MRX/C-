using System.Threading.Channels;

public class Card
{
    public string PAN { get; set; }
    public string PIN { get; set; }
    public string CVC { get; set; }
    public string ExpireDate { get; set; }
    public decimal Balance { get; set; }
    public Card()
    {
        Random rand = new Random();
        PAN = "";
        for (int i = 0; i < 4; i++)
        {
            PAN += rand.Next(1000, 10000);
        }
        PIN = rand.Next(1000, 10000).ToString();
        CVC = rand.Next(100, 1000).ToString();
        Console.WriteLine($"Pan: {PAN}");
        Console.WriteLine($"Pin: {PIN}");
        Console.WriteLine($"Cvc: {CVC}");
        int month = rand.Next(1, 13);
        int year = rand.Next(26, 36);
        ExpireDate = $"{month}/{year}";
        Balance = 100m;
    }
}
//-------------------------------------------------
public class User 
{
    public string Name;
    public string Surname;
    public Card CreditCard;
    public User(string Name , string Surname , Card CreditCard)
    {
        this.Name = Name;
        this.Surname = Surname;
        this.CreditCard = CreditCard;
    }
}
///---------------------------------------------------------------
public class ATM
{
    private User[] users;
    public ATM(User[] users)
    {
        this.users = users;
    }
    public void Start()
    {
        while (true)
        {
            Console.Write("Pin: ");
            string pin = Console.ReadLine();
            User User1 = null;
            for (int i = 0; i < users.Length; i++)
            {
                if (users[i].CreditCard.PIN == pin)
                {
                    User1 = users[i];
                    break;
                }
            }
            if (User1 == null)
            {
                Console.WriteLine("Error: Daxil etdiyiniz Pine uygun card tapilmadi !!!");
                continue;
            }
            Console.WriteLine($"{User1.Name} {User1.Surname} Salam ayqa");
            ShowMenu(User1);
        }
    }
    private void ShowMenu(User User1)
    {
        while (true)
        {
            Console.WriteLine("-> Yusuf Bank <-");
            Console.WriteLine("1. Show Balans");
            Console.WriteLine("2. Mexaric");
            Console.WriteLine("3. Medaxil carddan carda ");
            Console.WriteLine("4. Exit");
            Console.Write("Secim: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    ShowBalance(User1);
                    break;
                case 2:
                    Mexarix(User1);
                    break;
                case 3:
                    Medaxil(User1);
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Error: Yanlis secim !!!");
                    break;
            }
        }
    }
    private void ShowBalance(User user)
    {
        Console.WriteLine($"Balans: {user.CreditCard.Balance} $");//bu $ mennen basqa hec kim qoymuyubdu .
    }
    private void Mexarix(User user)
    {
        Console.WriteLine("1. 10 AZN");
        Console.WriteLine("2. 20 AZN");
        Console.WriteLine("3. 50 AZN");
        Console.WriteLine("4. 100 AZN");
        Console.WriteLine("5. Diger");
        Console.Write("Secim: ");
        int choice = Convert.ToInt32(Console.ReadLine());
        decimal Money = 0;
        switch (choice)
        {
            case 1:
                Money = 10;
                break;
            case 2:
                Money = 20;
                break;
            case 3:
                Money = 50;
                break;
            case 4:
                Money = 100;
                break;

            case 5:
                Console.Write("Enter the money ayqa: ");//englis please
                Money = Convert.ToDecimal(Console.ReadLine());
                break;
            default:
                Console.WriteLine("Error: Yanlis secim !!!");
                return;
        }
        try
        {
            if (Money > user.CreditCard.Balance)
                throw new Exception("Error: Balance yeterli deyil kasib sbsdbsdbcsghdbcsj");//mirtdasmasaq olmazda 
            
            ///--------------------------
            user.CreditCard.Balance -= Money;
            Console.WriteLine($"{Money} $ Verildi.");
            Console.WriteLine($"New Balance: {user.CreditCard.Balance} $");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    private void Medaxil(User Send_Ele )
    {
        Console.Write("Pin: ");
        string NewPin = Console.ReadLine();
        User Check = null;
        for (int i = 0; i < users.Length; i++)
        {
            if (users[i].CreditCard.PIN == NewPin)
            {
                Check = users[i];
                break;
            }
        }
        if (Check == null)
        {
            Console.WriteLine("Error: This pin code Incorrecteee Italyano qaqa");
            return;
        }
        Console.Write("Enter Money: ");
        decimal Money = Convert.ToDecimal(Console.ReadLine());
        try
        {
            if (Money > Send_Ele.CreditCard.Balance)
                throw new Exception("Error: Balance catmir kasib sdnas");

            Send_Ele.CreditCard.Balance -= Money;
            Check.CreditCard.Balance += Money;
            Console.WriteLine("Money gonderildi.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
//----------------------------------------------------------------
class Program
{
    static void Main()
    {
        Console.WriteLine("Yusuf Banka Xosgelmisiniz.");
        Console.WriteLine("Melumat daxil edin .");
        Console.WriteLine("Enter the Info .");//Ba ba ba Ingilsh ce daxgirdir da bu oghlan 
        User[] users = new User[5]
        {//Bu qisimde birini m,en yaratdim sora ai a dedimki bunlari coxalt 5 dene ele qaytar copy vur deyisdir de ola blerdi ama kart mrlumaltrini v.s her seyi deyisdirmeli olajaqdim buda hem vaxt itkisiidi de ai ile hell eledim 
        new User("Kamran", "Kerimzade",
            new Card
            {
                PAN = "1234567812345678",
                PIN = "1234",
                CVC = "123",
                ExpireDate = "06/28",
                Balance = 500m
            }),

        new User("Amil", "Eyvazli",
            new Card
            {
                PAN = "2345678923456789",
                PIN = "2345",
                CVC = "234",
                ExpireDate = "07/29",
                Balance = 750m
            }),

        new User("Ismayil", "Memmedli",
            new Card
            {
                PAN = "3456789034567890",
                PIN = "3456",
                CVC = "345",
                ExpireDate = "08/30",
                Balance = 1000m
            }),

        new User("Cavid", "Ibadzade",
            new Card
            {
                PAN = "4567890145678901",
                PIN = "4567",
                CVC = "456",
                ExpireDate = "09/31",
                Balance = 1250m
            }),

        new User("Ilham", "Namazov",
            new Card
            {
                PAN = "5678901256789012",
                PIN = "5678",
                CVC = "567",
                ExpireDate = "10/32",
                Balance = 1500m
            })
        };
        ATM atm = new ATM(users);
        atm.Start();
    }
}
