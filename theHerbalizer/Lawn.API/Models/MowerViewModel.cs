using MowerEngine.Models.MoveHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Lawn.API.Models
{
    /// <summary>
    /// Class Mower.
    /// </summary>
    public record MowerViewModel
    {
        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>The position.</value>
        [Required]
        public MowerPositionViewModel StartPosition { get; set; }

        /// <summary>
        /// Gets or sets the route.
        /// </summary>
        /// <value>The route.</value>
        [Required]
        public string Route { get; set; }
    }
}