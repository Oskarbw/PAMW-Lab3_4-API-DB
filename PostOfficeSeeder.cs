using Bogus;
using Microsoft.OpenApi.Models;

namespace PAMW3_API;

public class PostOfficeSeeder
{
    private readonly PostOfficeContext _db;

    public PostOfficeSeeder(PostOfficeContext db)
    {
        _db = db;
    }

    public void Seed()
    {

        if (_db.Database.CanConnect())
        {
            if (!_db.Parcels.Any())
            {
                var parcels = GenerateParcels();

                _db.Parcels.AddRange(parcels);
                _db.SaveChanges();
            }
        }
    }


    private Parcel GenerateParcel(int id)
    {
        var parcelFaker = new Faker<Parcel>()
            .UseSeed(05112023)
            .RuleFor(x => x.Id, x => id++)
            .RuleFor(x => x.Sender, x => x.Person.FullName)
            .RuleFor(x => x.Receiver, x => x.Person.FullName)
            .RuleFor(x => x.Weight, x => x.Random.Int(1, 24));
        return parcelFaker.Generate();
    }

    private List<Parcel> GenerateParcels()
    {
        int id = 1;
        var parcelFaker = new Faker<Parcel>()
            .UseSeed(05112023)
            .RuleFor(x => x.Id, x => id++)
            .RuleFor(x => x.Sender, x => x.Person.FullName)
            .RuleFor(x => x.Receiver, x => x.Person.FullName)
            .RuleFor(x => x.Weight, x => x.Random.Int(1, 24));
        return parcelFaker.Generate(16);
    }
}
