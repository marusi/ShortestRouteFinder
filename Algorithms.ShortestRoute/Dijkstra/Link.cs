using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.ShortestRoute.Dijkstra
{
   public class Link
    {
        private Link(double weight, Node destination)
        {
            Weight = weight;
            Destination = destination;
        }
        public double Weight { get; }
        public Node Destination { get; }

        internal static Link Create(double weight, Node destination)
        {
            return new Link(weight, destination);
        }
    }
}
