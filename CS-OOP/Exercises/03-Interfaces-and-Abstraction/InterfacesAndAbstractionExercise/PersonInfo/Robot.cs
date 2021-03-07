using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public class Robot : IIdentifiable
    {
        private string model;
        public Robot(string model, string id)
        {
            this.model = model;
            Id = id;
        }
        public string Id { get; set; }
    }
}
