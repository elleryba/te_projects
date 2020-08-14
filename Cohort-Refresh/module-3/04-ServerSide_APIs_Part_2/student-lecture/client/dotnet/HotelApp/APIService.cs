using RestSharp;
using System;
using System.Collections.Generic;

namespace HTTP_Web_Services_POST_PUT_DELETE_lecture
{
    class APIService
    {
        private readonly string API_URL = "https://localhost:44322/";
        private readonly RestClient client = new RestClient();

        public List<Hotel> GetHotels()
        {
            RestRequest request = new RestRequest(API_URL + "hotels");
            IRestResponse<List<Hotel>> response = client.Get<List<Hotel>>(request);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                Console.WriteLine("Error occurred - unable to reach server.");
            }
            else if (!response.IsSuccessful)
            {
                Console.WriteLine("Error occurred - received non-success response: " + (int)response.StatusCode);
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
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                Console.WriteLine("Error occurred - unable to reach server.");
            }
            else if (!response.IsSuccessful)
            {
                Console.WriteLine("Error occurred - received non-success response: " + (int)response.StatusCode);
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
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                Console.WriteLine("Error occurred - unable to reach server.");
            }
            else if (!response.IsSuccessful)
            {
                Console.WriteLine("Error occurred - received non-success response: " + (int)response.StatusCode);
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
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                Console.WriteLine("Error occurred - unable to reach server.");
            }
            else if (!response.IsSuccessful)
            {
                Console.WriteLine("Error occurred - received non-success response: " + (int)response.StatusCode);
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
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                Console.WriteLine("Error occurred - unable to reach server.");
            }
            else if (!response.IsSuccessful)
            {
                Console.WriteLine("Error occurred - received non-success response: " + (int)response.StatusCode);
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
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                Console.WriteLine("Error occurred - unable to reach server.");
            }
            else if (!response.IsSuccessful)
            {
                Console.WriteLine("Error occurred - received non-success response: " + (int)response.StatusCode);
            }
            else
            {
                Console.WriteLine("Reservation successfully deleted.");
            }
        }
    }
}
