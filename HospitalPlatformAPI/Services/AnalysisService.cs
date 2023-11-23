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
        public TestReturnDto GetById(int id)
        {
            var test = Get(id);
            return _mapper.Map<TestReturnDto>(test);
        }

        public bool Add(AnalysisCreateDto analysisCreateDto)
        {
            try
            {
                Analysis analysis = _mapper.Map<Analysis>(analysisCreateDto);
                _unitOfWork.AnalysisRepository.AddAsync(analysis);
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var test = Get(id);
                var result = _unitOfWork.TestRepository.DeleteAsync(test).GetAwaiter().GetResult;
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }



        public bool Update(TestCreateDto testCreateDto)
        {
            var groupEntity = _mapper.Map<Test>(testCreateDto);

            var existingGroup = _unitOfWork.TestRepository.GetByIdAsync(groupEntity.Id).Result;

            if (existingGroup == null)
            {
                return false;
            }

            existingGroup.AnalysisName = testCreateDto.Name;
            existingGroup.RefDoctor = testCreateDto.RefDoctor;
            _unitOfWork.Commit();
            return true;
        }


        private Test Get(int id)
        {
            return _unitOfWork.TestRepository.Include(a => a.AnalysisResult).FirstOrDefault(a => a.Id == id);
        }
    }
}
