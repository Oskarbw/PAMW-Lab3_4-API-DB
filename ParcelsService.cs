
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace PAMW3_API
{
    public class ParcelsService
    {
        private readonly PostOfficeContext _db;

        public ParcelsService(PostOfficeContext db)
        {
            _db = db;
        }

        public ServiceResult<Parcel> Create(Parcel parcel)
        {
            var result = validateParcel(parcel);
            if (result.IsSuccessful) 
            {
                _db.Parcels.Add(parcel);
            }
            return result;
        }

        public ServiceResult<Parcel> Read(int id) 
        {
            var query = from parcel in _db.Parcels
                        where parcel.Id == id
                        select parcel;
            var result = query.FirstOrDefault();
            _db.Parcels.Remove(result);
            _db.SaveChanges();

            return new ServiceResult<Parcel>()
            {
                Data = result,
                IsSuccessful = true,
                ErrorMessage = null
            };
        }

        public ServiceResult<List<Parcel>> ReadAll()
        {
            return new ServiceResult<List<Parcel>>()
            {
                Data = new List<Parcel>()
                {
                    new Parcel() {
                        Id = 1,
                        Sender = "Wysylajacy",
                        Receiver = "Odbierajacy",
                        Weight = 14
                    },
                    new Parcel() {
                        Id = 2,
                        Sender = "Wysylajacy",
                        Receiver = "Odbierajacy",
                        Weight = 15
                    },
                    new Parcel() {
                        Id = 3,
                        Sender = "Wysylajacy",
                        Receiver = "Odbierajacy",
                        Weight = 16
                    }

                },
                IsSuccessful = true,
                ErrorMessage = null
            };
        }

        public ServiceResult<Parcel> Update(int id, Parcel parcel)
        {
            var result = validateParcel(parcel);
            if (result.IsSuccessful)
            {
                //update in database
            }
            return result;
        }

        public ServiceResult<Parcel> Delete(int id)
        {
            return new ServiceResult<Parcel>()
            {
                Data = new Parcel()
                {
                    Id = id,
                    Sender = "Wysylajacy",
                    Receiver = "Odbierajacy",
                    Weight = 13
                },
                IsSuccessful = true,
                ErrorMessage = null
            };
        }

        private ServiceResult<Parcel> validateParcel(Parcel parcel)
        {
            if (parcel.Sender == null || parcel.Receiver == null) 
            {
                return new ServiceResult<Parcel>()
                {
                    Data = null,
                    IsSuccessful = false,
                    ErrorMessage = "Missing data about sender and/or receiver"
                };
            }
            if (parcel.Weight > 25)
            {
                return new ServiceResult<Parcel>()
                {
                    Data = null,
                    IsSuccessful = false,
                    ErrorMessage = "The parcel is too heavy"
                };
            }
            return new ServiceResult<Parcel>()
            {
                Data = parcel,
                IsSuccessful = true,
                ErrorMessage = null
            };
        }
    }
}
