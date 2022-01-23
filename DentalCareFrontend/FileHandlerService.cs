using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DentalCareBackend;

namespace DentalCareFrontend
{
    class FileHandlerService
    {
        private static string directory = @"data";
        private static string filePath = directory + @"\appointments.xml";

        private FileHandlerService() { }

        //Initializing file service 
        public static void Initialize()
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            if (!File.Exists(filePath))
            {
                var apptDetailsFile = File.Create(filePath);
                apptDetailsFile.Close();
                WriteAppointmentDetails(new PatientList());
            }
        }

        //Reading saved appointment details from file
        public static PatientList ReadAppointmentDetails()
        {
            TextReader reader = null;
            PatientList patients = new PatientList();
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(PatientList));
                reader = new StreamReader(filePath);
                patients = (PatientList)serializer.Deserialize(reader);
            }
            catch (IOException ioe)
            {
                Trace.WriteLine(ioe.ToString());
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }

            return patients;
        }

        //Writing Appointment Details to XML file
        public static void WriteAppointmentDetails(PatientList patients)
        {
            TextWriter writer = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(PatientList));
                writer = new StreamWriter(filePath);
                serializer.Serialize(writer, patients);
            }
            catch (IOException ioe)
            {
                Trace.WriteLine(ioe.ToString());
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }
    }
}
