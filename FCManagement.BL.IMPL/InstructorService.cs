using FCManagement.BL.ABSTRACT;
using FCManagement.DAL.ABSTRACT;
using FCManagement.Entities;
using FCManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCManagement.BL.IMPL
{
    public class InstructorService : IInstructorService
    {
        private readonly IInstructorRepository _instructorRepository;

        public InstructorService(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        public async Task<int> CountAllAsync()
        {
            return await _instructorRepository.CountAllAsync();
        }

        public async Task CreateAsync(InstructorDTO entity)
        {
            Instructor dbEntity = new Instructor()
            {
                FullName = entity.FullName,
                Gender = entity.Gender,
                Email = entity.Email,
                HomeAddress = entity.HomeAddress,
                PhoneNumber = entity.PhoneNumber
            };

            await _instructorRepository.CreateAsync(dbEntity);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _instructorRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<InstructorDTO>> GetAllAsync()
        {
            return (await _instructorRepository.GetAllAsync()).Select
                (m => new InstructorDTO()
                {
                    InstructorId = m.InstructorId,
                    FullName = m.FullName,
                    Gender = m.Gender,
                    Email = m.Email,
                    HomeAddress = m.HomeAddress,
                    PhoneNumber = m.PhoneNumber
                });
        }

        public async Task<InstructorDTO> GetByIdAsync(Guid id)
        {
            Instructor fromDb = await _instructorRepository.GetByIdAsync(id);

            InstructorDTO instructorDTO = new InstructorDTO()
            {
                InstructorId = fromDb.InstructorId,
                FullName = fromDb.FullName,
                Gender = fromDb.Gender,
                Email = fromDb.Email,
                HomeAddress = fromDb.HomeAddress,
                PhoneNumber = fromDb.PhoneNumber
            };
            return instructorDTO;
        }

        public async Task<bool> UpdateAsync(InstructorDTO entity)
        {
            var instructor = await _instructorRepository.GetByIdAsync(entity.InstructorId);

            instructor.InstructorId = entity.InstructorId;
            instructor.FullName = entity.FullName;
            instructor.Gender = entity.Gender;
            instructor.Email = entity.Email;
            instructor.HomeAddress = entity.HomeAddress;
            instructor.PhoneNumber = entity.PhoneNumber;
            
            return await _instructorRepository.UpdateAsync(instructor);
        }
    }
}
