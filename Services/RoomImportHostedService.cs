using System.Text.Json;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RasDashboard.DTOs.Rooms;
using RasDashboard.Interfaces;
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

    public RoomImportHostedService(
        IServiceScopeFactory scopeFactory,
        ILogger<RoomImportHostedService> logger,
        HttpClient httpClient,
        IConfiguration configuration,
        IMapper mapper)
    {
        _scopeFactory = scopeFactory;
        _logger = logger;
        _httpClient = httpClient;
        _configuration = configuration;
        _mapper = mapper;

        _apiKey = configuration["ExternalApis:ApiKEy"] ?? throw new NullReferenceException("API Key bulunamadı.");
        _roomsApiUrl = configuration["ExternalApis:RoomsEndpoint"] ?? throw new NullReferenceException("Rooms API endpoint'i bulunamadı.");
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Fetching rooms from Hostify API...");

            var request = new HttpRequestMessage(HttpMethod.Get, _roomsApiUrl + "?per_page=200");
            request.Headers.Add("x-api-key", _apiKey);
            var response = await _httpClient.SendAsync(request, cancellationToken);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync(cancellationToken);
            var apiResponse = JsonSerializer.Deserialize<ApiResponse>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (apiResponse?.Listings == null || !apiResponse.Listings.Any())
            {
                _logger.LogWarning("API'den oda listesi alınamadı.");
                return;
            }

            var rooms = _mapper.Map<List<Room>>(apiResponse.Listings);

            using var scope = _scopeFactory.CreateScope();
            var roomRepository = scope.ServiceProvider.GetRequiredService<IRoomRepository>();

            foreach (var room in rooms)
            {
                if (room.Street == "Eşrefsaat Sokağı No:1")
                    continue;

                var existingRoom = await roomRepository.GetRoomByIdAsync(room.Id);
                if (existingRoom == null)
                {
                    await roomRepository.AddRoomAsync(room);
                }
            }

            _logger.LogInformation($"{rooms.Count} oda başarıyla işlendi.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Room import sırasında bir hata oluştu.");
        }
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
