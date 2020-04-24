using System;
using System.Collections.Generic;
using System.Text;

namespace ThreeLayers.Entities
{
    public class Award
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public Award(string title)
        {
            Title = title;
        }

        public Award() {}

        public override string ToString()
        {
            return $"Award" + Environment.NewLine +
                $"Id:{Id}" + Environment.NewLine +
                $"Title: {Title}" + Environment.NewLine;
        }
    }
}