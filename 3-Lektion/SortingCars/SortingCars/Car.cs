namespace KG3;
class Car : IComparable
{
    public string Make { get; private set; }
    public string Model { get; private set; }
    public decimal Price { get; private set; }
    public Car(string make, string model, decimal price)
    {
        Make = make;
        Model = model;
        Price = price;
    }

    public int CompareTo(object? obj)
    {
        
        return Price.CompareTo(((Car)obj).Price);
    }
}