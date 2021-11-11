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
        public Mower(Lawn lawn)
        {
            this.Lawn = lawn;
        }

        private Guid _mowerId = Guid.NewGuid();

        public Guid MowerId { get => _mowerId; }

        public Lawn Lawn { get;  set; }

        [Required]
        [JsonPropertyName("startposition")]
        public MowerPosition Position { get; set; }

        [Required]
        public string Route { get; set; }


        public Mower Run ()
        {
            var moves = TravelParser.Parse(Route);

            foreach(var move in moves)
            {
                MoveHandlerFactory.GetMoveHandler(move).MoveMower(this, move);
            }
          
            return this;
        }


    }
}