namespace DataAccess.Extensions;

using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Citizen>().HasData(
            new Citizen(
                Guid.NewGuid(),
                "Ilia",
                "Shavirin",
                19,
                CitizenSex.Male),
            new Citizen(
                Guid.NewGuid(),
                "Nikita",
                "Bylym",
                27,
                CitizenSex.Male),
            new Citizen(
                Guid.NewGuid(),
                "Bogdan",
                "Soloviov",
                44,
                CitizenSex.Male),
            new Citizen(
                Guid.NewGuid(),
                "Olga",
                "Safronova",
                24,
                CitizenSex.Female),
            new Citizen(
                Guid.NewGuid(),
                "Anna",
                "Tubolova",
                31,
                CitizenSex.Female),
            new Citizen(
                Guid.NewGuid(),
                "Ihor",
                "Trubachov",
                16,
                CitizenSex.Male)
        );
    }
}