using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Lawn.API.Models
{
    /// <summary>
    /// Class Lawn.
    /// </summary>
    public class LawnCommand
    {
        /// <summary>
        /// Gets or sets the upper rigth corner.
        /// </summary>
        /// <value>The upper rigth corner.</value>
        [Required]
        public PointViewModel UpperRigthCorner { get; set; }

        /// <summary>
        /// Gets or sets the mowers.
        /// </summary>
        /// <value>The mowers.</value>
        [Required]
        public List<MowerViewModel> Mowers { get; set; }
    }
}