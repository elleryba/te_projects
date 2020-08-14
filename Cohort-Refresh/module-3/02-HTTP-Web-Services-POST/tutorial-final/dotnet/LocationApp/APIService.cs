using RestSharp;
using System;
using System.Collections.Generic;

namespace LocationApp
{
    public class APIService
    {
        const string API_URL = "http://localhost:3000/locations";
        readonly RestClient client = new RestClient();

        public List<Location> GetAllLocations()
        {
            RestRequest request = new RestRequest(API_URL);
            IRestResponse<List<Location>> response = client.Get<List<Location>>(request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                //response not received
                Console.WriteLine("An error occurred communicating with the server.");
                return null;
            }
            else if (!response.IsSuccessful)
            {
                //response non-2xx
                Console.WriteLine("An error response was received from the server. The status code is " + (int)response.StatusCode);
                return null;
            }
            else
            {
                //success
                return response.Data;
            }
        }

        public Location GetDetailsForLocation(int locationId)
        {
            RestRequest requestOne = new RestRequest(API_URL + "/" + locationId);
            IRestResponse<Location> response = client.Get<Location>(requestOne);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                //response not received
                Console.WriteLine("An error occurred communicating with the server.");
                return null;
            }
            else if (!response.IsSuccessful)
            {
                //response non-2xx
                Console.WriteLine("An error response was received from the server. The status code is " + (int)response.StatusCode);
                return null;
            }
            else
            {
                //success
                return response.Data;
            }
        }

        public Location AddLocation(Location newLocation)
        {
            RestRequest request = new RestRequest(API_URL);
            request.AddJsonBody(newLocation);
            IRestResponse<Location> response = client.Post<Location>(request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                //response not received
                Console.WriteLine("An error occurred communicating with the server.");
                return null;
            }
            else if (!response.IsSuccessful)
            {
                //response non-2xx
                Console.WriteLine("An error response was received from the server. The status code is " + (int)response.StatusCode);
                return null;
            }
            else
            {
                //success
                Console.WriteLine("Location successfully added");
                return response.Data;
            }
        }

        public Location UpdateLocation(Location locationToUpdate)
        {
            RestRequest request = new RestRequest(API_URL + "/" + locationToUpdate.Id);
            request.AddJsonBody(locationToUpdate);
            IRestResponse<Location> response = client.Put<Location>(request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                //response not received
                Console.WriteLine("An error occurred communicating with the server.");
                return null;
            }
            else if (!response.IsSuccessful)
            {
                //response non-2xx
                Console.WriteLine("An error response was received from the server. The status code is " + (int)response.StatusCode);
                return null;
            }
            else
            {
                //success
                Console.WriteLine("Location successfully updated");
                return response.Data;
            }
        }

        public void DeleteLocation(int locationId)
        {
            RestRequest request = new RestRequest(API_URL + "/" + locationId);
            IRestResponse response = client.Delete(request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                //response not received
                Console.WriteLine("An error occurred communicating with the server.");
            }
            else if (!response.IsSuccessful)
            {
                //response non-2xx
                Console.WriteLine("An error response was received from the server. The status code is " + (int)response.StatusCode);
            }
            else
            {
                //success
                Console.WriteLine("Location successfully deleted");
            }
        }
    }
}