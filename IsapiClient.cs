using IsapiPoC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace IsapiPoC
{
    public class IsapiClient
    {
        private HttpClient _httpClient;
        public IsapiClient(string user, string password, string baseAddress)
        {
            var handler = new HttpClientHandler()
            {
                Credentials = new NetworkCredential(user, password),
                
            };
            _httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(baseAddress)
            };
            _httpClient.DefaultRequestHeaders.Connection.Add("Keep-Alive");
        }

        public async Task<string> GetDeviceInfo()
        {
            string endpoint = $"/ISAPI/System/deviceInfo"; // Adjust the endpoint as needed

            HttpResponseMessage response = await _httpClient.GetAsync(endpoint);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return $"Error: {response.StatusCode}";
            }
        }

        public async Task<string> GetUserPermissionCapabilities()
        {
            string endpoint = "/ISAPI/Security/UserPermission/installer/capabilities?format=json";
            HttpResponseMessage response = await _httpClient.GetAsync(endpoint);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return $"Error: {response.StatusCode}";
            }
        }
        public async Task<UserList?> GetAllUsers()
        {
            string endpoint = $"/ISAPI/Security/users/";

            HttpResponseMessage response = await _httpClient.GetAsync(endpoint);
            if (response.IsSuccessStatusCode)
            {
                string xml = await response.Content.ReadAsStringAsync();
                var serializer = new XmlSerializer(typeof(UserList));
                using var reader = new StringReader(xml);
                return serializer.Deserialize(reader) as UserList;
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
                return null;
            }
        }

        public async Task<UserPermission?> GetUserPermission(int userId)
        {
            string endpoint = $"/ISAPI/Security/UserPermission/{userId}";
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await _httpClient.GetAsync(endpoint);
            if (response.IsSuccessStatusCode)
            {
                string xml = await response.Content.ReadAsStringAsync();
                var serializer = new XmlSerializer(typeof(UserPermission));
                using var reader = new StringReader(xml);
                return serializer.Deserialize(reader) as UserPermission;
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
                return null;
            }
        }


        public async Task<string> UpdateUserPermission(int userId, UserPermission userPermission)
        {
            string endpoint = $"/ISAPI/Security/UserPermission/{userId}";
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/xml"));

            // Serialize userPermission to XML
            var serializer = new XmlSerializer(typeof(UserPermission));
            string xmlContent;
            using (var stringWriter = new StringWriter())
            {
                serializer.Serialize(stringWriter, userPermission);
                xmlContent = stringWriter.ToString();
            }

            var content = new StringContent(xmlContent, Encoding.UTF8, "application/xml");

            HttpResponseMessage response = await _httpClient.PutAsync(endpoint, content);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return $"Error: {response.StatusCode}";
            }
        }

        public async Task<string> GetSubscribeEventCap()
        {
            string endpoint = $"/ISAPI/Event/notification/subscribeEventCap";

            HttpResponseMessage response = await _httpClient.GetAsync(endpoint);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return $"Error: {response.StatusCode}";
            }
        }
        
        public async Task<string> PostSubscribeEvents()
        {
            string endpoint = $"/ISAPI/Event/notification/subscribeEvent";

            //set Connection: keep-alive 
            HttpResponseMessage response = await _httpClient.PostAsync(endpoint, null);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return $"Error: {response.StatusCode}";
            }
        }

    }
}
