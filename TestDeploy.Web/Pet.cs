using System;

namespace TestDeploy.Web
{
    public class Pet
    {
        public DateTime DOB { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Name { get; set; }
    }
}
