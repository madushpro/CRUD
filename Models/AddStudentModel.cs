namespace CRUD_opr.Models
{
    public class AddStudentModel
    {
        public Guid Id { get; set; }    // Guid mean : Globally Unique Identifer ex: 123e4567-e89b-12d3-a456-426614174000
        public String Name { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }

    }
}
