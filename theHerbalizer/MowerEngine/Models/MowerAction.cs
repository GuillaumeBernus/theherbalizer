using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MowerEngine.Models
{
    public abstract class MowerActionBase
    {
        public Action Action { get; set; }

        public abstract MowerPosition Apply(MowerPosition start);
    }

    public  class MowerActionL: MowerActionBase
    {
        public override MowerPosition Apply(MowerPosition start)
        {
            

        }
    }
