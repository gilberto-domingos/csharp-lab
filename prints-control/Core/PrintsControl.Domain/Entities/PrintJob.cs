using System.ComponentModel.DataAnnotations;

namespace PrintsControl.Domain.Entities;

public class PrintJob : BaseEntity
{
    public Guid StudentId { get; private set; }

    public Student? Student { get; private set; }

    public int Quantity { get; private set; }
    
   public DateTimeOffset PrintDate { get; private set; }

    protected PrintJob(){}

    public PrintJob(Guid studentId, int quantity, DateTimeOffset printDate)
    {
        StudentId = studentId;
        Quantity = quantity;
        PrintDate = printDate;
    }
    
    public static PrintJob Create(Guid studentId, int quantity, DateTimeOffset printDate )
    {
        ValidateQuantity(quantity);

        return new PrintJob
        {
            StudentId = studentId,
            Quantity = quantity,
            PrintDate = printDate
        };
    }

    public void UpdateQuantity(int quantity)
    {
       ValidateQuantity(quantity);

        Quantity = quantity;
        MarkAsUpdated();
    }

    private static void ValidateQuantity(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("A quantidade impressa deve ser maior que zero");
    }

    public override string ToString()
    {
        return $"PrintJob [Id={Id}, StudentId={StudentId}, Quantity={Quantity}, Date={PrintDate}]";
    }
}
