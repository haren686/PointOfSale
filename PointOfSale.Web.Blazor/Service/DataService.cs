using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PointOfSale.Repository.Models;
using System.Text.Json;

namespace PointOfSale.Service
{
    public class DataService : IDataService
    {
        private HttpClient httpClient;
        public DataService(HttpClient _httpClient)
        {
            httpClient = _httpClient;
        }

        public async Task<string> AddApplication(Applications Application)
        {
            //if (db != null)
            //{
            //    await db.Applications.AddAsync(Application);
            //    await db.SaveChangesAsync();

            //    return Application.ApplicationNumber;
            //}

            return string.Empty;
        }

        public async Task<int> DeleteApplication(string ApplicationNumber)
        {
            int result = 0;

            //if (db != null)
            //{
            //    //Find the post for specific post id
            //    var application = await db.Applications.FirstOrDefaultAsync(x => x.ApplicationNumber == ApplicationNumber);

            //    if (application != null)
            //    {
            //        //Delete that post
            //        db.Applications.Remove(application);

            //        //Commit the transaction
            //        result = await db.SaveChangesAsync();
            //    }
            //    return result;
            //}

            return result;
        }

        public async Task<List<Applications>> GetApplication(string ApplicationNumber)
        {
            //if (db != null)
            //{
            //    return await (from application in db.Applications
            //                  where application.ApplicationNumber == ApplicationNumber
            //                  select application).ToListAsync();
            //}

            return null;
        }

        public async Task<List<Applications>> GetApplications()
        {
            return await JsonSerializer.DeserializeAsync<List<Applications>>(await httpClient.GetStreamAsync($"api/Applications"),new JsonSerializerOptions() { PropertyNameCaseInsensitive = true});
        }

        public async Task UpdateApplication(Applications Application)
        {
            //if (db != null)
            //{
            //    //Delete that post
            //    db.Applications.Update(Application);

            //    //Commit the transaction
            //    await db.SaveChangesAsync();
            //}
        }
    }
}
