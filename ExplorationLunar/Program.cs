using System;
using System.Collections.Generic;

namespace ExplorationLunar
{
    class Program
    {
        //classe do Programa
        private static List<(String origem, String destino)> PathTest;
        private static List<Vertex> nodes;
        private static List<Edge> edges;
        private static int contadorArquivo;
        private static int number;
        static void Main(string[] args)
        {
            NovaInstancia();
            String[,] matrix =  null;

            String line = String.Empty;

            while (true)
            {
                //line = Console.ReadLine();
                line = Console.In.ReadLine();
                if (String.IsNullOrEmpty(line) || String.IsNullOrWhiteSpace(line))
                {
                    for (int i = 0; i < number; i++)
                    {
                        String nodeAtual = matrix[i, i];
                        Vertex vertice = new Vertex(nodeAtual.ToString(), String.Format("Node: {0}", nodeAtual));
                        nodes.Add(vertice);
                    }

                    //trava na coluna e percorre a linha
                    for (int i = 0; i < number; i++)
                    {
                        for (int j = 0; j < number; j++)
                        {
                            if (matrix[j,i] == ".")
                            {
                                AddEdge(String.Format("{0} -> {1}",matrix[j,j],matrix[i,i]),j,i);
                            }
                        }
                    }

                    var dijkstra = new Dijkstra(new Graph(nodes, edges));

                    for (int i = 0; i < PathTest.Count; i++)
                    {
                        //Inicia a partir do node atual e analisa todos os caminhos possíveis
                        dijkstra.Iniciar(new Vertex(PathTest[i].origem.ToString(), String.Empty));
                        //Retorna uma lista para aquele caminho de origem
                        var caminho = dijkstra.GetPath(new Vertex(PathTest[i].destino.ToString(), String.Empty));
                        //Se tiver, adiciona um asterisco, senão uma exclamação
                        if (caminho is null)
                        {
                            Console.Write("! ");
                        }
                        else
                        {
                            Console.Write("* ");
                        }
                    }
                    Console.Write("\n");

                    if (line is null)
                    {
                        break;
                    }

                    NovaInstancia();
                    continue;
                }
                else
                {
                    if (contadorArquivo == 0)
                    { // Primeira linha, pega a quantidade de casos de teste
                        number = Convert.ToInt32(line);
                        matrix = new string[number, number];
                    }
                    else
                    {

                        if (contadorArquivo <= number)
                        {
                            var lineValues = line.Split(" ");
                            for (int i = 0; i < lineValues.Length; i++)
                            {
                                matrix[contadorArquivo - 1, i] = lineValues[i];
                            }
                        }
                        else
                        { // Salva os casos de teste
                            var pathValues = line.Split(" ");
                            PathTest.Add((Convert.ToString(pathValues[0]), Convert.ToString(pathValues[1])));
                        }
                    }
                }
                contadorArquivo++;               
            }
        }

        private static void AddEdge(String name, int origem, int dest)
        {
            Edge lane = new Edge(name, nodes[origem], nodes[dest], 0);
            edges.Add(lane);
        }

        private static void NovaInstancia()
        {
            nodes = new List<Vertex>();
            edges = new List<Edge>();
            PathTest = new List<(string origem, string destino)>();
            contadorArquivo = 0;
        }
    }
}
