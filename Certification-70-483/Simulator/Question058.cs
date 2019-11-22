using Certification_70_483.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Certification_70_483.Simulator
{
    public class Question058 : Starting
    {
        public Question058(params string[] args) : base(args)
        {
        }
        public override void Start(params string[] args)
        {
        }


        public enum Compass
        {
            North, 
            South,
            East,
            West
        }

        public void DoWork()
        {
            var location = new Location {
                Label = "",
                Direction = Compass.South
            };
            new DataContractSerializer(typeof(Location));
        }


        [DataContract]
        public class Location
        {
            [DataMember]
            public string Label { get; set; }
            public Compass Direction { get; set; }
        }

    }

    
}
