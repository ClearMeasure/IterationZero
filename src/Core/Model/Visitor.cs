using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Model
{
    public class Visitor
    {
        [ScaffoldColumn(false)]
        public Guid Id { get; set; }
        public string PathAndQuerystring { get; set; }
        public string LoginName { get; set; }
        public DateTime VisitDate { get; set; }
        public string IpAddress { get; set; }

        [DataType(DataType.MultilineText)]
        public string Browser { get; set; }
        public string FirstName { get; set; }
    }
}