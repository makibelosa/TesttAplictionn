using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesttAplictionn.Interface;
using TesttAplictionn.Models;

namespace TesttAplictionn.Repository
{
    public class GenderRepository : IGenderRepository
    {


        private readonly TesttDBContext _context;

        public GenderRepository(TesttDBContext context)
        {
            _context = context;
        }

        public void DeleteGender(int GenderId)
        {
            Gender gender = _context.Genders.Find(GenderId);
            _context.Genders.Remove(gender);
        }

        public IEnumerable<Gender> GetAllGender()
        {
            return _context.Genders.ToList();
        }

        public Gender GetGenderById(int GenderId)
        {
            return _context.Genders.Find(GenderId);
        }

        public void InsertGender(Gender gender)
        {
            _context.Genders.Add(gender);
        }

        public void SaveGender()
        {
            _context.SaveChanges();
        }

        public void UpdateGender(Gender gender)
        {
            _context.Entry(gender).State = EntityState.Modified;
        }
    }
}
