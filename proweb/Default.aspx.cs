using library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proweb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // Solo se carga la primera vez que se abre la página
            {
                ENCategory categoria = new ENCategory();
                categoryDropDown.DataSource = categoria.readAll();
                categoryDropDown.DataTextField = "Name"; // Lo que ve el usuario
                categoryDropDown.DataValueField = "Id";  // El valor interno que se guarda
                categoryDropDown.DataBind();
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                ENProduct en = new ENProduct();
                en.Code = codeTextBox.Text;

                if (en.read())
                {
                    statusLabel.ForeColor = System.Drawing.Color.Red;
                    statusLabel.Text = "Error: Ya existe un producto con ese Code en la base de datos.";
                    return; 
                }

                en.Name = nameTextBox.Text;
                en.Amount = int.Parse(amountTextBox.Text);
                en.Price = float.Parse(priceTextBox.Text);
                en.Category = int.Parse(categoryDropDown.SelectedValue);
                en.CreationDate = DateTime.Parse(creationDateTextBox.Text);

                
                if (en.create())
                {
                    statusLabel.ForeColor = System.Drawing.Color.Green;
                    statusLabel.Text = "¡Producto creado con éxito!";
                }
                else
                {
                    statusLabel.ForeColor = System.Drawing.Color.Red;
                    statusLabel.Text = "Error al intentar crear el producto.";
                }
            }
            catch (FormatException)
            {
                statusLabel.ForeColor = System.Drawing.Color.Red;
                statusLabel.Text = "Error de formato: Asegúrate de que los números y la fecha (dd/mm/aaaa) sean correctos.";
            }
            catch (Exception ex)
            {
                statusLabel.ForeColor = System.Drawing.Color.Red;
                statusLabel.Text = "Ha ocurrido un error inesperado: " + ex.Message;
            }
        }

        protected void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(codeTextBox.Text))
                {
                    statusLabel.ForeColor = System.Drawing.Color.Red;
                    statusLabel.Text = "Por favor, introduce un Code para leer el producto.";
                    return;
                }

                ENProduct en = new ENProduct();
                en.Code = codeTextBox.Text;

                if (en.read())
                {
                    nameTextBox.Text = en.Name;
                    amountTextBox.Text = en.Amount.ToString();
                    priceTextBox.Text = en.Price.ToString();

                    categoryDropDown.SelectedValue = en.Category.ToString();

                    creationDateTextBox.Text = en.CreationDate.ToString("dd/MM/yyyy HH:mm:ss");

                    [cite_start]
                    statusLabel.ForeColor = System.Drawing.Color.Green;
                    statusLabel.Text = "¡Producto leído correctamente!";
                }
                else
                {
                    statusLabel.ForeColor = System.Drawing.Color.Red;
                    statusLabel.Text = "Error: No se ha encontrado ningún producto con ese Code.";

                    nameTextBox.Text = "";
                    amountTextBox.Text = "";
                    priceTextBox.Text = "";
                    creationDateTextBox.Text = "";
                }
            }
            catch (Exception ex)
            {
                [cite_start]
                statusLabel.ForeColor = System.Drawing.Color.Red;
                statusLabel.Text = "Ha ocurrido un error al leer el producto: " + ex.Message;
            }
        }

        protected void btnFirst_Click(object sender, EventArgs e)
        {
            try
            {
                ENProduct en = new ENProduct();
                if (en.readFirst())
                {
                    // Si encuentra el primero, rellenamos el formulario
                    codeTextBox.Text = en.Code;
                    nameTextBox.Text = en.Name;
                    amountTextBox.Text = en.Amount.ToString();
                    priceTextBox.Text = en.Price.ToString();
                    categoryDropDown.SelectedValue = en.Category.ToString();
                    creationDateTextBox.Text = en.CreationDate.ToString("dd/MM/yyyy HH:mm:ss");

                    statusLabel.ForeColor = System.Drawing.Color.Green;
                    statusLabel.Text = "Primer producto leído.";
                }
                else
                {
                    statusLabel.ForeColor = System.Drawing.Color.Red;
                    statusLabel.Text = "La base de datos de productos está vacía.";
                }
            }
            catch (Exception ex) { statusLabel.Text = "Error: " + ex.Message; }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                ENProduct en = new ENProduct();
                en.Code = codeTextBox.Text; // Le pasamos el código actual para que busque el siguiente

                if (en.readNext())
                {
                    codeTextBox.Text = en.Code;
                    nameTextBox.Text = en.Name;
                    amountTextBox.Text = en.Amount.ToString();
                    priceTextBox.Text = en.Price.ToString();
                    categoryDropDown.SelectedValue = en.Category.ToString();
                    creationDateTextBox.Text = en.CreationDate.ToString("dd/MM/yyyy HH:mm:ss");

                    statusLabel.ForeColor = System.Drawing.Color.Green;
                    statusLabel.Text = "Siguiente producto leído.";
                }
                else
                {
                    statusLabel.ForeColor = System.Drawing.Color.Red;
                    statusLabel.Text = "No hay más productos en adelante.";
                }
            }
            catch (Exception ex) { statusLabel.Text = "Error: " + ex.Message; }
        }

        protected void btnPrev_Click(object sender, EventArgs e)
        {
            try
            {
                ENProduct en = new ENProduct();
                en.Code = codeTextBox.Text; // Le pasamos el código actual para que busque el anterior

                if (en.readPrev())
                {
                    codeTextBox.Text = en.Code;
                    nameTextBox.Text = en.Name;
                    amountTextBox.Text = en.Amount.ToString();
                    priceTextBox.Text = en.Price.ToString();
                    categoryDropDown.SelectedValue = en.Category.ToString();
                    creationDateTextBox.Text = en.CreationDate.ToString("dd/MM/yyyy HH:mm:ss");

                    statusLabel.ForeColor = System.Drawing.Color.Green;
                    statusLabel.Text = "Producto anterior leído.";
                }
                else
                {
                    statusLabel.ForeColor = System.Drawing.Color.Red;
                    statusLabel.Text = "No hay productos anteriores.";
                }
            }
            catch (Exception ex) { statusLabel.Text = "Error: " + ex.Message; }
        }
    }
}