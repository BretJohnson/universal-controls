using System;
using Microsoft.CodeAnalysis;

namespace UniversalUI.SourceGenerator
{
    public class UserViewableException : Exception
    {
        public string Id { get; }

        public Location? Location { get; }

        public UserViewableException(string message) : this("MISSING", message)
        {
        }

        public UserViewableException(string id, string message, Location? location = null) : base(message)
        {
            Id = id;
            Location = location;
        }
    }
}