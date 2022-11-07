using System;
using System.ComponentModel.DataAnnotations;

namespace JepcoBackEndSystemProject.EService.DataTransferObject.MaintenanceInsertSAPResponse
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class D
    {
        public Metadata __metadata { get; set; }
        public ImBp ImBp { get; set; }
        public ImAtt ImAtt { get; set; }
        public ImSrvN ImSrvN { get; set; }
        public string Vertrag { get; set; }
        public string ApiTyp { get; set; }
        public string BuSort1 { get; set; }
        public string MsgNotifNo { get; set; }
        public string MsgPassFail { get; set; }
        public string MsgSapBpNo { get; set; }
        public string MsgSapNameBp { get; set; }
        public string MsgStat { get; set; }
        public string MsgStatTyp { get; set; }
    }

    public class ImAtt
    {
        public Metadata __metadata { get; set; }
        public string Image1 { get; set; }
        public string Des1 { get; set; }
        public string Image2 { get; set; }
        public string Des2 { get; set; }
        public string Image3 { get; set; }
        public string Des3 { get; set; }
        public string Image4 { get; set; }
        public string Des4 { get; set; }
        public string Image5 { get; set; }
        public string Des5 { get; set; }
        public string Image6 { get; set; }
        public string Des6 { get; set; }
        public string Image7 { get; set; }
        public string Des7 { get; set; }
        public string Image8 { get; set; }
        public string Des8 { get; set; }
        public string Image9 { get; set; }
        public string Des9 { get; set; }
        public string Image10 { get; set; }
        public string Des10 { get; set; }
        public string Image11 { get; set; }
        public string Des11 { get; set; }
        public string Image12 { get; set; }
        public string Des12 { get; set; }
        public string Image13 { get; set; }
        public string Des13 { get; set; }
        public string Image14 { get; set; }
        public string Des { get; set; }
    }

    public class ImBp
    {
        public Metadata __metadata { get; set; }
        public string Idnumber { get; set; }
        public string IdType { get; set; }
        public string FisrtName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public string MobileNumber { get; set; }
        public string CityCode { get; set; }
        public string CityTxt { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string Nationality { get; set; }
    }

    public class ImSrvN
    {
        public Metadata __metadata { get; set; }
        public string NotifNo { get; set; }
        public string Priority { get; set; }
        public string NotifAddr { get; set; }
        public string PlntLocCode { get; set; }
        public string TextHeader { get; set; }
    }

    public class Metadata
    {
        public string id { get; set; }
        public string uri { get; set; }
        public string type { get; set; }
    }

    public class MaintenanceInsertSAPResponseDto
    {
        public D d { get; set; }
    }







}

