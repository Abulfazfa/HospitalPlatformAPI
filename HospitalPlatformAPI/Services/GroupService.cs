using AutoMapper;
using HospitalPlatformAPI.DTOs.Group;
using HospitalPlatformAPI.Models;
using HospitalPlatformAPI.Repositories.Interfaces;
using HospitalPlatformAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalPlatformAPI.Services;

public class GroupService : IGroupService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GroupService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public List<GroupReturnDto> GetGroups()
    {
        var groups = _unitOfWork.GroupRepository
            .Include(g => g.Doctors).ToList();
        var list = new List<GroupReturnDto>();
        foreach (var group in groups)
        {
           list.Add(_mapper.Map<GroupReturnDto>(group));
        }
        return list;
    }

    public bool AddGroup(GroupCreateDto groupCreateDto)
    {
        try
        {
            var group = _mapper.Map<Group>(groupCreateDto);
            group.OfficeId = _unitOfWork.OfficeRepository.GetByPredicateAsync(o => o.Name == groupCreateDto.OfficeName).Result.Id;
            var result = _unitOfWork.GroupRepository.AddAsync(group).GetAwaiter().GetResult; 
            _unitOfWork.Commit();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public bool DeleteGroup(int id)
    {
        try
        {
            var group = _unitOfWork.GroupRepository.GetByIdAsync(id).Result;
            var result = _unitOfWork.GroupRepository.DeleteAsync(group).GetAwaiter().GetResult; 
            _unitOfWork.Commit();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public GroupReturnDto GetGroupById(int id)
    {
        var group = _unitOfWork.GroupRepository.GetByIdAsync(id).Result;
        return _mapper.Map<GroupReturnDto>(group);
    }

    public bool UpdateGroup(GroupCreateDto groupCreateDto)
    {
        var groupEntity = _mapper.Map<Group>(groupCreateDto);
        
        var existingGroup = _unitOfWork.GroupRepository.GetByIdAsync(groupEntity.Id).Result;

        if (existingGroup == null)
        {
            return false;
        }
        groupEntity.Id = existingGroup.Id;
        _unitOfWork.GroupRepository.UpdateAsync(groupEntity);      
        _unitOfWork.Commit();
        return true;
    }
}