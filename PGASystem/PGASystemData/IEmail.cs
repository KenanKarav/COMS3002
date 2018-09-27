using System;
namespace PGASystemData
{
    public interface IEmail
    {
            void sendEmail(String toEmailAddress, String toName, String  subject, String body);
    }
}
