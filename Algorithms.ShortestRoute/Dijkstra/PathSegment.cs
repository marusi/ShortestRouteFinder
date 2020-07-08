using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.ShortestRoute.Dijkstra
{
   public class PathSegment
    {
        private PathSegment(Node origin, Node destination, double weight)
        {
            Weight = weight;
            Origin = origin;
            Destination = destination;
        }
        public Node Origin { get;  }
        public Node Destination { get; }
        public double Weight { get; }

        internal static PathSegment Create(Node origin, Node destination, double weight)
        {
            return new PathSegment(origin, destination, weight);
        }
    }
}
