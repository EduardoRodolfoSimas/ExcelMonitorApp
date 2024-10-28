using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using OfficeOpenXml;

namespace ExcelMonitorApp
{
    public partial class Form1 : Form
    {
        private string caminhoExcel = @"Coloca o caminho do excel aqui";
        private DateTime ultimaModificacao;

        public Form1()
        {
            InitializeComponent();

            // Configura o Timer.
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 5000; // Verifica a cada 5 segundos.
            timer.Tick += Timer_Tick;
            timer.Start();

            ultimaModificacao = File.GetLastWriteTime(caminhoExcel);
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
            using (var pacote = new ExcelPackage(new FileInfo(caminhoExcel)))
            {
                ExcelWorksheet planilha = pacote.Workbook.Worksheets[0];
                string codigoLido = planilha.Cells["A1"].Text;

                if (!string.IsNullOrEmpty(codigoLido))
                {
                    MedicoVeterinario MedicoVeterinarioEncontrado = MedicoVeterinario.BuscarMedicoVeterinarioPorCodigo(codigoLido);

                    if (MedicoVeterinarioEncontrado != null)
                    {
                        labelResultado.Text = $"Nome: {MedicoVeterinarioEncontrado.Nome}";
                    }
                    else
                    {
                        labelResultado.Text = "Código não encontrado.";
                    }
                }
            }
        }
    }

    public class MedicoVeterinario
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }

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
