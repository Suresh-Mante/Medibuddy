using Medibuddy.DataAccess;
using Medibuddy.Models;
using Medibuddy.Utils;

namespace Medibuddy.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IDepartmentDataAccess _departmentDataAccess;

        public DepartmentRepository(IDepartmentDataAccess departmentDataAccess)
        {
            _departmentDataAccess = departmentDataAccess;
        }

        public async Task<Response<Department>> Create(Department department)
        {
            Response<Department> response = new Response<Department>();

            try
            {
                Department createdDepartment = await _departmentDataAccess.Create(department);
                response.StatusCode = 201;
                response.StatusMessage = HttpMessages.Created;
                response.Record = createdDepartment;
            }
            catch (Exception ex)
            {
                //Write logic to log this exceptions somewhere//

                response.StatusCode = 500;
                response.StatusMessage = HttpMessages.InternalServerError;
            }

            return response;
        }

        public async Task<Response<Department>> Delete(int DepID)
        {
            Response<Department> response = new Response<Department>();

            try
            {
                Department? existingDepartment = await _departmentDataAccess.Get(DepID);
                if (existingDepartment != null)
                {
                    await _departmentDataAccess.Delete(DepID);
                    response.StatusCode = 200;
                    response.StatusMessage = HttpMessages.Created;
                    response.Record = existingDepartment;
                }
                else
                {
                    response.StatusCode = 404;
                    response.StatusMessage = HttpMessages.NotFound;
                }
            }
            catch (Exception ex)
            {
                //Write logic to log this exceptions somewhere//

                response.StatusCode = 500;
                response.StatusMessage = HttpMessages.InternalServerError;
            }

            return response;
        }

        public async Task<Response<Department>> Get(int DepID)
        {
            Response<Department> response = new Response<Department>();

            try
            {
                Department? department = await _departmentDataAccess.Get(DepID);
                if (department != null)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = HttpMessages.Ok;
                    response.Record = department;
                }
                else
                {
                    response.StatusCode = 404;
                    response.StatusMessage = HttpMessages.NotFound;
                }
            }
            catch (Exception ex)
            {
                //Write logic to log this exceptions somewhere//

                response.StatusCode = 500;
                response.StatusMessage = HttpMessages.InternalServerError;
            }

            return response;
        }

        public async Task<Response<Department>> Get()
        {
            Response<Department> response = new Response<Department>();

            try
            {
                List<Department> departments = (await _departmentDataAccess.Get()).ToList();
                response.StatusCode = 200;
                response.StatusMessage = HttpMessages.Ok;
                response.Records = departments;
            }
            catch (Exception ex)
            {
                //Write logic to log this exceptions somewhere//

                response.StatusCode = 500;
                response.StatusMessage = HttpMessages.InternalServerError;
            }

            return response;
        }

        public async Task<Response<Department>> Update(int DepID, Department department)
        {
            Response<Department> response = new Response<Department>();

            try
            {
                Department? existingDepartment = await _departmentDataAccess.Get(DepID);
                if (existingDepartment != null)
                {
                    Department? updatedDepartment = await _departmentDataAccess.Update(DepID, department);
                    response.StatusCode = 201;
                    response.StatusMessage = HttpMessages.Created;
                    response.Record = updatedDepartment;
                }
                else
                {
                    response.StatusCode = 404;
                    response.StatusMessage = HttpMessages.NotFound;
                }
            }
            catch (Exception ex)
            {
                //Write logic to log this exceptions somewhere//

                response.StatusCode = 500;
                response.StatusMessage = HttpMessages.InternalServerError;
            }

            return response;
        }
    }
}
