using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ExcelMonitorApp
{
    public partial class Form1 : Form
    {
        private string caminhoExcel = @"C:\teste.xlsx";
        private DateTime ultimaModificacao;

        public Form1()
        {
            InitializeComponent();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // Configura o Timer.
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 5000; 
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
                    int contador = 0;
                    string ultimoCodigoLido = null;

                    for (int row = 1; row <= planilha.Dimension.End.Row; row++)
                    {
                        object valorCelula = planilha.Cells[row, 1].Value;
                        if (valorCelula != null)
                        {
                            ultimoCodigoLido = valorCelula.ToString();
                            contador++;
                        }
                    }

                    labelContador.Text = $"Contador: {contador}";

                    if (!string.IsNullOrEmpty(ultimoCodigoLido))
                    {
                        MedicoVeterinario medicoVeterinarioEncontrado = MedicoVeterinario.BuscarMedicoVeterinarioPorCodigo(ultimoCodigoLido);

                        if (medicoVeterinarioEncontrado != null)
                        {
                            labelResultado.Text = $"{medicoVeterinarioEncontrado.Nome}";
                        }
                        else
                        {
                            labelResultado.Text = "Código não encontrado.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao verificar a célula do Excel: {ex.Message}");
            }
        }
        
        // Configura o F11 para fullscreen
        private bool bfullscreen = false;
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F11)
            {
                if (!bfullscreen)
                {
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.Left = 0;
                    this.Top = 0;
                    this.Bounds = Screen.PrimaryScreen.Bounds;
                    bfullscreen = true;
                }
                else
                {
                    this.FormBorderStyle = FormBorderStyle.Sizable;
                    bfullscreen = false;
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
            new MedicoVeterinario { Codigo = "982000401162532", Nome = "Nathalya Giovanna Silva Nascimento" },
            new MedicoVeterinario { Codigo = "982000367069735", Nome = "Clovis Rossi" },
            new MedicoVeterinario { Codigo = "982000401162510", Nome = "Leonardo Feijó e Silva Roda" },
            new MedicoVeterinario { Codigo = "999000144138633", Nome = "Sizenando Ribeiro da Silva Neto" }
        };

        public static MedicoVeterinario BuscarMedicoVeterinarioPorCodigo(string codigo)
        {
            return ListaMedicoVeterinario.FirstOrDefault(c => c.Codigo == codigo);
        }
    }
}
