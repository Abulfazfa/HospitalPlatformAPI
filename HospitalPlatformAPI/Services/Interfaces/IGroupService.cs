using HospitalPlatformAPI.Models;
using HospitalPlatformAPI.DTOs.Group;
using Group = System.Text.RegularExpressions.Group;

namespace HospitalPlatformAPI.Services.Interfaces;

public interface IGroupService
{
    List<GroupReturnDto> GetGroups();
    bool AddGroup(GroupCreateDto groupCreateDto);
    bool DeleteGroup(int id);
    GroupReturnDto GetGroupById(int id);
    bool UpdateGroup(GroupCreateDto groupCreateDto);
}