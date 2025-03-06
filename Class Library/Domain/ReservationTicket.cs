using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Library.Domain
{
    public class ReservationTicket
    {
        public DateTime DateReservation { get; set; }
        public float Prix { get; set; }
        public Passenger Passenger { get; set; }

        public Ticket Ticket { get; set; }


        [ForeignKey("Ticket")]
        public int TicketFk { get; set; }
        [ForeignKey("Passenger")]
        public string PassengerFk { get; set; }
    }
}
