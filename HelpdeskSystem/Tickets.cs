using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace HelpdeskSystem
{
    public class Tickets
    {
        [PrimaryKey, AutoIncrement]
        public int ticketsId { get; set; }

        public string title { get; set; }

        public string priority { get; set; }

        public string status { get; set; }
    }
}
