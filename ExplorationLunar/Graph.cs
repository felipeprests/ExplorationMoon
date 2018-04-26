using System;
using System.Collections.Generic;
using System.Text;

namespace ExplorationLunar
{
    public class Graph
    {
        //Classe de Graph
        public IList<Vertex> Vertices { get; set; }
        public IList<Edge> Edges { get; set; }

        public Graph(List<Vertex> vertexes, List<Edge> edges)
        {
            Vertices = vertexes;
            Edges = edges;
        }
    }
}
