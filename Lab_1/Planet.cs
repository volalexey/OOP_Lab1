namespace Lab_1
{
    public class Planet
    {
        private PlanetType type;
        private string name;
        private double mass;
        private double radius;
        private double distanceFromSun;
        private bool hasLife;
        private int age;

        public Planet(PlanetType type, string name, double mass, double radius, double distanceFromSun, bool hasLife)
        {
            this.type = type;
            this.name = name;
            this.mass = mass;
            this.radius = radius;
            this.distanceFromSun = distanceFromSun;
            this.hasLife = hasLife;
            this.age = 0;
        }

        public PlanetType GetPlanetType() => type;
        public string GetName() => name;
        public double GetMass() => mass;
        public double GetRadius() => radius;
        public double GetDistanceFromSun() => distanceFromSun;
        public bool GetHasLife() => hasLife;
        public int GetAge() => age;

        public void SetName(string value) => name = value;
        public void SetMass(double value) => mass = value > 0 ? value : mass;
        public void SetRadius(double value) => radius = value > 0 ? value : radius;
        public void SetDistanceFromSun(double value) => distanceFromSun = value >= 0 ? value : distanceFromSun;
        public void SetPlanetType(PlanetType value) => type = value;

        public double CalculateGravity()
        {
            const double G = 6.67430e-11;
            return G * mass / (radius * radius);
        }

        public string MakeYearPass()
        {
            age++;
            return $"{name} made a full circle around the Sun. Age is now {age} years.";
        }

        public string BirthLife()
        {
            if (hasLife)
                return $"Error: life already exists on {name}!";
            hasLife = true;
            return $"Life has begun on {name}!";
        }

        public string DestroyLife()
        {
            if (!hasLife)
                return $"Error: {name} already has no life!";
            hasLife = false;
            return $"Life on {name} has been destroyed...";
        }

        public override string ToString()
        {
            return string.Format(
                "{0,-15} {1,-12} {2,15:E2} {3,15:E2} {4,20:E2} {5,-6} {6,12}",
                name,
                type,
                mass,
                radius,
                distanceFromSun,
                hasLife ? "Yes" : "No",
                age
            );
        }

        public static Planet GenerateRandom(Random rnd)
        {
            string[] names = { "Xenon", "Astra", "Orbis", "Nova", "Kronos", "Zephyr" };
            PlanetType type = (PlanetType)rnd.Next(0, 4);
            string name = names[rnd.Next(names.Length)] + rnd.Next(100, 999);
            double mass = rnd.NextDouble() * 1e25 + 1e22;
            double radius = rnd.NextDouble() * 7e7 + 1e6;
            double distance = rnd.NextDouble() * 5000;
            bool life = rnd.Next(0, 2) == 1;

            return new Planet(type, name, mass, radius, distance, life);
        }
    }
}
