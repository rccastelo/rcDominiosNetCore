using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace rcDominiosCriptografia
{
  public class Criptografia
  {
    private const string conSal = "6DEDCA12EAF258EF";
    private const string conChv = "15010CB6E7AD9B8CBD3D80D7E7539E80";
    private const string conVet = "A08FD5BA3BFA17C3";

    /// <summary>
    /// Misturar o texto com alguns caracteres
    /// </summary>
    /// <param name="texto"></param>
    /// <returns>resultado</returns>
    public static string Salgar(string texto)
    {
      string resultado = null;

      if (!String.IsNullOrEmpty(texto))
      {
        int tamanhoTexto = texto.Length;
        int contador = 0;

        for (contador = 0; contador < tamanhoTexto; contador++)
        {
          resultado += texto[contador].ToString();

          if (contador < 16)
            resultado += conSal[contador].ToString();
        }
      }
      else
      {
        resultado = texto;
      }

      return resultado;
    }

    /// <summary>
    /// Retirar caracteres misturados no texto
    /// </summary>
    /// <param name="texto"></param>
    /// <returns>resultado</returns>
    public static string Desalgar(string texto)
    {
      string resultado = null;

      if (!String.IsNullOrEmpty(texto))
      {
        int tamanhoTexto = texto.Length;
        int contador = 0;

        for (contador = 0; contador < tamanhoTexto; contador++)
        {
          if (contador < 32)
          {
            if (contador % 2 == 0)
            {
              resultado += texto[contador].ToString();
            }
          }
          else
          {
            resultado += texto[contador].ToString();
          }
        }
      }
      else
      {
        resultado = texto;
      }

      return resultado;
    }

/// <summary>
    /// Transformar texto comum para texto desconhecido descriptografável
    /// </summary>
    /// <returns></returns>
    public static string Criptografar(string texto, string chave, string vetor)
    {
      try
      {
        if (texto != null)
        {
          byte[] byteVetor = null;
          byte[] byteChave = null;
          byte[] textoByte = null;

          MemoryStream memoryStream = null;
          CryptoStream cryptoStream = null;
          ICryptoTransform iCryptoTransform = null;
          Rijndael rijndael = null;

          byteChave = ASCIIEncoding.ASCII.GetBytes(chave);
          textoByte = ASCIIEncoding.ASCII.GetBytes(texto);
          byteVetor = ASCIIEncoding.ASCII.GetBytes(vetor);

          rijndael = new RijndaelManaged();
          rijndael.KeySize = 256;
          rijndael.Key = byteChave;
          rijndael.IV = byteVetor;
          rijndael.BlockSize = 128;
          rijndael.Padding = PaddingMode.PKCS7;

          iCryptoTransform = rijndael.CreateEncryptor(byteChave, byteVetor);

          memoryStream = new MemoryStream();

          cryptoStream = new CryptoStream(memoryStream, iCryptoTransform, CryptoStreamMode.Write);
          cryptoStream.Write(textoByte, 0, textoByte.Length);
          cryptoStream.FlushFinalBlock();
          cryptoStream.Close();
          memoryStream.Close();

          textoByte = memoryStream.ToArray();

          texto = Convert.ToBase64String(textoByte);
        }
      }
      catch
      {
        texto = null;
      }

      return texto;
    }

    /// <summary>
    /// Transformar texto desconhecido descriptografável para texto comum
    /// </summary>
    /// <returns></returns>
    public static string Descriptografar(string texto, string chave, string vetor)
    {
      try
      {
        if (texto != null)
        {
          byte[] byteVetor = null;
          byte[] textoByte = null;
          byte[] byteChave = null;

          MemoryStream memoryStream = null;
          CryptoStream cryptoStream = null;
          ICryptoTransform iCryptoTransform = null;
          Rijndael rijndael = null;

          byteChave = ASCIIEncoding.ASCII.GetBytes(chave);
          byteVetor = ASCIIEncoding.ASCII.GetBytes(vetor);

          rijndael = new RijndaelManaged();
          rijndael.KeySize = 256;
          rijndael.Key = byteChave;
          rijndael.IV = byteVetor;
          rijndael.BlockSize = 128;
          rijndael.Padding = PaddingMode.PKCS7;

          iCryptoTransform = rijndael.CreateDecryptor(byteChave, byteVetor);

          memoryStream = new MemoryStream();

          textoByte = Convert.FromBase64String(texto);

          cryptoStream = new CryptoStream(memoryStream, iCryptoTransform, CryptoStreamMode.Write);
          cryptoStream.Write(textoByte, 0, textoByte.Length);
          cryptoStream.FlushFinalBlock();
          cryptoStream.Close();
          memoryStream.Close();

          textoByte = memoryStream.ToArray();

          texto = ASCIIEncoding.ASCII.GetString(textoByte);
        }
      }
      catch
      {
        texto = null;
      }

      return texto;
    }

    /// <summary>
    /// Transformar texto comum para texto desconhecido descriptografável
    /// </summary>
    /// <returns></returns>
    public static string Criptografar(string texto)
    {
      return Criptografar(texto, conChv, conVet);
    }

    /// <summary>
    /// Transformar texto desconhecido descriptografável para texto comum
    /// </summary>
    /// <returns></returns>
    public static string Descriptografar(string texto)
    {
      return Descriptografar(texto, conChv, conVet);
    }

    /// <summary>
    /// Transformar texto comum para texto desconhecido descriptografável
    /// </summary>
    /// <returns></returns>
    public static string Criptografar(string texto, string chave)
    {
      return Criptografar(texto, chave, conVet);
    }

    /// <summary>
    /// Transformar texto desconhecido descriptografável para texto comum
    /// </summary>
    /// <returns></returns>
    public static string Descriptografar(string texto, string chave)
    {
      return Descriptografar(texto, chave, conVet);
    }

    /// <summary>
    /// Transformar texto comum para texto desconhecido não descriptografável / Hash / MD5
    /// </summary>
    /// <returns></returns>
    public static string CriptravarMD5(string texto)
    {
      string segredo = null;

      try
      {
        if (!String.IsNullOrEmpty(texto))
        {
          segredo = texto;

          byte[] textoByte = null;
          byte[] textoHash = null;

          StringBuilder sb = null;
          MD5 md5 = null;

          md5 = MD5.Create();

          textoByte = ASCIIEncoding.ASCII.GetBytes(segredo);

          textoHash = md5.ComputeHash(textoByte);

          sb = new StringBuilder();

          for (int i = 0; i < textoHash.Length; i++)
          {
            sb.Append(textoHash[i].ToString("X2"));
          }

          segredo = sb.ToString();
        }
      }
      catch
      {
        segredo = null;
      }

      return segredo;
    }

    /// <summary>
    /// Transformar texto comum para texto desconhecido não descriptografável / Hash / SHA1
    /// </summary>
    /// <returns></returns>
    public static string CriptravarSHA1(string texto)
    {
      string segredo = null;

      try
      {
        if (!String.IsNullOrEmpty(texto))
        {
          byte[] textoByte = null;
          byte[] textoHash = null;

          StringBuilder sb = null;
          SHA1Managed sha1 = null;

          sha1 = new SHA1Managed();

          textoByte = ASCIIEncoding.ASCII.GetBytes(texto);

          textoHash = sha1.ComputeHash(textoByte);

          sb = new StringBuilder();

          for (int i = 0; i < textoHash.Length; i++)
          {
            sb.Append(textoHash[i].ToString("X2"));
          }

          segredo = sb.ToString();
        }
      }
      catch
      {
        segredo = null;
      }

      return segredo;
    }

    /// <summary>
    /// Transformar texto comum para texto desconhecido não descriptografável / Hash / SHA256
    /// </summary>
    /// <returns></returns>
    public static string CriptravarSHA256(string texto)
    {
      string segredo = null;

      try
      {
        if (!String.IsNullOrEmpty(texto))
        {
          byte[] textoByte = null;
          byte[] textoHash = null;

          StringBuilder sb = null;
          SHA256Managed sha256 = null;

          sha256 = new SHA256Managed();

          textoByte = ASCIIEncoding.ASCII.GetBytes(texto);

          textoHash = sha256.ComputeHash(textoByte);

          sb = new StringBuilder();

          for (int i = 0; i < textoHash.Length; i++)
          {
            sb.Append(textoHash[i].ToString("X2"));
          }

          segredo = sb.ToString();
        }
      }
      catch
      {
        segredo = null;
      }

      return segredo;
    }

    /// <summary>
    /// Transformar texto comum para texto desconhecido não descriptografável / Hash / SHA512
    /// </summary>
    /// <returns></returns>
    public static string CriptravarSHA512(string texto)
    {
      string segredo = null;

      try
      {
        if (!String.IsNullOrEmpty(texto))
        {
          byte[] textoByte = null;
          byte[] textoHash = null;

          StringBuilder sb = null;
          SHA512Managed sha512 = null;

          sha512 = new SHA512Managed();

          textoByte = ASCIIEncoding.ASCII.GetBytes(texto);

          textoHash = sha512.ComputeHash(textoByte);

          sb = new StringBuilder();

          for (int i = 0; i < textoHash.Length; i++)
          {
            sb.Append(textoHash[i].ToString("X2"));
          }

          segredo = sb.ToString();
        }
      }
      catch
      {
        segredo = null;
      }

      return segredo;
    }
  }
}
