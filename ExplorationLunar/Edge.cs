using System;

namespace ExplorationLunar
{
    public class Edge
    {
        //Classe de Edge
        public String ID { get; set; }
        public Vertex Origem { get; set; }
        public Vertex Destino { get; set; }
        public int Peso { get; set; }
        public Edge(string id, Vertex origem, Vertex destino, int peso)
        {
            ID = id;
            Origem = origem;
            Destino = destino;
            Peso = peso;
        }

        public override string ToString()
        {
            return Origem + " " + Destino;  
        }
    }
}