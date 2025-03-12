using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M7PAPIA
{
    public class Pokemon
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int BaseExperience { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }

        public override string ToString()
        {
            return $"ID: {ID} | Name: {Name} | Base Experience: {BaseExperience} | Height: {Height} | Weight: {Weight}";
        }
    }
}