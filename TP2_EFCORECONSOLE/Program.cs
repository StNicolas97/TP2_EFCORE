using Bogus;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using TP2_EFCORE.Models;
using TP2_EFCORECONSOLE.data;

namespace TP2_EFCORE
{
    public class Program
    {
        public static void Main()
        {
            using var context = ConsoleDbContext.CreateDbContext();
            context.Moniteurs.RemoveRange(context.Moniteurs);
            context.Utilisateurs.RemoveRange(context.Utilisateurs);
            context.SaveChanges();


            //Faker
            var UtilisateurFaker = new Faker<Utilisateur>("fr")
                .RuleFor(u => u.Prenom, f => f.Name.FirstName())
                .RuleFor(u => u.Nom, f => f.Name.LastName())
                .RuleFor(u => u.DateNaissance, f => f.Date.Between(
                    new DateTime(2013, 01, 01),
                    new DateTime(2023, 01, 01)
                ))
                .RuleFor(u => u.DateCreationCompte, f => f.Date.Between(
                    new DateTime(2023, 01, 01),
                    DateTime.Now
                ));

            var UtilisateurFaker2 = new Faker<Utilisateur>("fr")
                .RuleFor(u => u.Prenom, f => f.Name.FirstName())
                .RuleFor(u => u.Nom, f => f.Name.LastName())
                .RuleFor(c => c.DateNaissance, f => f.Date.Between(
                    new DateTime(2003, 01, 01),
                    new DateTime(2010, 01, 01)
                    ))
                .RuleFor(u => u.DateCreationCompte, f => f.Date.Between(
                    new DateTime(2023, 01, 01),
                    DateTime.Now));

            var utilisateur1 = UtilisateurFaker.Generate(500);
            var utilisateur2 = UtilisateurFaker2.Generate(10);
            context.Utilisateurs.AddRange(utilisateur1);
            context.Utilisateurs.AddRange(utilisateur2);
            context.SaveChanges();

            var idList = utilisateur2.Select(c => c.Id).ToList();



            for (int i = 0; i < 10; i++)
            {
                var faker = new Faker("fr");
                var moniteur = new Moniteur
                {
                    UtilisateurId = idList[i],
                    NoLicence = faker.Random.Int(1000, 10000)
                };
                context.Moniteurs.Add(moniteur);
            }

            
            context.SaveChanges();
        }
    }

}
    

