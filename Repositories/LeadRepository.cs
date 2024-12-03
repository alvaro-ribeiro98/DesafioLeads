using System.Net;
using System.Net.Mail;
using System.Text;
using DesafioLeads.Data;
using DesafioLeads.Models;
using DesafioLeads.Repositories.Interaface;
using Microsoft.EntityFrameworkCore;

namespace DesafioLeads.Repositories
{
    public class LeadRepository : ILeadRepository
    {
        private readonly SystemLeadContext _dbContext;

        public LeadRepository(SystemLeadContext systemLeadContext)
        {
            _dbContext = systemLeadContext;
        }

        public async Task<List<Lead>> GetAcceptedLeads()
        {
            var listAcceptedLead = await _dbContext.Leads.Where(w => w.Status.Equals("Accepted")).ToListAsync();

            return listAcceptedLead;
        }

        public async Task<List<Lead>> GetInvitedLeads()
        {
            var listInvitedLead = await _dbContext.Leads.Where(w => w.Status.Equals("Invited")).ToListAsync();

            return listInvitedLead;
        }
        public async Task<bool> AcceptedLead(int leadId)
        {
            try
            {
                var updateLead = await _dbContext.Leads.FirstOrDefaultAsync(f => f.Id == leadId);

                if (updateLead != null) { 
                    updateLead.Status = Useful.Status.Accepted;
                    updateLead.Price = updateLead.Price > 500 ? updateLead.Price-(updateLead.Price * 0.1m) : updateLead.Price;

                    _dbContext.Leads.Update(updateLead);
                    _dbContext.SaveChanges();

                    SendEmail(updateLead);
                }
                else
                {
                    throw new Exception($"Lead para o id:{leadId} não foi encontrado");
                }

                return true;
            }
            catch (Exception ex) {
                throw new Exception($"Foi apresentado o seguinte erro:{ex}");
            }
        }

        public async Task<bool> DeclinedLead(int leadId)
        {
            try
            {
                var updateLead = await _dbContext.Leads.FirstOrDefaultAsync(f => f.Id == leadId);

                if (updateLead != null)
                {
                    updateLead.Status = Useful.Status.Declined;
                    _dbContext.Leads.Update(updateLead);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception($"Lead para o id:{leadId} não foi encontrado");
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Foi apresentado o seguinte erro:{ex}");
            }
        }

        public async Task<bool> SendEmail(Lead acceptedLead)
        {
            try
            {
                MailMessage emailMessage = new MailMessage();
                var smtpClient = new SmtpClient(Useful.SMTPConfig.Outlook,587);
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(Useful.SendEmail.Email, Useful.SendEmail.Senha);
                emailMessage.From = new MailAddress(Useful.SendEmail.Email, "Novo Pedido");
                emailMessage.Body = $"<p>Pedido {acceptedLead.Id}.</p> <p>Nome:{acceptedLead.FullName}.</p> <p>Endereço:{acceptedLead.Suburb}.</p> <p>Descrição: {acceptedLead.Description}.</p> <p>Contato:{acceptedLead.PhoneNumber}.</p>";
                emailMessage.Subject = $"Pedido do(a) cliente: {acceptedLead.FirstName}";
                emailMessage.SubjectEncoding = Encoding.GetEncoding("UTF-8");
                emailMessage.BodyEncoding = Encoding.GetEncoding("UTF-8");
                emailMessage.IsBodyHtml = true;
                emailMessage.Priority = MailPriority.Normal;
                emailMessage.To.Add(Useful.SendEmail.EmailRecive);
                smtpClient.Send(emailMessage);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Foi apresentado o seguinte erro:{ex}");
            }
        }

    }
}
