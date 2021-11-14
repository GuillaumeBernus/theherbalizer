using MowerEngine.Models.MoveHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MowerEngine.Models
{
    /// <summary>
    /// Class Mower.
    /// </summary>
    public class Mower
    {
        /// <summary>
        /// Gets or sets the lawn.
        /// </summary>
        /// <value>The lawn.</value>
        public Lawn Lawn { get; set; }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>The position.</value>
        [Required]
        public MowerPosition Position { get; set; }

        /// <summary>
        /// Gets the travel.
        /// </summary>
        /// <value>The travel.</value>
        public List<Move> Travel => TravelParser.Parse(Route);

        /// <summary>
        /// Gets or sets the route.
        /// </summary>
        /// <value>The route.</value>
        [Required]
        public string Route { get; set; }

        /// <summary>
        /// Runs this instance.
        /// </summary>
        /// <returns>MowerPosition.</returns>
        public MowerPosition Run()
        {
            var position = Position.Clone() as MowerPosition;

            foreach (var move in Travel)
            {
                position = MoveHandlerFactory.GetMoveHandler(move).MoveMower(position, Lawn, move);
            }

            return position;
        }
    }
}