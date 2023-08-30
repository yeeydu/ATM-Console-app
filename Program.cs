using System;

public class cardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;

    //constructor
    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    // getters 
    public String getNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public String getFirstName()
    {
        return firstName;
    }

    public String getLastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    // setters
    public void setNum(String newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }


    public static void Main(String[] args)
    {
        // methods options
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options..");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");

        }

        // deposit method
        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much €€ would you like to deposit: ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(deposit + currentUser.getBalance());
            Console.WriteLine("Thank you for your deposit. Your new balance is: " + currentUser.getBalance());
        }

        //withdrawal method
        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much €€ would you like to withdraw: ");
            double withdrawal = Double.Parse(Console.ReadLine());
            if (currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Insuficient balance :(");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("Thank you!");
            }
        }

        //balance method
        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }

        // add users / cardHolders
        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("456789432146568863", 1234, "John", "Doe", 180.43));
        cardHolders.Add(new cardHolder("456789437698665443", 5643, "Mike", "louve", 435));
        cardHolders.Add(new cardHolder("456782355446568863", 6785, "Lucas", "dester", 678.34));
        cardHolders.Add(new cardHolder("456789432167998663", 9563, "fire", "witt", 436.76));
        cardHolders.Add(new cardHolder("456345432146568863", 5633, "Mathew", "Jmaes", 235.65));

        // prompt user cardnumber

        Console.WriteLine("Wellcome to ATM");
        Console.WriteLine("Please insert your debit card: ");
        String debitCardNum = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                // check against our db
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum); //return first element of sequence tha satisfies the condition
                if (currentUser != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Card not recognized. Please try again");
                }
            }
            catch
            {
                Console.WriteLine("Card not recognized. Please try again");
            }

        }

        // user pin
        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                // check against our db
                if (currentUser.getPin() == userPin)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect pin. Please try again");
                }
            }
            catch
            {
                Console.WriteLine("Incorrect pin. Please try again");
            }

        }


        // while user is logged in
        Console.WriteLine("Welcome " + currentUser.getFirstName() + " :)");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch
            {

            }
            if (option == 1) { deposit(currentUser); }
            else if (option == 2) { withdraw(currentUser); }
            else if (option == 3) { balance(currentUser); }
            else if (option == 4) { break; }
            else { option = 0; }

        } while (option != 4); // 4 exit
        Console.WriteLine("Thank you! Have a nice day!");


    }

}
