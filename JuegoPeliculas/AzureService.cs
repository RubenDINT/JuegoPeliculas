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
            string cadenaConexion = "DefaultEndpointsProtocol=https;AccountName=recursosjuegopeliculas;AccountKey=SGmjMa0VmOIL5rQ1MbrAoulxchT8QWxyrhfpxJy2sfgI3V/NrVH+X1hBdJRsIykiCvcISJyE4YGOQlvMz1WAow==;EndpointSuffix=core.windows.net";
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
