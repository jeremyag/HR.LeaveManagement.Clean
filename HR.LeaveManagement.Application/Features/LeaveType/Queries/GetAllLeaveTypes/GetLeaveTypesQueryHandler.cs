using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.MappingProfiles;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

public class GetLeaveTypesQueryHandler : IRequestHandler<GetLeaveTypesQuery, List<LeaveTypeDto>>
{
    private readonly IMapper _mapper;
    private readonly ILeaveAllocationRepository _leaveRepository;

    public GetLeaveTypesQueryHandler(
        IMapper mapper, ILeaveAllocationRepository leaveRepository
        )
    {
        _mapper = mapper;
        _leaveRepository = leaveRepository;
    }
    public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypesQuery request, CancellationToken cancellationToken)
    {
        // Query the database
        var leaveTypes = await _leaveRepository.GetAsync();

        // Map to DTOs
        var data = _mapper.Map<List<LeaveTypeDto>>(leaveTypes);

        // return
        return data;
    }
}
