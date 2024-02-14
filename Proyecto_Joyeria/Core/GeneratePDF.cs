using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.IO;
using System.Windows;

using static Proyecto_Joyeria.Model.Model_Producto;

using Proyecto_Joyeria.Model;


namespace Proyecto_Joyeria.Core
{
    internal class GeneratePDF
    {

        public void crearPDF(Model_Producto p, Model_Person mp)
        {
            //string rutaAplicacion = Directory.GetCurrentDirectory();
           // string rutaAplicacion = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Descargas");
            string rutaAplicacion = "C:\\Users\\Usuario\\Desktop";
            string nombreArchivo = "Factura.pdf";

            string rutaCompleta = System.IO.Path.Combine(rutaAplicacion, nombreArchivo);
            
            PdfWriter pdfWriter = new PdfWriter(rutaCompleta);
            PdfDocument pdf = new PdfDocument(pdfWriter);
           
            PageSize tamanio = new PageSize(612, 792);
            Document documento = new Document(pdf, tamanio);
            //Document documento = new Document(pdf, PageSize.LETTER);

            documento.SetMargins(80, 20, 55, 20);

            PdfFont fontColumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            PdfFont fontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

            //string[] columnas = { "ID","Categoria", "Dueño", "Producto", "Descripción", "Modificacion", "Precio" };
            string[] columnasProducto = { "ID", "Categoria", "Producto", "Descripción", "Modificacion", "Precio" };
            float[] tamaniosProductos = { 2, 6, 6, 10, 10, 2 };

            var encabezado = new Paragraph("Factura").SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetBold().SetFontSize(28).SetFontColor(new DeviceRgb(255, 0, 0));
            var subtitulo = new Paragraph("Detalles del Producto").SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFontSize(16);

            documento.Add(encabezado);
            documento.Add(subtitulo);

            Table tabla = new Table(UnitValue.CreatePercentArray(tamaniosProductos));
            tabla.SetWidth(UnitValue.CreatePercentValue(100));

            foreach (string columna in columnasProducto)
            {
                tabla.AddHeaderCell(new Cell().Add(new Paragraph(columna).SetFont(fontColumnas)));
            }

            tabla.AddCell(new Cell().Add(new Paragraph(p.IdProducto.ToString()).SetFont(fontContenido)));
            tabla.AddCell(new Cell().Add(new Paragraph(p.NombreCategoria).SetFont(fontContenido)));
            // tabla.AddCell(new Cell().Add(new Paragraph(p.NombrePersona).SetFont(fontContenido)));
            tabla.AddCell(new Cell().Add(new Paragraph(p.Nombre).SetFont(fontContenido)));
            tabla.AddCell(new Cell().Add(new Paragraph(p.Informacion).SetFont(fontContenido)));
            tabla.AddCell(new Cell().Add(new Paragraph(p.Modificacion).SetFont(fontContenido)));
           
            tabla.AddCell(new Cell().Add(new Paragraph(p.Precio.ToString("C")).SetFont(fontContenido).SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT)));


            documento.Add(tabla);

            string[] columnasPersona = { "ID", "Nombre", "Email"};
            float[] tamaniosPersona = { 2, 6, 15};

            Table tablaP = new Table(UnitValue.CreatePercentArray(tamaniosPersona));
            tablaP.SetWidth(UnitValue.CreatePercentValue(100));

            foreach (string columna in columnasPersona)
            {
                tabla.AddHeaderCell(new Cell().Add(new Paragraph(columna).SetFont(fontColumnas)));
            }

            tablaP.AddCell(new Cell().Add(new Paragraph(mp.Id.ToString()).SetFont(fontContenido)));
            tablaP.AddCell(new Cell().Add(new Paragraph(mp.Name).SetFont(fontContenido)));
            tablaP.AddCell(new Cell().Add(new Paragraph(mp.Email).SetFont(fontContenido)));

            documento.Add(tablaP);

            var firma= new Paragraph("Firma: ___________________________").SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFontSize(12).SetMarginTop(100);

            var detallesEmpresa = new Paragraph("El diamante elegante\nC/El Ciego\n9-B").SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT).SetFontSize(10);
            documento.Add(firma);
            documento.Add(detallesEmpresa);

            documento.Close();

            string directorio = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string nombreArchivoNuevo = "Factura_"+ p.NombreCategoria.ToUpper() + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") +
           ".pdf";
            string rutaCompletaNueva = System.IO.Path.Combine(directorio, nombreArchivoNuevo);

            // Preparar cabecera y pie de página
            var logo = new Image(ImageDataFactory.Create(@"..\..\..\Assets\logo.png")).SetWidth(50);
            var plogo = new Paragraph("").Add(logo);

            Color miColor = new DeviceRgb(0, 0, 255);
            var titulo = new Paragraph("Informe de la Factura");
            titulo.SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
            titulo.SetFontColor(miColor);
            titulo.SetBold();
            titulo.SetFontSize(24);

            //var dfecha = DateTime.Now.ToString("dd-MM-yyyy");
            var dfecha = p.FechaRecogida.ToString("dd-MM-yyyy HH:mm");
            //var dhora = DateTime.Now.ToString("HH:mm");
            // var fecha = new Paragraph("Fecha: " + dfecha + "\nHora: " + dhora);
            // var fecha = new Paragraph(p.FechaRecogida.ToString("dd--MM--yyyy"));
            var fecha = new Paragraph("Fecha de finalización: " + dfecha).SetFontSize(12);


            PdfDocument pdfDoc = new PdfDocument(new PdfReader(rutaCompleta), new PdfWriter(rutaCompletaNueva));
            Document doc = new Document(pdfDoc);

            int numeros = pdfDoc.GetNumberOfPages();

            for (int i = 1; i <= numeros; i++)
            {
                PdfPage pagina = pdfDoc.GetPage(i);

                float y = (pdfDoc.GetPage(i).GetPageSize().GetTop() - 15);

                //cabecera
                doc.ShowTextAligned(plogo, 45, y, i, iText.Layout.Properties.TextAlignment.CENTER, iText.Layout.Properties.VerticalAlignment.TOP, 0);
                doc.ShowTextAligned(titulo, 300, y - 15, i, iText.Layout.Properties.TextAlignment.CENTER, iText.Layout.Properties.VerticalAlignment.TOP, 0);
                doc.ShowTextAligned(fecha, 590, y - 55, i, iText.Layout.Properties.TextAlignment.RIGHT, iText.Layout.Properties.VerticalAlignment.TOP, 0);

                //pie de página
                doc.ShowTextAligned(new Paragraph(String.Format("Página {0} de {1}", i, numeros)),
                    pdfDoc.GetPage(i).GetPageSize().GetWidth() / 2,
                    pdfDoc.GetPage(i).GetPageSize().GetBottom() + 30, i, iText.Layout.Properties.TextAlignment.CENTER,
                    iText.Layout.Properties.VerticalAlignment.TOP, 0);
            }

            doc.Close();

            MessageBox.Show("Informe guardado en: " + rutaCompletaNueva);

        }
    }
}
