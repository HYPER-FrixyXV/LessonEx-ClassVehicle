using BPascal.LessonEx2.ClassDomain;

internal class Program
{
    static void Main(string[] args)
    {
        try
        {
            Vehicle vehicle1 = new Vehicle("abc123d", 5, 2, 100);

            string license = vehicle1.LicensePlate;
            Console.WriteLine(license);

            Console.WriteLine(vehicle1.ID);
            Console.WriteLine(vehicle1.Odometer);
            Console.WriteLine(vehicle1.DailyRate);
            Console.WriteLine(vehicle1.FuelLvPerc);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }
}