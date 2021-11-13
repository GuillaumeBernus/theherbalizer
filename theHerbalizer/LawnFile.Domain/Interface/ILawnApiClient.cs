using LawnFile.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnFile.Domain.Interface
{
    public interface ILawnApiClient
    {
        Task<List<MowerPosition>> TreatLawnDescriptionAsync(Lawn lawn);
    }
}
