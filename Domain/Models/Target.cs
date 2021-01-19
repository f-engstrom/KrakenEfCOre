using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;

namespace KrakenEfCOre.Domain.Models
{
    class Target
    {
        public int Id { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Z { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime ?Date { get;  private set; }
        public bool Status { get; private set; }

        public Target(int id, int x, int y, int z, string name, string description, bool status)

        {
            Id = id;
            X = x;
            Y = y;
            Z = z;
            Name = name;
            Description = description;
            Date = DateTime.Now;
            Status = status;
        }

   


        public Target( int x, int y, int z, string name, string description)

        {
            X = x;
            Y = y;
            Z = z;
            Name = name;
            Description = description;
        }

        public void Hit()
        {
            Status = true;
            Date = DateTime.Now;

        }

        public void Miss()
        {

            Status = false;
            Date = DateTime.Now;
        }

    }
}
