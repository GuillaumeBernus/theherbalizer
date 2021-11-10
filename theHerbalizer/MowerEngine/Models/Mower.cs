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

        public Lawn Lawn { get; set; }

        [Required]
        [JsonPropertyName("startposition")]
        public MowerPosition Position { get; set; }

        [Required]
        public List<MowerAction> Route { get; set; }

        public Mower Run ()
        {
            foreach (var action in this.Route)
            {
                ApplyAction(Lawn,action);
            }
            return this;
        }

        private void ApplyAction(Lawn lawn, MowerAction action)
        {
            var possiblePosition = this.Position.CloneAndApplyAction(action);

            if (action != MowerAction.F || lawn.Contains(possiblePosition.Coordinates))
            {
                this.Position = possiblePosition;
            }
        }
    }
}