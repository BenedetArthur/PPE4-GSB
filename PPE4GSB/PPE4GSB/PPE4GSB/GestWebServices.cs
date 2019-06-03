using PPE4GSB.Classes;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PPE4GSB
{
    public class GestWebServices
    {
        private HttpClient ws;
        private string response;

        // Constructeur
        public GestWebServices()
        {
            ws = new HttpClient();
        }

        // Méthodes appelant les API PHP
        public async Task<List<Medicaments>> GetMedicamentsAsync()
        {
            response = await ws.GetStringAsync("http://arthur.sio19ingetis.lan/ppe4/GetLesMedocs.php");
            List<Medicaments> lesMedicaments = JsonConvert.DeserializeObject<List<Medicaments>>(response);
            return lesMedicaments;
        }

        public async Task<List<Dosage>> GetDosagesAsync()
        {
            response = await ws.GetStringAsync("http://arthur.sio19ingetis.lan/ppe4/GetLesDosages.php");
            List<Dosage> lesDosages = JsonConvert.DeserializeObject<List<Dosage>>(response);
            return lesDosages;
        }

        public async Task<List<Individu_type>> GetIndividu_TypesAsync()
        {
            response = await ws.GetStringAsync("http://arthur.sio19ingetis.lan/ppe4/GetLesIndividus.php");
            List<Individu_type> lesIndividus = JsonConvert.DeserializeObject<List<Individu_type>>(response);
            return lesIndividus;
        }

        public async Task<List<Individu_type>> GetNomIndividu_TypesAsync()
        {
            response = await ws.GetStringAsync("http://arthur.sio19ingetis.lan/ppe4/GetLesNomsIndividus.php");
            List<Individu_type> lesNomsIndividus = JsonConvert.DeserializeObject<List<Individu_type>>(response);
            return lesNomsIndividus;
        }

        public async Task<List<Medicaments>> GetNomMedicamentsAsync()
        {
            response = await ws.GetStringAsync("http://arthur.sio19ingetis.lan/ppe4/GetLesNomsMedicaments.php");
            List<Medicaments> lesNomsMedicaments = JsonConvert.DeserializeObject<List<Medicaments>>(response);
            return lesNomsMedicaments;
        }

        public async Task<List<Dosage>> GetNomDosageAsync()
        {
            response = await ws.GetStringAsync("http://arthur.sio19ingetis.lan/ppe4/GetLesNomsDosage.php");
            List<Dosage> lesNomsDosage = JsonConvert.DeserializeObject<List<Dosage>>(response);
            return lesNomsDosage;
        }

        public async void InsertMedicamentAsync(string med_depotlegal, string med_nomCommercial, string fam_code, string med_contrIndic, string med_composition, string med_effets, string med_prixechantillon)
        {
            response = await ws.GetStringAsync("http://alan.sio19ingetis.lan/ppe4/InsererMedoc.php?depot=" + med_depotlegal + "&nomcom=" + med_nomCommercial + "&codefam=" + fam_code + "&compo=" + med_composition + "&effets=" + med_effets + "&contrindic=" + med_contrIndic + "&prix=" + med_prixechantillon);
        }

        public async void InsertIndividuTypeAsync(string Code_Type, string Libelle_Type)
        {
            response = await ws.GetStringAsync("http://arthur.sio19ingetis.lan/ppe4/InsererIndividu.php?code=" + Code_Type + "&libelle=" + Libelle_Type);
        }

        public async void UpdateMedicamentAsync(string depot, string nomcom, string famcode, string contreindic, string compo, string effets, string prix)
        {
            response = await ws.GetStringAsync("http://arthur.sio19ingetis.lan/ppe4/UpdateMedoc.php?depot=" + depot + "&nom=" + nomcom + "&code=" + famcode + "&compo=" + compo + "&effets=" + effets + "&contreindic=" + contreindic + "&prix=" + prix);
        }

        public async void UpdateIndividuAsync(string Code_Type, string Libelle_Type)
        {
            response = await ws.GetStringAsync("http://arthur.sio19ingetis.lan/ppe4/UpdateIndividu.php?code=" + Code_Type + "&libelle=" + Libelle_Type);
        }

        public async void InsertPrecriptionAsync(string depot, int codeDose, string codeIndividu)
        {
            response = await ws.GetStringAsync("http://arthur.sio19ingetis.lan/ppe4/InsererPrescription.php?depot=" + depot + "&codeDose=" + codeDose + "&codetype=" + codeIndividu);
        }


    }
}
