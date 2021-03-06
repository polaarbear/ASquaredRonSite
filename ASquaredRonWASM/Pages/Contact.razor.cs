using ASquaredRonModels.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace ASquaredRonWASM.Pages
{
    public partial class Contact
    {
        private ContactMeModel _ContactMeModel { get; set; } = new ContactMeModel();

        private bool _Error { get; set; } = false;
        private bool _Success { get; set; } = false;

        [Inject]
        private HttpClient? _HttpClient { get; set; }

        private async Task SubmitContactInfo()
        {
            try
            {
                var task = await _HttpClient!.PostAsJsonAsync($"api/ContactMe", _ContactMeModel);
                if(task.IsSuccessStatusCode)
                {
                    _ContactMeModel = new ContactMeModel();
                    _Error = false;
                    _Success = true;
                }
                else
                {
                    _Error = true;
                    _Success = false;
                }
            }
            catch (Exception ex)
            {
                //TODO: Set up logging
                _Error = true;
                _Success = false;
            }
        }
    }
}
