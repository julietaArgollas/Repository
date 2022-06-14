using BackingServices.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BackingServices.Services
{
    public class CampaignService
    {
        public async Task<Campaign> GetCampaignServiceAsync()
        {
            try
            {
                Console.WriteLine("Pidiendo info de la campaña");
                using (HttpClient client = new HttpClient())
                {
                    Campaign campaign = new Campaign();
                    string URL = "https://tec-web-ucb-service-api-dev-proy-group-c.azurewebsites.net/Campaigns/is/Active";

                    HttpResponseMessage response = await client.GetAsync(URL);
                    if (response.IsSuccessStatusCode)
                    {
                        dynamic campaignBody = await response.Content.ReadAsStringAsync();
                        dynamic campaignRes = JsonConvert.DeserializeObject(campaignBody);
                        foreach (var res in campaignRes)
                        {
                            campaign.Id = res["id"];
                            campaign.NameCampaign = res["nameCampaign"];
                            campaign.DescriptionCampaign = res["descriptionCampaign"];
                            campaign.TypeCampaign = res["typeCampaign"];
                            campaign.Enable = res["enable"];
                        }
                        return campaign;
                    }
                    else
                    {
                        throw new Exception("HUBO FALLAS al pedir info de la campaña");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("HUBO FALLAS al pedir info de la campaña");
                Console.WriteLine(ex.Message + ex.StackTrace);
                throw;
            }
        }
    }
}
