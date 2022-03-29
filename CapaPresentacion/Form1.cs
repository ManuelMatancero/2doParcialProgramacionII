using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaLogica;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        L_Persona l_Persona = new L_Persona();
        E_Persona e_Persona = null;
        bool estadoInsertar = false;
        bool estadoEditar = false;
        string idPersona = "0";

        public Form1()
        {
            InitializeComponent();
            bloqueoCampo();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            mostrarBusqueda("");
        }



        private void btnInsertar_Click(object sender, EventArgs e)
        {
            desbloqueoCampo();
            limpiar();
            txtNombre.Focus();
            estadoInsertar = true;
            estadoEditar = false;
            idPersona = "0";

        }



        public void mostrarBusqueda(string buscar)
        {
            tablaPersonas.DataSource = l_Persona.searchPersonaL(buscar);
            tablaPersonas.Columns[0].Visible = false;
        }

        private void textBuscar_TextChanged(object sender, EventArgs e)
        {
            string busqueda = txtBuscar.Text;
            mostrarBusqueda(busqueda);

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (estadoInsertar == true)
            {
                if (checkTextBox() == true)
                {
                    e_Persona = new E_Persona(txtNombre.Text, txtApellidos.Text,
                    txtDireccion.Text, DateTime.Parse(txtNacimiento1.Text), txtCelular1.Text);
                    l_Persona.insertPersonaL(e_Persona);
                    MessageBox.Show("Contacto agregado correctamente");
                    mostrarBusqueda("");
                    limpiar();
                    bloqueoCampo();
                    estadoInsertar = false;
                    idPersona = "0";
                }

            }
            else if (estadoEditar == true)
            {
                if (checkTextBox() == true)
                {
                    e_Persona = new E_Persona(int.Parse(idPersona), txtNombre.Text, txtApellidos.Text,
                                   txtDireccion.Text, DateTime.Parse(txtNacimiento1.Text), txtCelular1.Text);
                    l_Persona.updatePersonaL(e_Persona);
                    MessageBox.Show("Contacto actualizado correctamente");
                    mostrarBusqueda("");
                    limpiar();
                    bloqueoCampo();
                    estadoEditar = false;
                    idPersona = "0";
                }

            }
        }

        public void limpiar()
        {
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtDireccion.Text = "";
            txtNacimiento1.Text = "";
            txtCelular1.Text = "";
        }

        public void bloqueoCampo()
        {
            txtNombre.Enabled = false;
            txtApellidos.Enabled = false;
            txtDireccion.Enabled = false;
            txtNacimiento1.Enabled = false;
            txtCelular1.Enabled = false;
            btnGuardar.Enabled = false;
        }

        public void desbloqueoCampo()
        {
            txtNombre.Enabled = true;
            txtApellidos.Enabled = true;
            txtDireccion.Enabled = true;
            txtNacimiento1.Enabled = true;
            txtCelular1.Enabled = true;
            btnGuardar.Enabled = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idPersona.Equals("0"))
            {
                MessageBox.Show("Debe seleccionar una fila para eliminar");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Esta seguro que desea eliminar", "Eliminar Contacto", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    l_Persona.deletePersonaL(idPersona);
                    mostrarBusqueda("");
                    idPersona = "0";
                    limpiar();
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idPersona.Equals("0"))
            {
                MessageBox.Show("Debe Seleccionar una fila");
            }
            else
            {
                desbloqueoCampo();
                estadoEditar = true;
                txtNombre.Focus();
                estadoInsertar = false;
            }


        }

        private void tablaPersonas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablaPersonas.SelectedRows.Count > 0)
            {
                idPersona = tablaPersonas.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = tablaPersonas.CurrentRow.Cells[2].Value.ToString();
                txtApellidos.Text = tablaPersonas.CurrentRow.Cells[3].Value.ToString();
                txtDireccion.Text = tablaPersonas.CurrentRow.Cells[4].Value.ToString();
                txtNacimiento1.Text = tablaPersonas.CurrentRow.Cells[5].Value.ToString();
                txtCelular1.Text = tablaPersonas.CurrentRow.Cells[6].Value.ToString();
            }
        }

        private void txtApellidos_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
            bloqueoCampo();
            idPersona = "0";
            estadoEditar = false;
            estadoInsertar = false;
        }

        private bool checkTextBox()
        {
            bool confirmado;
            if (txtNombre.Text == string.Empty)
            {
                MessageBox.Show("Hay campos que deben ser completados");
                txtNombre.Focus();
                confirmado = false;
            }
            else if (txtApellidos.Text == string.Empty)
            {
                MessageBox.Show("Hay campos que deben ser completados");
                txtApellidos.Focus();
                confirmado = false;
            }
            else if (txtCelular1.MaskCompleted == false)
            {
                MessageBox.Show("Hay campos que deben ser completados");
                txtCelular1.Focus();
                confirmado = false;
            }
            else if (txtDireccion.Text == string.Empty)
            {
                MessageBox.Show("Hay campos que deben ser completados");
                txtDireccion.Focus();
                confirmado = false;
            }
            else
            {
                confirmado = true;

            }
            return confirmado;
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            if (tablaPersonas.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Output.pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("No fue posible guardar los datos en el disco." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(tablaPersonas.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in tablaPersonas.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in tablaPersonas.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    pdfTable.AddCell(cell.Value.ToString());
                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Datos exportados correctamente!!!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No hubo datos para guardar !!!", "Info");
            }
           
        }
    }  
}
