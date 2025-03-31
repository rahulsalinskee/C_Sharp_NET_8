using Client.Management.UI.DTOs;
using Client.Management.UI.NotifyPropertiesOnChange;
using Client.Management.UI.Repository.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Management.UI.ViewModels
{
    public class ClientViewModel : BaseNotifyPropertyChange
    {
        private readonly IApiService _apiService;
        private ObservableCollection<ClientDto> _clients;
        private ClientDto _client;
        private bool _isLoading;

        public ClientViewModel(IApiService apiService)
        {
            this._apiService = apiService;
            Clients = new ObservableCollection<ClientDto>();
            this._client = new ClientDto();
        }

        public ObservableCollection<ClientDto> Clients
        {
            get
            {
                return _clients;
            }
            set
            {
                _clients = value;
                OnPropertyChanged(nameof(Clients));
            }
        }

        public ClientDto Client
        {
            get
            {
                return _client;
            }
            set
            {
                _client = value;
                OnPropertyChanged(nameof(Client));
            }
        }
    }
}
