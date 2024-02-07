﻿namespace BarberTech.Domain.Entities
{
    public class Feedback : Entity
    {
        public Guid UserId { get; set; }

        public User User { get; set; }

        public Guid HaircutId { get; set; }

        public Haircut Haircut { get; set; }

        public Guid BarberId { get; set; }

        public Barber Barber { get; set; }

        public Guid EstablishmentId { get; set; }

        public Establishment Establishment { get; set; }

        public int QntStarsBarber { get; set; }

        public int QntStarsHaircut { get; set; }

        public int QntStarsEstablishment { get; set; }

        public string? Comment { get; set; }

        public Feedback(
            User user, 
            Barber barber,
            Haircut haircut,
            Establishment establishment,
            int qntStarsBarber,
            int qntStarsHaircut,
            int qntStarsEstablishment,
            string? comment)
        {
            User = user;
            UserId = user.Id;
            Barber= barber;
            BarberId = barber.Id;
            Haircut= haircut;
            HaircutId = haircut.Id;
            Establishment= establishment;
            EstablishmentId = establishment.Id;
            QntStarsBarber = qntStarsBarber;
            QntStarsHaircut = qntStarsHaircut;
            QntStarsEstablishment = qntStarsEstablishment;
            Comment = comment;
        }

        public Feedback()
        {
        }

        public double GetStarsAverage()
        {
            return (QntStarsBarber + QntStarsHaircut + QntStarsEstablishment) / 3;
        }
    }
}
