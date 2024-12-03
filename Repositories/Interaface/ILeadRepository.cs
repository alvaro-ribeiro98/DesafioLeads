using DesafioLeads.Models;

namespace DesafioLeads.Repositories.Interaface
{
    public interface ILeadRepository
    {
        Task<List<Lead>> GetInvitedLeads();
        Task<List<Lead>> GetAcceptedLeads();
        Task<bool> AcceptedLead(int leadId);
        Task<bool> DeclinedLead(int leadId);
    }
}
