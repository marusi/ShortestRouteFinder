using System;
using System.Runtime.Serialization;

namespace Algorithms.ShortestRoute.Dijkstra
{
    [Serializable]
    internal class PathFinderException : Exception
    {
        public PathFinderException()
        {
        }

        public PathFinderException(string message) : base(message)
        {
        }

        public PathFinderException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PathFinderException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}