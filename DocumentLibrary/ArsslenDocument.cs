using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace DocumentLibrary
{
    public class ASDOCReader
    {
        byte[] data;
        int offset;
        public ASDOCReader(string filename)
        {
            offset = 0;
            data = File.ReadAllBytes(filename);
        }
        public byte[] ReadBytes(int length)
        {
            byte[] d = new byte[length];
            for (int i = 0; i <= length-1; i++)
                d[i] = data[offset + i];

            offset += length;
            return d;
        }
        public byte[] ReadFinal()
        {
            byte[] d = new byte[data.Length - offset];
            for (int i = 0; i <= data.Length - offset - 1; i++)
                d[i] = data[offset + i];

            offset = data.Length;
            return d;
        }
        public int ReadInt()
        {
            return BitConverter.ToInt32(ReadBytes(4), 0);
        }
        public long ReadLong()
        {
            return BitConverter.ToInt64(ReadBytes(8), 0);
        }
        public ushort ReadUShort()
        {
            return BitConverter.ToUInt16(ReadBytes(2), 0);
        }
    }
    public class ASDOCWriter
    {
        string file;
        byte[] data;
        public ASDOCWriter(string fileName)
        {
            file = fileName;
          
        }
        public byte[] Append(byte[] dat, byte[] append)
        {
            byte[] dt = new byte[dat.Length + append.Length];
            for (int i = 0; i < dat.Length; i++)
                dt[i] = dat[i];

            for (int i = 0; i < append.Length; i++)
                dt[i+dat.Length] = append[i];

            return dt;
        }
    
        public void Write(ushort ush)
        {
            if (data != null)
                data = Append(data, BitConverter.GetBytes(ush));
            else
                data = BitConverter.GetBytes(ush);
        }
        public void Write(int ush)
        {
            if (data != null)
                data = Append(data, BitConverter.GetBytes(ush));
            else
                data = BitConverter.GetBytes(ush);
        }
        public void Write(long ush)
        {
            if (data != null)
                data = Append(data, BitConverter.GetBytes(ush));
            else
                data = BitConverter.GetBytes(ush);
        }
        public void Write(string ush)
        {
            if (data != null)
                data = Append(data, Encoding.UTF8.GetBytes(ush));
            else
                data = Encoding.UTF8.GetBytes(ush);
        }
        public void Write(byte[] da)
        {
            if (data != null)
                data = Append(data, da);
            else
                data = da;
        }
        public void Finalize()
        {
            File.WriteAllBytes(file,data);
        }
    }
   public static class ArsslenDocument
    {
       public static Dictionary<int, byte[]> CurrentDocumentRessources;
     
       public static void WriteDocument(string fileName,string code, List<string> Ressources)
       {

           ASDOCWriter bw = new ASDOCWriter(fileName);
           
               bw.Write((ushort)Ressources.Count);
               bw.Write(code.Length);
               int i = 0;
               foreach (string f in Ressources)
               {
                   FileInfo fi = new FileInfo(f);
                   bw.Write((int)(fi.Length));
                   bw.Write(i);
                   i++;
               }  
               foreach (string f in Ressources)
               {
                   byte[] b = File.ReadAllBytes(f);
                   bw.Write(b);
               }
               bw.Write(Encoding.UTF8.GetBytes(code));
               bw.Finalize();
           
       }
       public static void Read(string fileName,out string code, out Dictionary<int,byte[]> Ressources)
       {
           Ressources = new Dictionary<int,byte[]>();
           ushort rescount = 0;
           int clength = 0;
           List<int> fc = new List<int>();

           ASDOCReader br = new ASDOCReader(fileName);
          
               rescount = br.ReadUShort();
               clength = br.ReadInt();
               for (int i = 0; i < (int)rescount; i++)
               {
                   int fl = br.ReadInt();
                   int name = br.ReadInt();
                   fc.Add(fl);
               }

              for(int j = 0; j < fc.Count; j++)
                 Ressources.Add(j, br.ReadBytes(fc[j]));
              code = Encoding.UTF8.GetString(br.ReadFinal());
        

           
       }
    }
}
