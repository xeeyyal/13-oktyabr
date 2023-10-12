namespace task13._10Abctract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle[] vehicles = new Vehicle[]
         {
            new Car("BMW", "F30", "Black", 1, "City", 3, false),
            new Bicycle("Adidas", "Classic", "Gray", 1.0, "Park", "Cruiser"),
            new Car("Kia", "Sorento", "White", 3.0, "Village", 5, true),         
            new Bicycle("Kross", "Level 1.0", "Green", 2.0, "Off-road", "Mountain"),
         };

            foreach (Vehicle vehicle in vehicles)
            {
                Console.WriteLine(" Vehicle About ");
                Console.WriteLine(vehicle);
                vehicle.GetInfo();
                Console.WriteLine("Average Speed: " + vehicle.AverageSpeed() + " km/saat");
                Console.WriteLine();
            }
        }
    }
    abstract class Vehicle
    {
        public string FactoryName { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public double DriveTime { get; set; }
        public string DrivePath { get; set; }

        public readonly DateTime ProductionDate;

        public Vehicle(string factoryName, string model, string color, double driveTime, string drivePath)
        {
            FactoryName = factoryName;
            Model = model;
            Color = color;
            DriveTime = driveTime;
            DrivePath = drivePath;
            ProductionDate = DateTime.Now;
        }
        public double AverageSpeed()
        {
            return CalculateAverageSpeed();
        }

        protected abstract double CalculateAverageSpeed();

        public virtual void GetInfo()
        {
            Console.WriteLine($"Factory Name: {FactoryName}");
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"Color: {Color}");
            Console.WriteLine($"Drive Time: {DriveTime} hours");
            Console.WriteLine($"Drive Path: {DrivePath}");
            Console.WriteLine($"Production Date: {ProductionDate: day-month-year}");
        }

        public abstract string DefineNatureHarmness();
    }

    class Car : Vehicle
    {
        public int DoorCount { get; set; }
        public bool IsElectricCar { get; set; }

        public Car(string factoryName, string model, string color, double driveTime, string drivePath, int doorCount, bool isElectric) : base(factoryName, model, color, driveTime, drivePath)
        {
            DoorCount = doorCount;
            IsElectricCar = isElectric;
        }
        protected override double CalculateAverageSpeed()
        {
            return DoorCount * 10;
        }

        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"Door Count: {DoorCount}");
            Console.WriteLine($"Is Electric Car: {IsElectricCar}");
            Console.WriteLine($"Nature Harmness: {DefineNatureHarmness()}");
        }

        public override string DefineNatureHarmness()
        {
            return IsElectricCar ? "Low" : "High";
        }

        public override string ToString()
        {
            return $"Factory Name: {FactoryName}, Model: {Model}";
        }
    }

    class Bicycle : Vehicle
    {
        public string Type {  get; set; }
        public Bicycle(string factoryName, string model, string color, double driveTime, string drivePath, string type) : base(factoryName, model, color, driveTime, drivePath)
        {
            Type = type;
        }
        protected override double CalculateAverageSpeed()
        {
            return 25;
        }

        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"Type: {Type}");
            Console.WriteLine($"Nature Harmness: {DefineNatureHarmness()}");
        }

        public override string DefineNatureHarmness()
        {
            return "None";
        }

        public override string ToString()
        {
            return $"Factory Name: {FactoryName}, Model: {Model}";
        }
    }
}