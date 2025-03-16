using Student_CRUD.Models;

namespace Student_CRUD.DataAccess
{
    public interface IStudentRespository
    {
        List<Students> GetAllStudents();
        Task<Students> GetStudentByIdAsync(int id);
        Task<Students> CreateStudentAsync(Students student);
        Task<bool> UpdateStudentAsync(Students student);
        Task<bool> DeleteStudentAsync(int id);
    }
}
