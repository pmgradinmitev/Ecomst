using Ecomst.DTO;
using Ecomst.Entities;
using Ecomst.Helpers;
using Ecomst.Repositories.IRepositories;
using Microsoft.DotNet.MSIdentity.Shared;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json;

namespace Ecomst.Repositories
{
    public class UserRepositoryAPI:IUserRepository
    {
        public SearchResult<ApplicationUser> GetPageData(ApplicationUserSearch searchModel, string sortColumn, int start, int length)
        {

            SearchResult<ApplicationUser> result = new SearchResult<ApplicationUser>();

            // Create an HttpClient instance
            using (HttpClient client = new HttpClient())
            {
                // Set the base address of the API
                client.BaseAddress = new Uri("https://reqres.in/");

                // Make a GET request to the specified endpoint
                HttpResponseMessage response = client.GetAsync("api/users?page=2").GetAwaiter().GetResult();

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    string jsonResponse =  response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                    // Print the JSON response
                    Console.WriteLine(jsonResponse);
                    ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);
                    foreach (var user in apiResponse.Data)
                    {
                        Console.WriteLine($"Name: {user.FirstName} {user.LastName}");
                        Console.WriteLine($"Email: {user.Email}");
                        Console.WriteLine();
                    }

                    //result.RecordsTotal = recordsTotal;
                    //result.RecordsFiltered = recordsFiltered;
                    //result.Data = query.ToList();
                    return result;
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }
            return result;
        }
    }
}
