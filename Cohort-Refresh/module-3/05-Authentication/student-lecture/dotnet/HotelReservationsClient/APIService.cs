using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;

namespace HotelReservationsClient
{
    class APIService
    {
        private readonly string API_URL = "";
        private readonly RestClient client = new RestClient();
        private API_User user = new API_User();

        public bool LoggedIn { get { return !string.IsNullOrWhiteSpace(user.Token); } }

        public APIService(string api_url)
        {
            API_URL = api_url;
        }

        public List<Hotel> GetHotels()
        {
            RestRequest request = new RestRequest(API_URL + "hotels");
            IRestResponse<List<Hotel>> response = client.Get<List<Hotel>>(request);

            if (response.ResponseStatus != ResponseStatus.Completed || !response.IsSuccessful)
            {
                ProcessErrorResponse(response);
            }
            else
            {
                return response.Data;
            }
            return null;
        }

        public List<Reservation> GetReservations(int hotelId = 0)
        {
            string url = API_URL;
            if (hotelId != 0)
                url += $"hotels/{hotelId}/reservations";
            else
                url += "reservations";

            RestRequest request = new RestRequest(url);
            IRestResponse<List<Reservation>> response = client.Get<List<Reservation>>(request);

            if (response.ResponseStatus != ResponseStatus.Completed || !response.IsSuccessful)
            {
                ProcessErrorResponse(response);
            }
            else
            {
                return response.Data;
            }
            return null;
        }

        public Reservation GetReservation(int reservationId)
        {
            RestRequest request = new RestRequest(API_URL + "reservations/" + reservationId);
            IRestResponse<Reservation> response = client.Get<Reservation>(request);

            if (response.ResponseStatus != ResponseStatus.Completed || !response.IsSuccessful)
            {
                ProcessErrorResponse(response);
            }
            else
            {
                return response.Data;
            }
            return null;
        }

        public Reservation AddReservation(Reservation newReservation)
        {
            RestRequest request = new RestRequest(API_URL + "reservations");
            request.AddJsonBody(newReservation);
            IRestResponse<Reservation> response = client.Post<Reservation>(request);

            if (response.ResponseStatus != ResponseStatus.Completed || !response.IsSuccessful)
            {
                ProcessErrorResponse(response);
            }
            else
            {
                return response.Data;
            }
            return null;
        }

        public Reservation UpdateReservation(Reservation reservationToUpdate)
        {
            RestRequest request = new RestRequest(API_URL + "reservations/" + reservationToUpdate.id);
            request.AddJsonBody(reservationToUpdate);
            IRestResponse<Reservation> response = client.Put<Reservation>(request);

            if (response.ResponseStatus != ResponseStatus.Completed || !response.IsSuccessful)
            {
                ProcessErrorResponse(response);
            }
            else
            {
                return response.Data;
            }
            return null;
        }

        public void DeleteReservation(int reservationId)
        {
            RestRequest request = new RestRequest(API_URL + "reservations/" + reservationId);
            IRestResponse response = client.Delete(request);

            if (response.ResponseStatus != ResponseStatus.Completed || !response.IsSuccessful)
            {
                ProcessErrorResponse(response);
            }
            else
            {
                Console.WriteLine("Reservation successfully deleted.");
            }
        }

        private void ProcessErrorResponse(IRestResponse response)
        {
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                Console.WriteLine("Error occurred - unable to reach server.");
            }
            else if (!response.IsSuccessful)
            {
                Console.WriteLine("Error occurred - received non-success response: " + (int)response.StatusCode);
            }
        }

        public bool Login(string submittedName, string submittedPass)
        {
            var credentials = new { username = submittedName, password = submittedPass }; //this gets converted to JSON by RestSharp
            RestRequest request = new RestRequest(API_URL + "login");
            request.AddJsonBody(credentials);
            IRestResponse<API_User> response = client.Post<API_User>(request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                Console.WriteLine("An error occurred communicating with the server.");
                return false;
            }
            else if (!response.IsSuccessful)
            {
                if (!string.IsNullOrWhiteSpace(response.Data.Message))
                {
                    Console.WriteLine("An error message was received: " + response.Data.Message);
                }
                else
                {
                    Console.WriteLine("An error response was received from the server. The status code is " + (int)response.StatusCode);
                }
                return false;
            }
            else
            {
                user.Token = response.Data.Token;

                return true;
            }
        }

        public void Logout()
        {
            user = new API_User();
            client.Authenticator = null;
        }
    }
}
