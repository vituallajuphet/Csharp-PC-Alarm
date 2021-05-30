using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace securityalarm
{
    class Sms
    {
        public string accountSID {get; private set;}
        public string authToken {get; private set;}
        public string fromNumber {get; private set;}

        private string messageBody;
        private string toNumber;

        public Sms (string accID, string accAuth, string accFromNumber) {
            this.accountSID = accID;
            this.authToken = accAuth;
            this.fromNumber = accFromNumber;
        }

        public string msgBody{
            get{return this.messageBody;}
            set{this.messageBody = value;}
        }

        public string tonumber{
            get{return this.toNumber;}
            set{this.toNumber = value;}
        }

        public MessageResource sendSms(){
        
            MessageResource message = null;
            Console.WriteLine("Sending...");
            try
            {
                TwilioClient.Init(accountSID, authToken);

                message = MessageResource.Create(
                    body: this.msgBody,
                    from: new Twilio.Types.PhoneNumber(this.fromNumber),
                    to: new Twilio.Types.PhoneNumber(this.toNumber)
                );

            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Sending failed!");
            }
            
            return message;
        }

    }
}
