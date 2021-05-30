using System;
using System.Net.Mail;
using System.Net;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace securityalarm
{
    class Sms
    {
        public string accountSID {get; private set;}
        public string authToken {get; private set;}
        public string fromNumber {get; private set;}

        public Sms (string accID, string accAuth, string accFromNumber) {
            accountSID = accID;
            authToken = accAuth;
            fromNumber = accFromNumber;
        }

        public MessageResource sendSms(string body, string toNumber){
        
            MessageResource message = null;

            try
            {
                TwilioClient.Init(accountSID, authToken);
                Console.WriteLine("Sending...");

                message = MessageResource.Create(
                    body: body,
                    from: new Twilio.Types.PhoneNumber(fromNumber),
                    to: new Twilio.Types.PhoneNumber(toNumber)
                );

            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
            }
            
            return message;
        }
    }
}
