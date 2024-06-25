namespace Hospital.Domain.Services;

public class CalculateDiscount
{
    public static decimal Calculate(decimal price, decimal discount)
    {
        return price - (price * discount);
    }
}
