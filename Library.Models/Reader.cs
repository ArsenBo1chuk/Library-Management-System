namespace Library.Models;

using Library.Utils;
public class Reader : Person
{
    public List<BorrowRecord> BorrowHistory {get; set;} = new();
    public Reader(string name, int age, string email) : base(name, age, email){}
    public double penaltyMoney{get; set;}

    public override void PrintInfo()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}, Email: {Email}, Penalty: {penaltyMoney}, Books Count: {GetBorrowCount}");
    }
    public void AddPenalty(double money)
    {
        if (ValidationHelper.ValidateMoney(money))
        {
            penaltyMoney += money;
        }
        else
        {
            throw new ArgumentException("Invalid money format");
        }
    }

    public int GetBorrowCount()
    {
        return BorrowHistory.Count;
    }

    public List<BorrowRecord> GetActiveBorrows()
    {
        List<BorrowRecord> ActiveBooksList = new();
        foreach (var book in BorrowHistory)
        {
            if (book.GetStatus() == Enums.BorrowStatus.Active)
            {
                ActiveBooksList.Add(book);
            }
        }
        return ActiveBooksList;
    }

    
}