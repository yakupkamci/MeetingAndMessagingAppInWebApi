
namespace SahaBTMeet.Helper.Extension
{
    public static class ModelToModelDTO
    {
        public static UserDTO UserToUserDTO(this User user)
        {
            return new UserDTO(user);
        }

        public static List<UserDTO> UserToUserDTO(this List<User> users)
        {
            List<UserDTO> NewUserDTOs = new List<UserDTO>();
            foreach(User incominguser in users)
            {
                NewUserDTOs.Add(new UserDTO(incominguser));                
            }

            return NewUserDTOs;
        }
    
        public static AccountDTO AccountToAccountDTO(this Account accounts)
        {
            return new AccountDTO(accounts);
        }

        public static List<AccountDTO> AccountToAccountDTO(this List<Account> accounts)
        {
            List<AccountDTO> NewAccountDTOs = new List<AccountDTO>();
            foreach(Account InComingAccount in accounts)
            {
                NewAccountDTOs.Add(new AccountDTO(InComingAccount));                
            }

            return NewAccountDTOs;
        }

        public static IndividualMessageDTO IndividualMessageToDTO(this IndividualMessage message)
        {
            return new IndividualMessageDTO(message);
        }

        public static List<IndividualMessageDTO> IndividualMessageToDTO(this List<IndividualMessage> messages)
        {
            List<IndividualMessageDTO> NewAccountDTOs = new List<IndividualMessageDTO>();
            foreach(IndividualMessage InComingMessages in messages)
            {
                NewAccountDTOs.Add(new IndividualMessageDTO(InComingMessages));                
            }

            return NewAccountDTOs;
        }

        public static MeetingDTO MeetingToMeetingDTO(this Meeting meeting)
        {
            return new MeetingDTO(meeting);
        }

        public static List<MeetingDTO> MeetingToMeetingDTO(this List<Meeting> meetings)
        {
            List<MeetingDTO> NewMeetingDTOs = new List<MeetingDTO>();
            foreach(Meeting InComingMeeting in meetings)
            {
                NewMeetingDTOs.Add(new MeetingDTO(InComingMeeting));                
            }

            return NewMeetingDTOs;
        }

        public static RoleDTO RoleToRoleDTO(this Role role)
        {
            return new RoleDTO(role);
        }

        public static List<RoleDTO> RoleToRoleDTO(this List<Role> roles)
        {
            List<RoleDTO> NewRoleDTOs = new List<RoleDTO>();
            foreach(Role InComingRole in roles)
            {
                NewRoleDTOs.Add(new RoleDTO(InComingRole));                
            }

            return NewRoleDTOs;
        }

        public static DepartmanDTO DepartmanToDTO(this Departman departman)
        {
            return new DepartmanDTO(departman);
        }

        public static List<DepartmanDTO> DepartmanToDTO(this List<Departman> departmans)
        {
            List<DepartmanDTO> NewDepartmanDTOs = new List<DepartmanDTO>();
            foreach(Departman incomingdepartman in departmans)
            {
                NewDepartmanDTOs.Add(new DepartmanDTO(incomingdepartman));                
            }

            return NewDepartmanDTOs;
        }

        public static AddressDTO AddressToDTO(this Address address)
        {
            return new AddressDTO(address);
        }

        public static List<AddressDTO> AddressToDTO(this List<Address> addresses)
        {
            List<AddressDTO> NewAddressDTOs = new List<AddressDTO>();
            foreach(Address incomingaddress in addresses)
            {
                NewAddressDTOs.Add(new AddressDTO(incomingaddress));                
            }

            return NewAddressDTOs;
        }
    }
}