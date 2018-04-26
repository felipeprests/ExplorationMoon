using System;
using System.Collections.Generic;
using System.Text;

namespace ExplorationLunar
{
    public class Vertex
    {
        //Classe de vertex
        public String ID { get; set; }
        public String Name { get; set; }

        public Vertex(String id, String name)
        {
            ID = id;
            Name = name;
        }
        public override int GetHashCode()
        {
            int prime = 31;
            int result = 1;
            result = prime * result + ((ID == null) ? 0 : ID.GetHashCode());
            return result;
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;

            if (obj == null)
                return false;

            if (GetType() != obj.GetType())
                return false;

            Vertex other = (Vertex)obj;

            if (ID == null)
            {
                if (other.ID != null)
                {
                    return false;
                }
            }
            else if (!ID.Equals(other.ID))
                return false;

            return true;
        }

        public override string ToString()
        {
            return Name.ToString();
        }

    }
}
