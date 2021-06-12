using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace NET.Kniaz.PAI.Model.Agents.Rover
{
    public class Desire
    {
        public TypesDesire Name { get; set; }
        public dynamic Predicate;
        public List<Desire> SubDesires { get; set; }

        private void CreateSubDesires()
        {
            SubDesires = new List<Desire>();
        }
        public Desire()
        {
            CreateSubDesires();
        }

        public Desire(TypesDesire name)
        {
            Name = name;
            CreateSubDesires();
        }

        public Desire(TypesDesire name, dynamic predicate)
        {
            Name = name;
            Predicate = predicate;
            CreateSubDesires();
        }

        public Desire(TypesDesire name, IEnumerable<Desire> subDesires)
        {
            Name = name;
            SubDesires = new List<Desire>(subDesires);
        }

        public Desire(TypesDesire name, params Desire[] subDesires)
        {
            Name = name;
            SubDesires = new List<Desire>(subDesires);
        }

        public List<Desire> GetSubDesires()
        {
            if (SubDesires.Count==0)
                return new List<Desire>(){this};
            var result = new List<Desire>();

            foreach(var desire in SubDesires)
                result.AddRange(desire.GetSubDesires());

            return result;
        }

        public override string ToString()
        {
            return Name.ToString() + "\n";
        }
    }
}
