
namespace SahaBTMeet.Repositories
{
    public class MeetingRepository : IMeetingRepository
    {
        private readonly SahaBTMeetContext _context;
        public MeetingRepository(SahaBTMeetContext context)
        {
            _context = context;
        }

        public async Task<Meeting> AddParticipantToMeetingLaterOperation(Meeting Meeting, List<Account> Accounts)
        {
            string MeetLink = string.Format("http://www.sahabtmeeting/{0}/{1}",Meeting.Name.Replace(" ",""),Meeting.Id);
            foreach(Account tempAccount in Accounts)
            {
                Account InComingAccount = await GetAccountById(tempAccount.Id);
                InComingAccount.AccountMeeting.Add(
                    new AccountMeeting{ Account = InComingAccount, Meeting = Meeting, CreatingDate = DateTime.Now, MeetingLink = MeetLink});
            }
            await _context.SaveChangesAsync();
            return Meeting;
        }

        public async Task<Meeting> CancelMeetingOperation(Meeting Meeting)
        {
            string content = string.Format("{0} Tarih ve Saatinde Baslayacak {1} Meet Iptal Edilmistir !!!",
                                            Meeting.StartTime.ToString("g"),Meeting.Name);
            
            Meeting InComingMeeting = await _context.Meetings.SingleOrDefaultAsync(q=>q.Id == Meeting.Id);
            _context.Meetings.Remove(InComingMeeting);

            Account OrganizerAccount = await GetAccountById(Meeting.OrganizerId ?? 0);
            foreach(var coming in InComingMeeting.AccountMeeting)
            {
                if(Meeting.OrganizerId != coming.AccountId)
                {   
                    OrganizerAccount.AccountIndividualMessages.Add(
                        new AccountIndividualMessage { Account = OrganizerAccount, 
                        IndividualMessage = new IndividualMessage(0,content,coming.AccountId,false), CreationDate = DateTime.Now });
                }                
            }           
            await _context.SaveChangesAsync();

            return Meeting;
        }

        public async Task<Meeting> CreateMeetingOperation(Account Account, MeetingDIO meetingDIO)
        {            
            int LastMeetingId = (await _context.Meetings.MaxAsync(x=>(int?)x.Id) ?? 0) +1;
            string MeetLink = string.Format("http://www.sahabtmeeting/{0}/{1}",meetingDIO.Name.Replace(" ",""),LastMeetingId);
            Meeting Meeting = new Meeting(meetingDIO);
            if(meetingDIO.Participants != null)
            {
                foreach(Account tempAccount in meetingDIO.Participants)
                {
                    Account incomingAccount = await GetAccountById(tempAccount.Id);
                    incomingAccount.AccountMeeting.Add(
                        new AccountMeeting{ Account = incomingAccount, Meeting = Meeting, CreatingDate = DateTime.Now, MeetingLink = MeetLink});
                }                
            }
            Account.AccountMeeting.Add(
                new AccountMeeting{ Account = Account, Meeting = Meeting, CreatingDate = DateTime.Now, MeetingLink = MeetLink});

            await _context.SaveChangesAsync();

            return Meeting;
        }

        public async Task<Meeting> EndTheMeetingOperation(Meeting Meeting)
        {
            Meeting InComingMeeting = await _context.Meetings.SingleOrDefaultAsync(q=>q.Id == Meeting.Id);
            InComingMeeting.IsCompleted = true;
            await _context.SaveChangesAsync();
            return InComingMeeting;
        }

        public async Task<Account> GetAccountById(int Id)
        {
            return await _context.Accounts.SingleOrDefaultAsync(q=>q.Id == Id);
        }

        public async Task<List<Meeting>> GetAllMeetingOperation()
        {            
            return  await (from meet in _context.Meetings.Include(x=>x.AccountMeeting).ThenInclude(x=>x.Account)
                            join accMeet in _context.AccountMeetings on meet.Id equals accMeet.MeetingId
                            select meet).Distinct().ToListAsync();
        }

        public async Task<Meeting> GetMeetingById(int Id)
        {
            return await _context.Meetings.Include(x=>x.AccountMeeting).ThenInclude(x=>x.Account).SingleOrDefaultAsync(q=>q.Id == Id);                        
        }

        public async Task<List<Meeting>> GetMeetingByOrganizer(Account Account)
        {
            return await _context.Meetings.Include(x=>x.AccountMeeting).ThenInclude(x=>x.Account)
                        .Where(q=>q.OrganizerId == Account.Id).ToListAsync();
        }

        public async Task<List<Meeting>> MyScheduledMeetingByAccount(Account Account)
        {
            return  await (from meet in _context.Meetings.Include(x=>x.AccountMeeting).ThenInclude(x=>x.Account)
                            join accMeet in _context.AccountMeetings on meet.Id equals accMeet.MeetingId
                                where accMeet.AccountId == Account.Id && meet.IsCompleted == false
                                select meet).ToListAsync(); 
        }

        public async Task<Meeting> RemoveParticipantToMeetingOperation(Meeting Meeting, List<Account> Accounts)
        {
            foreach(Account Assignment in Accounts){
                var InComingMeeting = _context.AccountMeetings.SingleOrDefault(x=>x.AccountId == Assignment.Id && x.MeetingId == Meeting.Id);
                Meeting.AccountMeeting.Remove(InComingMeeting);
            }
            await _context.SaveChangesAsync();
            return Meeting; 
        }
    }
}