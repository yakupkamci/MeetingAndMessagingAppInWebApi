
namespace SahaBTMeet.DTO
{
    public class DepartmanDTO
    {
        public string Name { get; set; }


        public DepartmanDTO()
        {
            
        }
        public DepartmanDTO(Departman departman)
        {
            if(departman != null)
            {
                this.Name = departman.Name;
            }
        }
    }
    
}