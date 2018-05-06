using System;
namespace TransactionelExos.Models
{
    public class Command
    {
        public Receiver receiver;


        public Command(Receiver re)
        {
            this.receiver = re;
        }

    }
}
