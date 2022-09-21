using AutoMapper;
using JepcoBackEndSystemProject.Models.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SAPReference;

//using JepcoBackEndSystemProject.Services.DataTransferObject.ErrorLogs;

using JepcoBackEndSystemProject.Services.DataTransferObject;
//using JepcoBackEndSystemProject.Services.DataTransferObject.MeterReaderCompaniesReports;

namespace JepcoBackEndSystemProject.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            

            //Error Logs
           // CreateMap<TbErrorLogs, ErrorLogsReturnDto>();
          //  CreateMap<ErrorLogsAddDto, TbErrorLogs>();
            //CreateMap<TbUnReadedMeters, ReturnUnreadedMetersDto>()
            //    .ForMember(dest => dest.InternalNumber, o => o.MapFrom(src => src.INTERNAL_NUMBER))
            //    .ForMember(dest => dest.InstallationNumber, o => o.MapFrom(src => src.INSTALLATION_NUMBER))
            //    .ForMember(dest => dest.CustomerName, o => o.MapFrom(src => src.CUSTOMER_NAME))
            //    .ForMember(dest => dest.MeterNumber, o => o.MapFrom(src => src.METER_NUMBER))
            //    .ForMember(dest => dest.mru, o => o.MapFrom(src => src.MRU))
            //    .ForMember(dest => dest.ReaderCode, o => o.MapFrom(src => src.READER_CODE))
            //    .ForMember(dest => dest.ReaderName, o => o.MapFrom(src => src.READER_NAME))
            //    .ForMember(dest => dest.BranchCode, o => o.MapFrom(src => src.BRANCH_CODE))
            //    .ForMember(dest => dest.BranchName, o => o.MapFrom(src => src.BRANCH_NAME))
            //    .ForMember(dest => dest.Id, o => o.MapFrom(src => src.ID))
            //     .ForMember(dest => dest.ContractNumber, o => o.MapFrom(src => src.CONTRACT_NUMBER == null ? "": src.CONTRACT_NUMBER))
            //     .ForMember(dest => dest.ConsumptionAvarage, o => o.MapFrom(src => src.CONSUMPTION_AVARAGE == null ? "" : src.CONSUMPTION_AVARAGE))
            //     .ForMember(dest => dest.UnreadedRemainingDays, o => o.MapFrom(src => src.UNREADED_REMAINING_DAYS.HasValue == true ? src.UNREADED_REMAINING_DAYS.ToString(): ""))
            //    .ForMember(dest => dest.ContractStartingDate, o => o.MapFrom(src => src.CONTRACT_STARTING_DATE.HasValue == true? src.CONTRACT_STARTING_DATE.Value.ToString("yyyy-MM-dd"): ""))
            //    .ForMember(dest => dest.LastMeterReadingDate, o => o.MapFrom(src => src.LAST_METER_READING_DATE.HasValue == true ? src.LAST_METER_READING_DATE.Value.ToString("yyyy-MM-dd") : ""))

            //    .ForMember(dest => dest.ScheduleDate, o => o.MapFrom(src => src.SCHEDULE_DATE.ToString("yyyy-MM-dd")));



            //CreateMap<TbSummaryMetersReads, ReturnSummaryMeterReadsDto>()
            //    .ForMember(dest => dest.InternalNumber, o => o.MapFrom(src => src.INTERNAL_NUMBER))
            //    .ForMember(dest => dest.mru, o => o.MapFrom(src => src.MRU))
            //    .ForMember(dest => dest.ReaderCode, o => o.MapFrom(src => src.READER_CODE))
            //    .ForMember(dest => dest.ReaderName, o => o.MapFrom(src => src.READER_NAME))
            //    .ForMember(dest => dest.BranchCode, o => o.MapFrom(src => src.BRANCH_CODE))
            //    .ForMember(dest => dest.BranchName, o => o.MapFrom(src => src.BRANCH_NAME))
            //    .ForMember(dest => dest.TotalMeters, o => o.MapFrom(src => src.TOTAL_METERS))
            //    .ForMember(dest => dest.TotalReadedMeters, o => o.MapFrom(src => src.TOTAL_READED_METERS))
            //    .ForMember(dest => dest.TotalUreadedMeters, o => o.MapFrom(src => src.TOTAL_UNREDED_METERS))
            //    .ForMember(dest => dest.Id, o => o.MapFrom(src => src.ID))
            //    .ForMember(dest => dest.ScheduleDate, o => o.MapFrom(src => src.SCHEDULE_DATE.ToString("yyyy-MM-dd")));


            //CreateMap<TbCompanyMetersSummaryPerDay, CompanyMetersSummaryPerDayDTO>()
            //   .ForMember(dest => dest.INTERNAL_NUMBER, o => o.MapFrom(src => src.INTERNAL_NUMBER))
            //   .ForMember(dest => dest.SUMMARY_DATE, o => o.MapFrom(src => src.SUMMARY_DATE))
            //   .ForMember(dest => dest.TOTAL_METERS, o => o.MapFrom(src => src.TOTAL_METERS))
            //   .ForMember(dest => dest.TOTAL_READED_METERS, o => o.MapFrom(src => src.TOTAL_READED_METERS))
            //   .ForMember(dest => dest.TOTAL_UNREDED_METERS, o => o.MapFrom(src => src.TOTAL_UNREDED_METERS));
             



            //    .ForMember(dest => dest.BillYear, o => o.MapFrom(src => int.Parse(src.BILLYEAR)))
            //    .ForMember(dest => dest.BillMonth, o => o.MapFrom(src => int.Parse(src.BILLMONTH)))
            //    .ForMember(dest => dest.NetConsumption, o => o.MapFrom(src => Decimal.Parse(src.NETCONSUMPTION)))
            //    .ForMember(dest => dest.BillAmount, o => o.MapFrom(src => Decimal.Parse(src.BILLAMOUNT)))
            //    .ForMember(dest => dest.LastUpdateDate, o => o.MapFrom(src => src.LASTUPDATEDATE)).ReverseMap();

            //SelfMeterRead


            //CreateMap<TbNAFCustomerInfos, EMRCCustomerInfosReturnDto>();
            //CreateMap<EMRCCustomerInfosReturnDto, TbNAFCustomerInfos>();
            //CreateMap<EMRCCustomerInfosAddDto, TbNAFCustomerInfos>();
            //CreateMap<EMRCCustomerInfosUpdateDto, TbNAFCustomerInfos>();

            //CreateMap<TbJepcoBillsConsumptions, JepcoBillsConsumptionsReturnDto>()
            //    .ForMember(dest => dest.InternalNumber, o => o.MapFrom(src => src.INTERNALNUMBER))
            //    .ForMember(dest => dest.FileNumber, o => o.MapFrom(src => src.FILENUMBER))
            //    .ForMember(dest => dest.CustomerName, o => o.MapFrom(src => src.CUSTOMERNAME))
            //    .ForMember(dest => dest.BillYear, o => o.MapFrom(src => int.Parse(src.BILLYEAR)))
            //    .ForMember(dest => dest.BillMonth, o => o.MapFrom(src => int.Parse(src.BILLMONTH)))
            //    .ForMember(dest => dest.NetConsumption, o => o.MapFrom(src => Decimal.Parse(src.NETCONSUMPTION)))
            //    .ForMember(dest => dest.BillAmount, o => o.MapFrom(src => Decimal.Parse(src.BILLAMOUNT)))
            //    .ForMember(dest => dest.LastUpdateDate, o => o.MapFrom(src => src.LASTUPDATEDATE)).ReverseMap();
            ////CreateMap<JepcoBillsConsumptionsReturnDto, TbJepcoBillsConsumptions>()
            //// .ForMember(dest => dest.INTERNALNUMBER, o => o.MapFrom(src => src.InternalNumber))
            ////    .ForMember(dest => dest.FILENUMBER, o => o.MapFrom(src => src.FileNumber))
            ////    .ForMember(dest => dest.CUSTOMERNAME, o => o.MapFrom(src => src.CustomerName))
            ////    .ForMember(dest => dest.BILLYEAR, o => o.MapFrom(src => src.BillYear.ToString()))
            ////    .ForMember(dest => dest.BILLMONTH, o => o.MapFrom(src => src.BillMonth.ToString()))
            ////    .ForMember(dest => dest.NETCONSUMPTION, o => o.MapFrom(src => src.NetConsumption.ToString()))
            ////    .ForMember(dest => dest.BILLAMOUNT, o => o.MapFrom(src => src.BillAmount.ToString()))
            ////    .ForMember(dest => dest.LASTUPDATEDATE, o => o.MapFrom(src => src.LastUpdateDate));
            //CreateMap<JepcoBillsConsumptionsAddDto, TbJepcoBillsConsumptions>()
            //.ForMember(dest => dest.INTERNALNUMBER, o => o.MapFrom(src => src.InternalNumber))
            //    .ForMember(dest => dest.FILENUMBER, o => o.MapFrom(src => src.FileNumber))
            //    .ForMember(dest => dest.CUSTOMERNAME, o => o.MapFrom(src => src.CustomerName))
            //    .ForMember(dest => dest.BILLYEAR, o => o.MapFrom(src => src.BillYear.ToString()))
            //    .ForMember(dest => dest.BILLMONTH, o => o.MapFrom(src => src.BillMonth.ToString()))
            //    .ForMember(dest => dest.NETCONSUMPTION, o => o.MapFrom(src => src.NetConsumption.ToString()))
            //    .ForMember(dest => dest.BILLAMOUNT, o => o.MapFrom(src => src.BillAmount.ToString()))
            //    .ForMember(dest => dest.LASTUPDATEDATE, o => o.MapFrom(src => src.LastUpdateDate));
            //CreateMap<JepcoBillsConsumptionsUpdateDto, TbJepcoBillsConsumptions>()
            //.ForMember(dest => dest.INTERNALNUMBER, o => o.MapFrom(src => src.InternalNumber))
            //    .ForMember(dest => dest.FILENUMBER, o => o.MapFrom(src => src.FileNumber))
            //    .ForMember(dest => dest.CUSTOMERNAME, o => o.MapFrom(src => src.CustomerName))
            //    .ForMember(dest => dest.BILLYEAR, o => o.MapFrom(src => src.BillYear.ToString()))
            //    .ForMember(dest => dest.BILLMONTH, o => o.MapFrom(src => src.BillMonth.ToString()))
            //    .ForMember(dest => dest.NETCONSUMPTION, o => o.MapFrom(src => src.NetConsumption.ToString()))
            //    .ForMember(dest => dest.BILLAMOUNT, o => o.MapFrom(src => src.BillAmount.ToString()))
            //    .ForMember(dest => dest.LASTUPDATEDATE, o => o.MapFrom(src => src.LastUpdateDate));


            //.ForMember(dest => dest.FileNumber, o => o.MapFrom(src => src.FileNumber))


        }
    }
}
