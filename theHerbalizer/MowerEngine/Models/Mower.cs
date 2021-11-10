using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MowerEngine.Models
{

    public class Mower
    {

        private Guid _mowerId = Guid.NewGuid();

        public Guid MowerId { get => _mowerId; }

        [Required]
        [JsonPropertyName("startposition")]
        public MowerPosition Position { get; set; }

        [Required]
        public List<MowerAction> Route { get; set; }

        public Mower Run (Lawn lawn)
        {
            foreach (var action in this.Route)
            {
                ApplyAction(lawn,action);
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