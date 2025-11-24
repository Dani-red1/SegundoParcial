using CampusTech.Models;
using System.Collections.Generic;
using System.Linq;

namespace CampusTech.Data
{
    public class ReservationRepository
    {
        private static List<Reservation> _reservations = new List<Reservation>();

        public IEnumerable<Reservation> GetAll() => _reservations;

        public string Add(Reservation r)
        {
            if (_reservations.Any(x => x.ReservationCode == r.ReservationCode))
                return "El código de reserva ya existe.";

            if (r.EndTime <= r.StartTime)
                return "La hora de fin debe ser mayor a la hora de inicio.";

            _reservations.Add(r);
            return "OK";
        }
    }
}