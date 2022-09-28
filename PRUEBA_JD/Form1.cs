using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cEntidades;
using cNegocio;

namespace PRUEBA_JD
{
    public partial class Form1 : Form
    {
        string sInd = "";
        public Form1()
        {
            InitializeComponent();
        }

        ePrueba oEntidades = new ePrueba();
        nPrueba oNegocio = new nPrueba();

        void Limpiar()
        {
            try
            {
                txt_codigo.Text = "";
                txt_paterno.Text = "";
                txt_materno.Text = "";
                txt_nombres.Text = "";
                dtp_fechanac.Text = "";
                txt_direccion.Text = "";
            }
            catch(Exception ex)
            {

            } 
        }
        void Habilitar(bool bIndicador)
        {
            try
            {
                //txt_codigo.Enabled = bIndicador;
                txt_paterno.Enabled = bIndicador;
                txt_materno.Enabled = bIndicador;
                txt_nombres.Enabled = bIndicador;
                dtp_fechanac.Enabled = bIndicador;
                txt_direccion.Enabled = bIndicador;
                dgv_Alumnos.Enabled = !bIndicador;
            }
            catch (Exception ex)
            {

            }
        }

        void Listar()
        {
            try
            {
                DataTable odtAlumnos = new DataTable();
                sInd = "0";
                oEntidades.Ind = sInd;

                oEntidades.Codigo = txt_codigo.Text;
                oEntidades.Paterno = txt_paterno.Text;
                oEntidades.Materno = txt_materno.Text;
                oEntidades.Nombres = txt_nombres.Text;
                oEntidades.FechaNac = dtp_fechanac.Text;
                oEntidades.Direccion = txt_direccion.Text;

                odtAlumnos = oNegocio.fMantenimientoAlumnoB(oEntidades);

                if (odtAlumnos.Rows.Count>0)
                {
                    dgv_Alumnos.DataSource = odtAlumnos;
                }
            }
            catch (Exception ex)
            {

            }
        }

        void Grabar()
        {
            try
            {
                DataTable odtAlumnos = new DataTable();
                oEntidades.Ind = sInd;
                oEntidades.Codigo = txt_codigo.Text;
                oEntidades.Paterno = txt_paterno.Text;
                oEntidades.Materno = txt_materno.Text;
                oEntidades.Nombres = txt_nombres.Text;
                oEntidades.FechaNac = dtp_fechanac.Text;
                oEntidades.Direccion = txt_direccion.Text;
                odtAlumnos = oNegocio.fMantenimientoAlumnoB(oEntidades);
                dgv_Alumnos.DataSource = odtAlumnos;

                if (sInd=="1")
                {
                    MessageBox.Show("Alumno Registrado", "");
                }
                else
                {
                    MessageBox.Show("Alumno Modificado", "");
                }
                
            }
            catch (Exception ex)
            {

            }
        }

        void Eliminar()
        {
            try
            {
                DataTable odtAlumnos = new DataTable();
                oEntidades.Ind = sInd;
                oEntidades.Codigo = txt_codigo.Text;
                oEntidades.Paterno = txt_paterno.Text;
                oEntidades.Materno = txt_materno.Text;
                oEntidades.Nombres = txt_nombres.Text;
                oEntidades.FechaNac = dtp_fechanac.Text;
                oEntidades.Direccion = txt_direccion.Text;
                odtAlumnos = oNegocio.fMantenimientoAlumnoB(oEntidades);
                dgv_Alumnos.DataSource = odtAlumnos;
                MessageBox.Show("Alumno Eliminado","");
            }
            catch (Exception ex)
            {

            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            Listar();
            btn_Nuevo.Enabled = true;
            btn_Grabar.Enabled = false;
            btn_Cancelar.Enabled = false;
            btn_Eliminar.Enabled = true;
            dgv_Alumnos.Enabled = true;
            Habilitar(false);
        }

        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Habilitar(true);
            sInd = "1";
            btn_Nuevo.Enabled = false;
            btn_Grabar.Enabled = true;
            btn_Cancelar.Enabled = true;
            btn_Eliminar.Enabled = false;
            dgv_Alumnos.Enabled = false;
        }

        private void btn_Grabar_Click(object sender, EventArgs e)
        {
            Grabar();
            Listar();
            btn_Nuevo.Enabled = true;
            btn_Grabar.Enabled = false;
            btn_Cancelar.Enabled = false;
            btn_Eliminar.Enabled = true;
            dgv_Alumnos.Enabled = true;
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            Habilitar(false);

            btn_Nuevo.Enabled = true;
            btn_Grabar.Enabled = false;
            btn_Cancelar.Enabled = false;
            btn_Eliminar.Enabled = true;
            dgv_Alumnos.Enabled = true;
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            sInd = "3";
            int indice = dgv_Alumnos.CurrentRow.Index;
            txt_codigo.Text = dgv_Alumnos.Rows[indice].Cells[0].Value.ToString();
            Eliminar();
            Limpiar();
            Listar();

        }

        private void dgv_Alumnos_DoubleClick(object sender, EventArgs e)
        {
            sInd = "2";
            int indice = dgv_Alumnos.CurrentRow.Index;

            txt_codigo.Text= dgv_Alumnos.Rows[indice].Cells[0].Value.ToString();
            txt_paterno.Text = dgv_Alumnos.Rows[indice].Cells[1].Value.ToString();
            txt_materno.Text = dgv_Alumnos.Rows[indice].Cells[2].Value.ToString();
            txt_nombres.Text = dgv_Alumnos.Rows[indice].Cells[3].Value.ToString();
            txt_direccion.Text = dgv_Alumnos.Rows[indice].Cells[4].Value.ToString();
            dtp_fechanac.Value = Convert.ToDateTime(dgv_Alumnos.Rows[indice].Cells[5].Value.ToString());


            btn_Nuevo.Enabled = false;
            btn_Grabar.Enabled = true;
            btn_Cancelar.Enabled = true;
            btn_Eliminar.Enabled = false;
            dgv_Alumnos.Enabled = false;

        }


    }
}
