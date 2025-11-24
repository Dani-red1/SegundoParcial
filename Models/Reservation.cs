using System;
using System.ComponentModel.DataAnnotations;

namespace CampusTech.Models
{
    public class Reservation
    {
        [Required(ErrorMessage = "El nombre del profesor es obligatorio.")]
        [MinLength(3, ErrorMessage = "El nombre debe tener al menos 3 caracteres.")]
        public string ProfessorName { get; set; }

        [Required(ErrorMessage = "El correo institucional es obligatorio.")]
        [EmailAddress(ErrorMessage = "Debe ingresar un correo válido.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@campus\.edu$",
            ErrorMessage = "El correo debe pertenecer al dominio @campus.edu")]
        public string InstitutionalEmail { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un laboratorio.")]
        public string Lab { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        [DataType(DataType.Date)]
        public DateTime ReservationDate { get; set; }

        [Required(ErrorMessage = "La hora de inicio es obligatoria.")]
        public TimeSpan StartTime { get; set; }

        [Required(ErrorMessage = "La hora de fin es obligatoria.")]
        public TimeSpan EndTime { get; set; }

        [Required(ErrorMessage = "Debe indicar un motivo.")]
        [MinLength(5, ErrorMessage = "El motivo debe tener al menos 5 caracteres.")]
        [MaxLength(200, ErrorMessage = "Máximo 200 caracteres permitidos.")]
        public string Reason { get; set; }

        [Required(ErrorMessage = "Debe ingresar el código de reserva.")]
        [RegularExpression(@"^RES-\d{3}$",
            ErrorMessage = "El formato debe ser RES-### (Ej. RES-001).")]
        public string ReservationCode { get; set; }
    }
}