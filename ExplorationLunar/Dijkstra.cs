using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExplorationLunar
{
    public class Dijkstra
    {
        //Classe de Dijkstra
        private IDictionary<Vertex, Vertex> Predecessores;
        private IDictionary<Vertex, int> Distancia;
        private ISet<Vertex> NodeSetados;
        private ISet<Vertex> NodeNaoSetados;
        private List<Vertex> Nodes;
        private List<Edge> Edges;

        public Dijkstra(Graph graph)
        {
            Nodes = new List<Vertex>(graph.Vertices);
            Edges = new List<Edge>(graph.Edges);
        }

        private bool foiSetado(Vertex vertice)
        {
            return NodeSetados.Contains(vertice);
        }

        public LinkedList<Vertex> GetPath(Vertex alvo)
        {
            LinkedList<Vertex> path = new LinkedList<Vertex>();
            Vertex prox = alvo;

            if (!Predecessores.ContainsKey(prox))
            {
                return null;
            }

            path.AddLast(prox);

            while (Predecessores.ContainsKey(prox))
            {
                prox = Predecessores[prox];
                path.AddLast(prox);
            }

            return new LinkedList<Vertex>(path.Reverse());
        }

        private int PegaDistancia(Vertex node, Vertex alvo)
        {
            foreach (Edge edge in Edges)
            {
                if (edge.Origem.Equals(node) && edge.Destino.Equals(alvo))
                {
                    return edge.Peso;
                }
            }
            throw new System.Exception("Should not happen");//Mudar
        }

        private Vertex PegaMinimo(ISet<Vertex> vertices)
        {
            Vertex minimo = null;
            foreach (var vertice in vertices)
            {
                if(minimo != null)
                {
                    if (PegaMenorDistancia(vertice) < PegaMenorDistancia(minimo))
                    {
                        minimo = vertice;
                    }
                }
                else
                {
                    minimo = vertice;
                }
            }
            return minimo;
        }

        private List<Vertex> PegaVizinhos(Vertex node)
        {
            return Edges.Where(e => e.Origem.Equals(node) && !foiSetado(e.Destino)).Select(t => t.Destino).ToList();
        }

        private void ProcurarDistanciaMinima(Vertex node)
        {
            List<Vertex> adjacentNodes = PegaVizinhos(node);

            foreach (Vertex alvo in adjacentNodes)
            {
                if (PegaMenorDistancia(alvo) > PegaMenorDistancia(node) + PegaDistancia(node, alvo))
                {
                    Distancia[alvo] = PegaMenorDistancia(node) + PegaDistancia(node, alvo);
                    Predecessores[alvo] = node;
                    NodeNaoSetados.Add(alvo);
                }
            }

        }

        public void Iniciar(Vertex origem)
        {
            NodeSetados = new HashSet<Vertex>();
            NodeNaoSetados = new HashSet<Vertex>();
            Distancia = new Dictionary<Vertex, int>();
            Predecessores = new Dictionary<Vertex, Vertex>();
            Distancia[origem] = 0;
            NodeNaoSetados.Add(origem);
            while (NodeNaoSetados.Count > 0)
            {
                Vertex node = PegaMinimo(NodeNaoSetados);
                NodeSetados.Add(node);
                NodeNaoSetados.Remove(node);
                ProcurarDistanciaMinima(node);
            }
        }

        private int PegaMenorDistancia(Vertex destino)
        {
            if (Distancia.TryGetValue(destino, out int dest))
            {
                return dest;
            }
            return int.MaxValue;
        }
    }
}
