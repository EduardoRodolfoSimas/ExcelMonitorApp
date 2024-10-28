using OfficeOpenXml;

namespace ExcelMonitorApp
{
    public partial class Form1 : Form
    {
        private string caminhoExcel = @"C:\Users\Granter\Downloads\teste.xlsx";
        private string ultimoCodigoLido;
        private DateTime ultimaModificacao;

        public Form1()
        {
            InitializeComponent();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;


            // Configura o Timer.
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 5000; // Verifica a cada 5 segundos.
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime ultimaModificacaoAtual = File.GetLastWriteTime(caminhoExcel);

            if (ultimaModificacaoAtual > ultimaModificacao)
            {
                ultimaModificacao = ultimaModificacaoAtual;
                VerificarCelulaExcel();
            }
        }

        private void VerificarCelulaExcel()
        {
            try
            {
                using (var pacote = new ExcelPackage(new FileInfo(caminhoExcel)))
                {
                    ExcelWorksheet planilha = pacote.Workbook.Worksheets[0];


                    object valorLido = planilha.Cells["A1"].Value;
                    string codigoLido;

                    if (valorLido is double)
                    {
                        codigoLido = ((double)valorLido).ToString("F0");
                    }
                    else
                    {
                        codigoLido = valorLido?.ToString();
                    }
                    if (!string.IsNullOrEmpty(codigoLido))
                    {
                        if (codigoLido != ultimoCodigoLido)
                        {
                            ultimoCodigoLido = codigoLido;

                            MedicoVeterinario medicoVeterinarioEncontrado = MedicoVeterinario.BuscarMedicoVeterinarioPorCodigo(codigoLido);

                            if (medicoVeterinarioEncontrado != null)
                            {
                                labelResultado.Text = $"Nome: {medicoVeterinarioEncontrado.Nome}";
                            }
                            else
                            {
                                labelResultado.Text = "Código não encontrado.";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao verificar a célula do Excel: {ex.Message}");
            }
        }
    }

    public class MedicoVeterinario
    {
        public string? Codigo { get; set; }
        public string? Nome { get; set; }

        public static List<MedicoVeterinario> ListaMedicoVeterinario = new List<MedicoVeterinario>
        {
            new MedicoVeterinario { Codigo = "982000401162543", Nome = "Eduardo Rodolfo de Simas" },
            new MedicoVeterinario { Codigo = "982000401162532", Nome = "Nathalya Giovanna Silva Nascimento" }
        };

        public static MedicoVeterinario BuscarMedicoVeterinarioPorCodigo(string codigo)
        {
            return ListaMedicoVeterinario.FirstOrDefault(c => c.Codigo == codigo);
        }
    }
}
