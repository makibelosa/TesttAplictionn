using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesttAplictionn.Models;

namespace TesttAplictionn.Interface
{
    public interface IGenderRepository
    {
        IEnumerable<Gender> GetAllGender();
        Gender GetGenderById(int GenderId);
        void InsertGender(Gender gender);
        void UpdateGender(Gender gender);
        void DeleteGender(int GenderId);
        void SaveGender();
    }
}
