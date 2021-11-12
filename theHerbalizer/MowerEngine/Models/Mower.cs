using MowerEngine.Models.MoveHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MowerEngine.Models
{
    public class Mower
    {
        public Mower()
        {
        }

        private Guid _mowerId = Guid.NewGuid();

        public Guid MowerId { get => _mowerId; }

        private Lawn _lawn;
        public Lawn Lawn
        {
            get { return _lawn; }
            set { 
                _lawn = value;
                Destination= this.Run2();
            }
        }

        [Required]
        [JsonPropertyName("startposition")]
        public MowerPosition Position { get; set; }

        public MowerPosition Destination { get; internal set; }
        public List<Move> Travel =>  TravelParser.Parse(Route);

        [Required]
        public string Route { get; set; }

        public Mower Run()
        {
            foreach (var move in Travel)
            {
                MoveHandlerFactory.GetMoveHandler(move).MoveMower(this, move);
            }

            return this;
        }
        private MowerPosition Run2()
        {
            var position = Position with { };
            try
            {
                foreach (var move in Travel)
                {
                    position = MoveHandlerFactory.GetMoveHandler(move).ApplyMove(position, Lawn, move);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return position;
        }
    }
}