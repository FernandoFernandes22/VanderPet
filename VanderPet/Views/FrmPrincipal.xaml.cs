namespace VanderPet.Views;

public partial class FrmPrincipal : ContentPage
{
    App PropriedadeApp;
    public FrmPrincipal()
    {
        InitializeComponent();
        PropriedadeApp = (App)Application.Current;
        pckEspecies.ItemsSource = PropriedadeApp.lstEspecies;
        pckServicos.ItemsSource = PropriedadeApp.lstServicos;
        pckRacas.ItemsSource = PropriedadeApp.lstRacas;
        dtPckInicio.MinimumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1);
        dtPckInicio.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);
    }
}