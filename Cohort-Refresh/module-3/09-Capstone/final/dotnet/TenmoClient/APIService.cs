using System;
using System.Collections.Generic;
using RestSharp;
using RestSharp.Authenticators;
using TenmoClient.Data;

namespace TenmoClient
{
    public class APIService
    {
        private readonly static string API_BASE_URL = "https://localhost:44315/";
        private readonly IRestClient client = new RestClient();

        //users endpoints
        public List<User> GetUsers()
        {
            client.Authenticator = new JwtAuthenticator(UserService.GetToken());
            RestRequest request = new RestRequest(API_BASE_URL + "users");
            IRestResponse<List<User>> response = client.Get<List<User>>(request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                Console.WriteLine("An error occurred communicating with the server.");
                return null;
            }
            else if (!response.IsSuccessful)
            {
                Console.WriteLine("An error response was received from the server. The status code is " + (int)response.StatusCode);
                return null;
            }
            else
            {
                return response.Data;
            }
        }


        //transfers endpoint
        public Transfer GetTransfer(int id)
        {
            client.Authenticator = new JwtAuthenticator(UserService.GetToken());
            RestRequest request = new RestRequest(API_BASE_URL + "transfers/" + id);
            IRestResponse<Transfer> response = client.Get<Transfer>(request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                Console.WriteLine("An error occurred communicating with the server.");
                return null;
            }
            else if (!response.IsSuccessful)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine("Transfer not found");
                }
                else
                {
                    Console.WriteLine("An error response was received from the server. The status code is " + (int)response.StatusCode);
                }

                return null;
            }
            else
            {
                return response.Data;
            }
        }

        public Transfer AddTransfer(NewTransfer newTransfer)
        {
            client.Authenticator = new JwtAuthenticator(UserService.GetToken());
            RestRequest request = new RestRequest(API_BASE_URL + "transfers");
            request.AddJsonBody(newTransfer);
            IRestResponse<Transfer> response = client.Post<Transfer>(request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                Console.WriteLine("An error occurred communicating with the server.");
                return null;
            }
            else if (!response.IsSuccessful)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    if (newTransfer.TransferType == TransferType.Request)
                    {
                        Console.WriteLine("The user you're requesting TE bucks from doesn't exist.");
                    }
                    if (newTransfer.TransferType == TransferType.Send)
                    {
                        Console.WriteLine("The user you're sending TE bucks to doesn't exist.");
                    }
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.PaymentRequired)
                {
                    if (newTransfer.TransferType == TransferType.Request)
                    {
                        Console.WriteLine("The user you're requesting TE bucks from has insufficient funds.");
                    }
                    if (newTransfer.TransferType == TransferType.Send)
                    {
                        Console.WriteLine("You have insufficient funds to send this amount.");
                    }
                }
                else
                {
                    Console.WriteLine("An error response was received from the server. The status code is " + (int)response.StatusCode);
                }

                return null;
            }
            else
            {
                return response.Data;
            }
        }

        public Transfer ApproveTransfer(int transferId)
        {
            client.Authenticator = new JwtAuthenticator(UserService.GetToken());
            RestRequest request = new RestRequest(API_BASE_URL + "transfers/" + transferId + "/approve");
            IRestResponse<Transfer> response = client.Put<Transfer>(request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                Console.WriteLine("An error occurred communicating with the server.");
                return null;
            }
            else if (!response.IsSuccessful)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine("The transfer you're approving doesn't exist.");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    Console.WriteLine("The transfer you're approving is not in pending state or is not your transaction to approve.");
                }
                else
                {
                    Console.WriteLine("An error response was received from the server. The status code is " + (int)response.StatusCode);
                }

                return null;
            }
            else
            {
                return response.Data;
            }
        }

        public Transfer RejectTransfer(int transferId)
        {
            client.Authenticator = new JwtAuthenticator(UserService.GetToken());
            RestRequest request = new RestRequest(API_BASE_URL + "transfers/" + transferId + "/reject");
            IRestResponse<Transfer> response = client.Put<Transfer>(request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                Console.WriteLine("An error occurred communicating with the server.");
                return null;
            }
            else if (!response.IsSuccessful)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine("The transfer you're rejecting doesn't exist.");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    Console.WriteLine("The transfer you're rejecting is not in pending state or is not your transaction to reject.");
                }
                else
                {
                    Console.WriteLine("An error response was received from the server. The status code is " + (int)response.StatusCode);
                }

                return null;
            }
            else
            {
                return response.Data;
            }
        }

        //account endpoints
        public decimal GetBalance()
        {
            client.Authenticator = new JwtAuthenticator(UserService.GetToken());
            RestRequest request = new RestRequest(API_BASE_URL + "account/balance");
            IRestResponse<decimal> response = client.Get<decimal>(request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                Console.WriteLine("An error occurred communicating with the server.");
                return decimal.MinValue;
            }
            else if (!response.IsSuccessful)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine("User account not found");
                }
                else
                {
                    Console.WriteLine("An error response was received from the server. The status code is " + (int)response.StatusCode);
                }
                return decimal.MinValue;
            }
            else
            {
                return response.Data;
            }
        }

        public List<Transfer> GetTransfers() //maybe should be `/transfers`?
        {
            client.Authenticator = new JwtAuthenticator(UserService.GetToken());
            RestRequest request = new RestRequest(API_BASE_URL + "account/transfers");
            IRestResponse<List<Transfer>> response = client.Get<List<Transfer>>(request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                Console.WriteLine("An error occurred communicating with the server.");
                return null;
            }
            else if (!response.IsSuccessful)
            {
                Console.WriteLine("An error response was received from the server. The status code is " + (int)response.StatusCode);
                return null;
            }
            else
            {
                return response.Data;
            }
        }

        public List<Transfer> GetPendingTransfers()
        {
            client.Authenticator = new JwtAuthenticator(UserService.GetToken());
            RestRequest request = new RestRequest(API_BASE_URL + "account/pending");
            IRestResponse<List<Transfer>> response = client.Get<List<Transfer>>(request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                Console.WriteLine("An error occurred communicating with the server.");
                return null;
            }
            else if (!response.IsSuccessful)
            {
                Console.WriteLine("An error response was received from the server. The status code is " + (int)response.StatusCode);
                return null;
            }
            else
            {
                return response.Data;
            }
        }
    }
}
