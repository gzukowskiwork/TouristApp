using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TouristAppBackend.Application.Common.Interfaces.Configuration;
using TouristAppBackend.Application.Common.Interfaces.ExternalApi;
using TouristAppBackend.Application.Common.Interfaces.Repository;

namespace TouristAppBackend.Infrastructure.ExternalApi
{
    public class OpenTripMap: IOpenTripMap
    {
        private readonly IAppSettings _appSettings;
        private readonly ISettingsRepository _settingsRepository;
        static HttpClient client = new HttpClient();

        public OpenTripMap(IAppSettings appSettings, ISettingsRepository settingsRepository)
        {
            _appSettings = appSettings;
            _settingsRepository = settingsRepository;
        }

        //TODO
        /// <summary>
        /// zrobić interfejs z metodami typu response, przyjmującymi request
        /// w application zrobić folder i dodać queries, tam zrobic query typu api request i handler zwracający typ api response
        /// wstrzyknąć interfejs z httpclienta i wywyoływać metody
        /// controller do wywołania akcji
        /// </summary>

        public void Aaaa()
        {
            Uri aa = new Uri(_appSettings.BaseAddress);

            client.BaseAddress = aa;

            var xx = _appSettings.OpenTripMapApiKey;

            string apiKey = _settingsRepository.GetByCode(xx);
            var response = client.GetAsync(apiKey);
        }
    }
}
