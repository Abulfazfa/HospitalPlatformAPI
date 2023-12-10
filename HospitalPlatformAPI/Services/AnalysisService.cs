using AutoMapper;
using HospitalPlatformAPI.DTOs.Analysis;
using HospitalPlatformAPI.DTOs.Test;
using HospitalPlatformAPI.Models;
using HospitalPlatformAPI.Repositories.Interfaces;
using HospitalPlatformAPI.Services.Interfaces;

namespace HospitalPlatformAPI.Services
{
    public class AnalysisService : IAnalysisService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AnalysisService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public List<Analysis> Get()
        {
            var analyses = _unitOfWork.AnalysisRepository.Include(a => a.AnalysisResult).ToList();
            var list = new List<Analysis>();
            foreach (var analysis in analyses)
            {
                list.Add(analysis);
            }
            return list;
        }

        public bool Add(AnalysisCreateDto analysisCreateDto)
        {
            try
            {
                Analysis analysis = _mapper.Map<Analysis>(analysisCreateDto);
                AnalysisResult analysisResult = new();
                analysis.AnalysisResult = analysisResult;
        
                if (analysisCreateDto.KeyEntries != null && analysisCreateDto.KeyEntries.Count > 0)
                {
                    foreach (var item in analysisCreateDto.KeyEntries)
                    {
                        AnalysisNameAndResultEntry entry = new AnalysisNameAndResultEntry(); 

                        entry.Key = item.Key;
                        entry.Value = item.Value;
                        //entry.Desc = item.Desc; 

                        analysisResult.TestNameAndResultEntry.Add(entry);
                    }
                }

                _unitOfWork.AnalysisRepository.AddAsync(analysis);
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception e)
            {
                // Log the exception e for debugging purposes
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var test = Get(id);
                var result = _unitOfWork.AnalysisRepository.DeleteAsync(test).GetAwaiter().GetResult;
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }



        // public bool Update(AnalysisCreateDto analysis)
        // {
        //     var groupEntity = _mapper.Map<Analysis>(analysis);
        //
        //     var existingGroup = _unitOfWork.AnalysisRepository.GetByIdAsync(groupEntity.Id).Result;
        //
        //     if (existingGroup == null)
        //     {
        //         return false;
        //     }
        //
        //     existingGroup.Name = analysis.Name;
        //     existingGroup.Price = analysis.price;
        //     _unitOfWork.Commit();
        //     return true;
        // }


        public Analysis Get(int id)
        {
            return _unitOfWork.AnalysisRepository.GetByIdAsync(id).Result;
        }
    }
}
