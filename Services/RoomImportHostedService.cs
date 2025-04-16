using System.Text.Json;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RasDashboard.Areas.Identity.Data;
using RasDashboard.DTOs.Rooms;
using RasDashboard.Models;


namespace RasDashboard.Services;

public class RoomImportHostedService : IHostedService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<RoomImportHostedService> _logger;
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;
    private readonly string _apiKey;
    private readonly string _roomsApiUrl;
    
    public RoomImportHostedService(IServiceScopeFactory scopeFactory, ILogger<RoomImportHostedService> logger,
        HttpClient httpClient, IConfiguration configuration, IMapper mapper)
    {
        _scopeFactory = scopeFactory;
        _logger = logger;
        _httpClient = httpClient;
        _configuration = configuration;
        _mapper = mapper;
        _apiKey = configuration["ExternalApis:ApiKEy"] ?? throw new NullReferenceException();
        _roomsApiUrl = configuration["ExternalApis:RoomsEndpoint"] ?? throw new NullReferenceException();
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Fetching rooms from Hostify API...");

            var request = new HttpRequestMessage(HttpMethod.Get, _roomsApiUrl + "?per_page=200");
            request.Headers.Add("x-api-key", $"{_apiKey}");
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonSerializer.Deserialize<ApiResponse>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            var rooms = _mapper.Map<List<Room>>(apiResponse!.Listings);

            using (var scope = _scopeFactory.CreateScope()) // Create a new scope
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<RasDashboardContext>();

                foreach (var room in rooms)
                {
                    if (room.Street == "Eşrefsaat Sokağı No:1")
                    {
                        continue;
                    }

                    var existingRoom = await dbContext.Rooms.FirstOrDefaultAsync(r => r.Id == room.Id);
                    if (existingRoom == null)
                    {
                        await dbContext.Rooms.AddAsync(room);
                    }
                }

                await dbContext.SaveChangesAsync();
            }

            _logger.LogInformation($"{rooms.Count} rooms successfully saved.");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error getting listings: {ex.Message}");
        }
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
