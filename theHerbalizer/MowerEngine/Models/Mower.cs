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
        /// Initializes a new instance of the <see cref="Mower"/> class.
        /// </summary>
        public Mower()
        {
        }

        /// <summary>
        /// The mower identifier
        /// </summary>
        private Guid _mowerId = Guid.NewGuid();

        /// <summary>
        /// Gets the mower identifier.
        /// </summary>
        /// <value>The mower identifier.</value>
        public Guid MowerId { get => _mowerId; }

        /// <summary>
        /// The lawn
        /// </summary>
        private Lawn _lawn;

        /// <summary>
        /// Gets or sets the lawn.
        /// </summary>
        /// <value>The lawn.</value>
        public Lawn Lawn
        {
            get { return _lawn; }
            set
            {
                _lawn = value;
                Destination = this.Run();
            }
        }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>The position.</value>
        [Required]
        [JsonPropertyName("startposition")]
        public MowerPosition Position { get; set; }

        /// <summary>
        /// Gets the destination.
        /// </summary>
        /// <value>The destination.</value>
        public MowerPosition Destination { get; internal set; }

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
            try
            {
                foreach (var move in Travel)
                {
                    position = MoveHandlerFactory.GetMoveHandler(move).MoveMower(position, Lawn, move);
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