
namespace SahaBTMeet.DTO
{
    public class RoleDTO
    {
        public string Name { get; set; }

        public RoleDTO()
        {
            
        }
        public RoleDTO(Role role)
        {
            this.Name = role.Name;
        }
    }
    
}