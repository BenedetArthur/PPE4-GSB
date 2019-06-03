using PPE4GSB.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PPE4GSB.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PagePrescription : ContentPage
	{

        private GestPrescription LaPrescription { get; set; }

		public PagePrescription ()
		{
			InitializeComponent ();
            RemplirlesPickers();
            this.LaPrescription = new GestPrescription();
		}

        public async void RemplirlesPickers()
        {
            
            pkMedicaments.ItemsSource = await App.GestWeb.GetNomMedicamentsAsync();
            pkIndividu.ItemsSource = await App.GestWeb.GetNomIndividu_TypesAsync();
            pkDosage.ItemsSource = await App.GestWeb.GetNomDosageAsync();
        }

        public void pkMedicaments_SelectedIndexChanged(object sender, EventArgs e)
        {
            LaPrescription.leMedicament = (Medicaments)pkMedicaments.ItemsSource[pkMedicaments.SelectedIndex];
        }

        public void pkDosage_SelectedIndexChanged(object sender, EventArgs e)
        {
            LaPrescription.leDosage = (Dosage)pkDosage.ItemsSource[pkDosage.SelectedIndex];
        }

        public void pkIndividu_SelectedIndexChanged(object sender, EventArgs e)
        {
            LaPrescription.lIndividu = (Individu_type)pkIndividu.ItemsSource[pkIndividu.SelectedIndex];
        }

        private void BtnPrescription_Clicked(object sender, EventArgs e)
        {
            string depot = LaPrescription.leMedicament.Depot;
            int codeDose = LaPrescription.leDosage.dos_code;
            string codeIndividu = LaPrescription.lIndividu.Code_Type;
            App.GestWeb.InsertPrecriptionAsync(depot, codeDose, codeIndividu);  
        }

        private async void BtnAccueil_Clicked(object sender, EventArgs e)
        {
            MainPage page = new MainPage();
            await Navigation.PushModalAsync(page);
        }
    }
}