using System;
using System.ComponentModel.DataAnnotations;

namespace JepcoBackEndSystemProject.EService.DataTransferObject.MaintenanceSAPInsertRequest
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class D
    {
        public string Vertrag { get; set; }
        public string ApiTyp { get; set; }
        public string BuSort1 { get; set; }
        public ImBp ImBp { get; set; }
        public ImAtt ImAtt { get; set; }
        public ImSrvN ImSrvN { get; set; }
    }

    public class ImAtt
    {
        public string Image1 { get; set; }
        public string Des1 { get; set; }
    }

    public class ImBp
    {
        public string MobileNumber { get; set; }
    }

    public class ImSrvN
    {
        public string Priority { get; set; }
        public string NotifAddr { get; set; }
        public string PlntLocCode { get; set; }
        public string TextHeader { get; set; }
    }

    public class MaintenanceInsertSAPRequestDto
    {
        public D d { get; set; }
    }






}

