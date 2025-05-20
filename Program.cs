using IsapiPoC;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Text;
using System.Text.Json;

//string url = "http://10.0.80.2/ISAPI/Event/notification/alertStream";
IConfiguration config = new ConfigurationBuilder()
           .SetBasePath(AppContext.BaseDirectory) // Set base path
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) // Add JSON config
           .Build();

string ip = config["CameraSettings:IP"]!;
string username = config["CameraSettings:Username"]!;
string password = config["CameraSettings:Password"]!;

var isapiClient = new IsapiClient(username, password, $"http://{ip}");

var users = await isapiClient.GetAllUsers();

int? userId = null;

if (users != null)
{
    foreach (var user in users.Users)
    {
        if (user.UserName == "NUTRM")
        {
            userId = user.Id;
        }
    }
}
else
{
    Console.WriteLine("No users found.");
}

if (!userId.HasValue) return;

Console.WriteLine($"User ID: {userId}");

var r = await isapiClient.GetUserPermission(userId.Value);

// Convert the result to JSON and print
string json = JsonSerializer.Serialize(r, new JsonSerializerOptions { WriteIndented = true });
Console.WriteLine(json);

if (r == null)
{
    Console.WriteLine("UserPermission is null");
    return;
}

UpdateRemotePermissions(r);
UpdateLocalPermissions(r);

await isapiClient.UpdateUserPermission(userId.Value, r);

//string cameraIp = "0845-190-150-197-107.ngrok-free.app"; // Replace with your camera IP
//string endpoint = $"/ISAPI/System/deviceInfo"; // Adjust the endpoint as needed
//var handler = new HttpClientHandler()
//{
//    Credentials = new NetworkCredential("admin", "underc0ver1")
//};
//var httpClient = new HttpClient(handler);
////httpClient.DEFAUL
//// Send GET request

//HttpResponseMessage response = await httpClient.GetAsync($"https://{cameraIp}/{endpoint}");
//if (response.IsSuccessStatusCode)
//{
//    // Process the response if needed
//    var content = await response.Content.ReadAsStringAsync();
//    Console.WriteLine(content);
//}
//else
//{
//    Console.WriteLine($"Error: {response.StatusCode}");
//}

//OldWay();

static void OldWay()
{
    string strUrl = "https://0845-190-150-197-107.ngrok-free.app/ISAPI/System/deviceInfo";
    WebClient client = new WebClient();
    // Set the user name and password
    client.Credentials = new NetworkCredential("admin", "underc0ver1");
    byte[] responseData = client.DownloadData(strUrl);
    string strResponseData = Encoding.UTF8.GetString(responseData);
    // Output received information
    Console.WriteLine(strResponseData);
}

static void UpdateRemotePermissions(IsapiPoC.Models.UserPermission r)
{
    if (r.RemotePermission == null) return;

    r.RemotePermission.PlayBack = true;
    r.RemotePermission.Preview = true;
    r.RemotePermission.Record = true;

    foreach (var permission in r.RemotePermission.VideoChannelPermissionList)
    {
        permission.PlayBack = true;
        permission.Preview = true;
        permission.Record = true;
    }
}

static void UpdateLocalPermissions(IsapiPoC.Models.UserPermission r)
{
    if (r.LocalPermission == null) return;

    r.LocalPermission.PlayBack = true;
    r.LocalPermission.Preview = true;
    r.LocalPermission.Record = true;

    foreach (var permission in r.LocalPermission.VideoChannelPermissionList)
    {
        permission.PlayBack = true;
        permission.Preview = true;
        permission.Record = true;
    }
}