using Bogus;
using Microsoft.EntityFrameworkCore;
using Seeder;
using Tp2.Models;

using var context = DbContextFactory.CreateDbContext();

// Effacer les donnees générees par le Seeder
context.Moniteurs.RemoveRange(context.Moniteurs);
context.Utilisateurs.RemoveRange(context.Utilisateurs);
context.SaveChanges();

// Utilisateurs enfants
var utilisateursEnfantsFaker = new Faker<Utilisateurs>()
    .RuleFor(x => x.Id, f => 0)
    .RuleFor(x => x.Prenom, f => f.Name.FirstName())
    .RuleFor(x => x.Nom, f => f.Name.LastName())
    .RuleFor(x => x.DateNaissance, f => f.Date.Between(new DateTime(2013, 1, 1), new DateTime(2023, 1, 1)))
    .RuleFor(x => x.DateCreationCompte, f => f.Date.Between(new DateTime(2023, 1, 1), DateTime.Now))
    .Generate(500);

context.Utilisateurs.AddRange(utilisateursEnfantsFaker);
context.SaveChanges();

// Utilisateurs moniteurs
var utilisateursFaker = new Faker<Utilisateurs>()
    .RuleFor(x => x.Id, f => 0)
    .RuleFor(x => x.Prenom, f => f.Name.FirstName())
    .RuleFor(x => x.Nom, f => f.Name.LastName())
    .RuleFor(x => x.DateNaissance, f => f.Date.Between(new DateTime(2003, 1, 1), new DateTime(2010, 1, 1)))
    .RuleFor(x => x.DateCreationCompte, f => f.Date.Between(new DateTime(2023, 1, 1), DateTime.Now))
    .Generate(10);

context.Utilisateurs.AddRange(utilisateursFaker);
context.SaveChanges();

// Moniteurs
int compteur = 0;

var moniteursFaker = new Faker<Moniteurs>()
    .RuleFor(x => x.Id, f => 0)
    .RuleFor(x => x.Utilisateur, f => utilisateursFaker[compteur++])
    .RuleFor(x => x.NoLicence, f => f.Random.Number(1000, 10000).ToString())
    .Generate(10);

context.Moniteurs.AddRange(moniteursFaker);
context.SaveChanges();
