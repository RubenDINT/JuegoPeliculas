using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoPeliculas
{
    class AzureService
    {
        public static string AzureImageService(string rutaImagen)
        {
            string cadenaConexion = "https://recursosjuegopeliculas.blob.core.windows.net/assets";
            string nombreContenedorBlobs = "assets";

            //Obtenemos el cliente del contenedor
            var clienteBlobService = new BlobServiceClient(cadenaConexion);
            var clienteContenedor = clienteBlobService.GetBlobContainerClient(nombreContenedorBlobs);

            //Leemos la imagen y la subimos al contenedor
            Stream streamImagen = File.OpenRead(rutaImagen);
            string nombreImagen = Path.GetFileName(rutaImagen);
            clienteContenedor.UploadBlob(nombreImagen, streamImagen);

            //Una vez subida, obtenemos la URL para referenciarla
            var clienteBlobImagen = clienteContenedor.GetBlobClient(nombreImagen);
            string urlImagen = clienteBlobImagen.Uri.AbsoluteUri;

            return urlImagen;
        }
    }
}
