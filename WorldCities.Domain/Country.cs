﻿
namespace WorldCities.Domain
{
    public class Country
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ISO2 { get; set; }
        public string? ISO3 { get; set; }
        public virtual List<City>? Cities { get; set; }
    }
}
