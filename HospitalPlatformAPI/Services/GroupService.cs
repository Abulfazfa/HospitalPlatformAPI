using AutoMapper;
using HospitalPlatformAPI.DTOs.Group;
using HospitalPlatformAPI.Models;
using HospitalPlatformAPI.Repositories.Interfaces;
using HospitalPlatformAPI.Services.Interfaces;

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
        var groups = _unitOfWork.GroupRepository.GetAllAsync().GetAwaiter().GetResult();
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
            var group = GetGroup(id);
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
        var group = GetGroup(id);
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

        existingGroup.GroupName = groupCreateDto.GroupName;
        existingGroup.AdministratorName = groupCreateDto.AdministratorName;
        _unitOfWork.Commit();
        return true;
    }


    private Group GetGroup(int id)
    {
        return _unitOfWork.GroupRepository.GetByIdAsync(id).GetAwaiter().GetResult();
    }
}