using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Library.Domain
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Destination { get; set; }
        public string Classe { get; set; }

        virtual public ICollection<ReservationTicket> reservationTickets { get; set; }
    }
}
