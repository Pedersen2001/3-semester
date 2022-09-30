using KG3;


static void Main()
{
    List<Car> cars = new List<Car>()
    {
        new Car("Skoda", "Fabia", 50000m),
        new Car("Skoda", "Octavia", 60000m),
        new Car("Fiat", "500", 12345m),
        new Car("Ford", "Mustang", 9000000m),
        new Car("Ford", "Mustang", 9000001m)
        };
    cars.Sort();
    Console.WriteLine("Sorted by price");
    foreach (Car car in cars)
    {
        Console.WriteLine($" {car.Make} {car.Model} {car.Price}");
    }
}
