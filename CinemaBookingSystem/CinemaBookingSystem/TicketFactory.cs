
namespace CinemaBookingSystem
{

    class TicketFactory
    {
        public static Ticket CreateSwiftCar(TicketType type, Movie movie)
        {
            Ticket ticket = null;

            switch (type)
            {
                case TicketType.KIDS: ticket = new KidsTicket(movie, 5);
                    break;
                case TicketType.STUDENT: ticket = new StudentsTicket(movie, 6);
                    break;
                case TicketType.BASIC: ticket = new BaseTicket(movie, 4);
                    break;
            }
            return ticket;
        }
    }
}
