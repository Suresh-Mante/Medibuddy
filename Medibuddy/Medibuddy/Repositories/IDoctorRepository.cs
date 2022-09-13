using Medibuddy.Models;
namespace Medibuddy.Repositories
{
    public interface IDoctorRepository
    {

        public Task<Response<Doctor>> Create(Doctor doctor);
        public Task<Response<Doctor>> Get(int ID);
        public Task<Response<Doctor>> Get();
        public Task<Response<Doctor>> Update(int ID, Doctor doctor);
        public Task<Response<Doctor>> Delete(int ID);
    }
}
