using FCManagement.BL.ABSTRACT;
using FCManagement.DAL.ABSTRACT;
using FCManagement.Entities;
using FCManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FCManagement.BL.IMPL
{
    public class InstructorService : IInstructorService
    {
        private readonly IInstructorRepository _instructorRepository;

        public InstructorService(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        public void AddObject(InstructorDTO instructor)
        {
            Instructor dbEntity = new Instructor()
            {
                FullName = instructor.FullName,
                Gender = instructor.Gender,
                Email = instructor.Email,
                HomeAdress = instructor.HomeAdress,
                PhoneNumber = instructor.PhoneNumber
            };

            _instructorRepository.Add(dbEntity);
            _instructorRepository.Save();
        }

        public void DeleteObject(int id)
        {
            _instructorRepository.Delete(id);
        }

        public IEnumerable<InstructorDTO> GetAll()
        {
            return _instructorRepository.GetAll().Select(m => new InstructorDTO()
            {
                InstructorId = m.InstructorId,
                FullName = m.FullName,
                Gender = m.Gender,
                Email = m.Email,
                HomeAdress = m.HomeAdress,
                PhoneNumber = m.PhoneNumber
            });
        }

        public InstructorDTO GetElementById(int id)
        {
            Instructor fromDb = _instructorRepository.GetById(id);

            InstructorDTO instructorDTO = new InstructorDTO()
            {
                InstructorId = fromDb.InstructorId,
                FullName = fromDb.FullName,
                Gender = fromDb.Gender,
                Email = fromDb.Email,
                HomeAdress = fromDb.HomeAdress,
                PhoneNumber = fromDb.PhoneNumber
            };
            return instructorDTO;
        }

        public void UpdateObject(InstructorDTO instructor)
        {
            Instructor instructorBase = new Instructor()
            {
                InstructorId = instructor.InstructorId,
                FullName = instructor.FullName,
                Gender = instructor.Gender,
                Email = instructor.Email,
                HomeAdress = instructor.HomeAdress,
                PhoneNumber = instructor.PhoneNumber
            };
            _instructorRepository.Update(instructorBase);
        }
    }
}
