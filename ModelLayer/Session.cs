using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Session
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string SessionID { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public bool FlLogin { get; set; }

    }
}
