using Phidelis.Service.Interfaces;
using Phidelis.Entities.DTO;
using System;
using System.Net;
using System.IO;
using System.Text.Json;

namespace HostedService
{

    public class HostedService
    {
        IEnrolmentService Service { get; }

        public HostedService(IEnrolmentService service)
        {
            Service = service;
            DoWork();
        }

        private void DoWork()
        {
            string[] namesList;

            var requisicaoWeb = WebRequest.CreateHttp("https://gerador-nomes.herokuapp.com/nomes/5");
            requisicaoWeb.Method = "GET";

            using (var resposta = requisicaoWeb.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                string objResponse = reader.ReadToEnd().ToString();
                namesList = JsonSerializer.Deserialize<string[]>(objResponse);
                streamDados.Close();
                resposta.Close();
            }

            foreach(string name in namesList)
            {
                var enrolmentDTO = new EnrolmentDTO()
                {
                    Name = name,
                    EnrolmentDate = DateTime.Now
                };

                Service.Add(enrolmentDTO);
            }
        }
    }
}
